using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Application;
using HelpDesk.Common.Models;
using HelpDesk.Common.System;

namespace HelpDeskWinFormsApp
{
    public partial class MainForm : Form
    {       

        private User user = new();
        private IProvider provider;

        public MainForm(ApplicationDIController controller)
        {
            controller.Start();
            InitializeComponent();
            GetProvider();
        }

        public void GetProvider()
        {
            SystemManager.Get(out provider);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var login = AuthorizationUser();

            if (login != string.Empty)
            {
                user = provider.GetUser(login);

                ShowUserTreeNode();
                SetHeaderWindowText();
                ShowExportSubMenu();

                treeView.Width = splitContainer.Panel1.Width;
                treeView.Height = splitContainer.Panel1.Height - AppConstants.TreeViewBottomMargin;

                troubleTicketsDataGridView.Size = splitContainer.Panel2.Size;

                UpdateUserInfoUI();
            }
        }

        private void UpdateUserInfoUI()
        {
            userNameToolStripStatusLabel.Text = $"Имя: {user.Name}";
            loginToolStripStatusLabel.Text = $"Логин: {user.Login}";
            userNameToolStripMenuItem.Text = $"&{user.Name}";
        }

        private void ShowExportSubMenu()
        {
            if (!user.IsEmployee)
            {
                exportToolStripMenuItem.Visible = false;
            }
            else
            {
                exportToolStripMenuItem.Visible = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            troubleTicketsDataGridView.Rows.Clear();
            troubleTicketsDataGridView.Columns.Clear();

            Hide();

            var login = AuthorizationUser();

            if (login != string.Empty)
            {
                user = provider.GetUser(login);

                SetHeaderWindowText();

                UpdateUserInfoUI();
                treeView.SelectedNode = treeView.Nodes[0];

                ShowUserTreeNode();
                ShowExportSubMenu();
                Show();
            }
        }

        private void SplitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            treeView.Width = splitContainer.Panel1.Width;
            treeView.Height = splitContainer.Panel1.Height - AppConstants.TreeViewBottomMargin;
            editUserButton.Location = new Point(openTroubleTicketButton.Location.X, splitContainer.Panel1.Height - AppConstants.EditButtonOffset);
            openTroubleTicketButton.Location = new Point(openTroubleTicketButton.Location.X, splitContainer.Panel1.Height - AppConstants.OpenButtonOffset);
            addTroubleTicketbutton.Location = new Point(openTroubleTicketButton.Location.X, splitContainer.Panel1.Height - AppConstants.AddButtonOffset);
            exitButton.Location = new Point(exitButton.Location.X, splitContainer.Panel1.Height - AppConstants.ExitButtonOffset);
        }

        private void SplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            troubleTicketsDataGridView.Size = splitContainer.Panel2.Size;
        }

        private void OpenTroubleTicketButton_Click(object sender, EventArgs e)
        {
            if (troubleTicketsDataGridView.SelectedRows.Count != 0)
            {
                var ticketId = Convert.ToInt32(troubleTicketsDataGridView.SelectedCells[0].Value);

                var resolvedUser = Convert.ToInt32(provider.GetTroubleTicket(ticketId).ResolveUser != null ? user.Id : -1);

                if (user.IsEmployee && resolvedUser == AppConstants.InvalidUserId)
                {
                    resolvedUser = user.Id;
                }

                var dialogResult = new TroubleTicketForm(ticketId, user.IsEmployee, resolvedUser, provider).ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    RefreshTroubleTicketsDataGrid();
                }
            }
        }

        private void AddTroubleTicketButton_Click(object sender, EventArgs e)
        {
            var dialogResult = new AddTroubleTicketForm(user, provider);

            if (dialogResult.ShowDialog() == DialogResult.OK)
            {
                treeView.SelectedNode = treeView.Nodes[AppConstants.TreeNodeTrubleTicketList].Nodes[AppConstants.TreeNodeOpenTroubleTickets];
                RefreshTroubleTicketsDataGrid();
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refreshToolStripMenuItem.PerformClick();
        }

        private void ListTTDataGridView_DoubleClick(object sender, EventArgs e)
        {            

            if (treeView.SelectedNode.Level != 0)
            {
                var parentName = treeView.SelectedNode.Parent.Name;

                if (parentName == AppConstants.TreeNodeTrubleTicketList || parentName == AppConstants.TreeNodeStatusTroubleTicket)
                {
                    openTroubleTicketButton.PerformClick();
                }

                if (parentName == AppConstants.TreeNodeUsers)
                {
                    editUserButton.PerformClick();
                }
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isSupport = false;

            if (user.IsEmployee)
            {
                isSupport = user.Department == AppConstants.DepartmentTechnicalSupport; 
            }

            new ExportForm(isSupport, provider).ShowDialog();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            if (troubleTicketsDataGridView.SelectedRows.Count != 0)
            {
                var userId = Convert.ToInt32(troubleTicketsDataGridView.SelectedCells[0].Value);

                var dialogResult = new EditUserForm(userId, provider).ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    RefreshUsersDataGrid();
                }
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Level != 0)
            {
                var parentName = treeView.SelectedNode.Parent.Name;

                if (parentName == AppConstants.TreeNodeTrubleTicketList || parentName == AppConstants.TreeNodeStatusTroubleTicket)
                {
                    RefreshTroubleTicketsDataGrid();
                    editUserButton.Enabled = false;
                    openTroubleTicketButton.Enabled = true;
                }

                if (parentName == AppConstants.TreeNodeUsers)
                {
                    RefreshUsersDataGrid();
                    editUserButton.Enabled = true;
                    openTroubleTicketButton.Enabled = false;
                }
            }
            else
            {
                editUserButton.Enabled = false;
                openTroubleTicketButton.Enabled = false;
            }
        }

        private void ShowUserTreeNode()
        {
            if (!user.IsEmployee || user.Department == AppConstants.DepartmentTechnicalSupport)
            {
                RemoveUserTreeNode();
                editUserButton.Visible = false;
            }
            else
            {
                if (treeView.Nodes.Count == 1)
                {
                    AddUserTreeNode();
                }

                editUserButton.Visible = true;
            }
        }

        private void SetHeaderWindowText()
        {
            if (user.IsEmployee)
            {
                Text = $"HelpDesk. {user.Function}: {user.Name}/{user.Login}";
            }
            else
            {
                Text = $"HelpDesk. Клиент: {user.Name}/{user.Login}";
            }
        }

        private void RemoveUserTreeNode()
        {
            if (treeView.Nodes.Count > 1)
            {
                treeView.Nodes.RemoveAt(1);
            }
        }

        private void AddUserTreeNode()
        {
            var allUsersNode = new TreeNode("Все пользователи") { Name = AppConstants.TreeNodeAllUsers };
            var clientsNode = new TreeNode("Клиенты") { Name = AppConstants.TreeNodeClients };
            var employeesNode = new TreeNode("Сотрудники") { Name = AppConstants.TreeNodeEmployees };
            var usersNode = new TreeNode("Пользователи", new TreeNode[] { allUsersNode, clientsNode, employeesNode })
            {
                Name = AppConstants.TreeNodeUsers
            };

            treeView.Nodes.AddRange(new TreeNode[] { usersNode });
        }

        private string AuthorizationUser()
        {
            var isNeedRegistration = false;
            var login = string.Empty;
            var authorizationForm = new AuthorizationForm(provider);

            if (authorizationForm.ShowDialog() == DialogResult.OK)
            {
                login = authorizationForm.loginTextBox.Text;
            }
            else
            {
                isNeedRegistration = authorizationForm.RegistrationChoice;

                if (!isNeedRegistration)
                {
                    Environment.Exit(0);
                    return string.Empty;
                }
            }

            if (isNeedRegistration)
            {
                var registrationForm = new RegistrationForm(provider);
                var registrationFormDialogResult = registrationForm.ShowDialog();

                if (registrationFormDialogResult == DialogResult.OK)
                {
                    login = registrationForm.loginTextBox.Text;
                }
                else if (registrationFormDialogResult == DialogResult.Cancel)
                {
                    Application.Restart();
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            return login;
        }

        private void RefreshUsersDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;

            troubleTicketsDataGridView.Columns.Clear();

            switch (selectedNode)
            {
                case AppConstants.TreeNodeAllUsers:
                    FillUsersDataGridView(provider.GetAllUsers());
                    break;
                case AppConstants.TreeNodeClients:
                    FillUsersDataGridView(provider.GetAllUsers().Where(u => !u.IsEmployee).ToList());
                    break;
                case AppConstants.TreeNodeEmployees:
                    FillUsersDataGridView(provider.GetAllUsers().Where(u => u.IsEmployee).ToList());
                    break;
                default:
                    break;
            }
        }

        private void RefreshTroubleTicketsDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;

            if (selectedNode == AppConstants.TreeNodeStatusTroubleTicket)
            {
                return;
            }

            List<TroubleTicket> troubleTickets = new();

            troubleTicketsDataGridView.Columns.Clear();

            if (user.IsEmployee)
            {
                troubleTickets = provider.GetAllTroubleTickets();
            }
            else
            {
                troubleTickets = provider.GetAllTroubleTickets().Where(t => t.CreateUser == user.Id).ToList();
            }

            switch (selectedNode)
            {
                case AppConstants.TreeNodeAllTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets);
                    break;
                case AppConstants.TreeNodeOpenTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.IsSolved == false).ToList());
                    break;
                case AppConstants.TreeNodeClosedTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.IsSolved == true).ToList());
                    break;
                case AppConstants.TreeNodeOverdueTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => (DateTime.Now - s.Deadline).TotalSeconds > 0).ToList());
                    break;
                case AppConstants.TreeNodeRegisteredTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == AppConstants.StatusRegistered).ToList());
                    break;
                case AppConstants.TreeNodeWorkTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == AppConstants.StatusInProgress).ToList());
                    break;
                case AppConstants.TreeNodeCompletedTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == AppConstants.StatusCompleted).ToList());
                    break;
                case AppConstants.TreeNodeRejectedTroubleTickets:
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == AppConstants.StatusRejected).ToList());
                    break;
                default:
                    break;
            }
        }

        private void FillUsersDataGridView(List<User> users)
        {
            troubleTicketsDataGridView.Columns.Add("id", "ID");
            troubleTicketsDataGridView.Columns.Add("name", "Имя");
            troubleTicketsDataGridView.Columns.Add("login", "Логин");
            troubleTicketsDataGridView.Columns.Add("email", "E-Mail");
            troubleTicketsDataGridView.Columns.Add("discriminator", "Тип");
            troubleTicketsDataGridView.Columns.Add("function", "Функция");
            troubleTicketsDataGridView.Columns.Add("department", "Отдел");

            troubleTicketsDataGridView.Rows.Clear();

            var countRows = users.Count;

            for (int i = 0; i < countRows; i++)
            {
                troubleTicketsDataGridView.Rows.Add();
                troubleTicketsDataGridView.Rows[i].Cells[0].Value = users[i].Id;
                troubleTicketsDataGridView.Rows[i].Cells[1].Value = users[i].Name;
                troubleTicketsDataGridView.Rows[i].Cells[2].Value = users[i].Login;
                troubleTicketsDataGridView.Rows[i].Cells[3].Value = users[i].Email;

                var userType = users[i].IsEmployee;

                troubleTicketsDataGridView.Rows[i].Cells[4].Value = userType ? "Сотрудник" : "Клиент";

                if (userType)
                {
                    troubleTicketsDataGridView.Rows[i].Cells[5].Value = user.Function;
                    troubleTicketsDataGridView.Rows[i].Cells[6].Value = user.Department;
                }
                else
                {
                    troubleTicketsDataGridView.Rows[i].Cells[5].Style.BackColor = Color.Gray;
                    troubleTicketsDataGridView.Rows[i].Cells[6].Style.BackColor = Color.Gray;
                }
            }

            troubleTicketsDataGridView.ClearSelection();
        }

        private void FillTroubleTicketsDataGridView(List<TroubleTicket> allTroubleTickets)
        {
            AddColumnsTroubleTicketsDataGridView();

            troubleTicketsDataGridView.Rows.Clear();

            var allUsers = provider.GetAllUsers();

            foreach (var ticket in allTroubleTickets)
            {
                var user = allUsers.FirstOrDefault(u => u.Id == ticket.CreateUser);
                var resolveUser = allUsers.FirstOrDefault(u => u.Id == ticket.ResolveUser);

                var rowIndex = troubleTicketsDataGridView.Rows.Add();
                var row = troubleTicketsDataGridView.Rows[rowIndex];

                row.Cells[0].Value = ticket.Id;
                row.Cells[1].Value = ticket.IsSolved ? "Да" : "Нет";

                SetRowStyleBasedOnStatus(row, ticket);

                row.Cells[2].Value = ticket.Status;
                row.Cells[3].Value = GetPreviewText(ticket.Text);
                row.Cells[4].Value = ticket.Resolve;
                row.Cells[5].Value = resolveUser?.Name ?? string.Empty;
                row.Cells[6].Value = ticket.Created;
                row.Cells[7].Value = ticket.ResolveTime;
                row.Cells[8].Value = ticket.Deadline;
                row.Cells[9].Value = $"{user?.Name} \\ {user?.Email}";
            }

            troubleTicketsDataGridView.ClearSelection();
        }

        private void SetRowStyleBasedOnStatus(DataGridViewRow row, TroubleTicket ticket)
        {
            if (ticket.IsSolved)
            {
                row.DefaultCellStyle.BackColor = ticket.Status == AppConstants.StatusCompleted
                    ? Color.LightGreen
                    : Color.LightGray;
            }
            else
            {
                if ((DateTime.Now - ticket.Deadline).TotalSeconds > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                }

                if (ticket.Status == AppConstants.StatusInProgress)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private string GetPreviewText(string text)
        {
            if (text.Length > AppConstants.TextPreviewLength)
            {
                return $"{text.Substring(0, AppConstants.TextPreviewEllipsisLength)}...";
            }
            return text;
        }


        private void AddColumnsTroubleTicketsDataGridView()
        {
            troubleTicketsDataGridView.Columns.Add("id", "ID");
            troubleTicketsDataGridView.Columns.Add("isSolved", "Решён");
            troubleTicketsDataGridView.Columns.Add("status", "Статус");
            troubleTicketsDataGridView.Columns.Add("text", "Текст");
            troubleTicketsDataGridView.Columns.Add("resolve", "Решение");
            troubleTicketsDataGridView.Columns.Add("resolveUser", "Решил");
            troubleTicketsDataGridView.Columns.Add("created", "Создано");
            troubleTicketsDataGridView.Columns.Add("resolveDate", "Дата решения");
            troubleTicketsDataGridView.Columns.Add("deadline", "Крайний срок");
            troubleTicketsDataGridView.Columns.Add("userCreate", "Кем создано");
        }
    }
}