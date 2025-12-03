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
            string login = AuthorizationUser();

            if (login != string.Empty)
            {
                user = provider.GetUser(login);

                ShowUserTreeNode();
                SetHeaderWindowText();
                ShowExportSubMenu();

                treeView.Width = splitContainer.Panel1.Width;
                treeView.Height = splitContainer.Panel1.Height - 152;

                troubleTicketsDataGridView.Size = splitContainer.Panel2.Size;

                userNameToolStripStatusLabel.Text = $"Имя: {user.Name}";
                loginToolStripStatusLabel.Text = $"Логин: {user.Login}";
                userNameToolStripMenuItem.Text = $"&{user.Name}";
            }
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

                userNameToolStripStatusLabel.Text = $"Имя: {user.Name}";
                loginToolStripStatusLabel.Text = $"Логин: {user.Login}";
                userNameToolStripMenuItem.Text = $"&{user.Name}";
                treeView.SelectedNode = treeView.Nodes[0];

                ShowUserTreeNode();
                ShowExportSubMenu();
                Show();
            }
        }

        private void SplitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            treeView.Width = splitContainer.Panel1.Width;
            treeView.Height = splitContainer.Panel1.Height - 152;
            editUserButton.Location = new Point(openTrubleTicketButton.Location.X, splitContainer.Panel1.Height - 117);
            openTrubleTicketButton.Location = new Point(openTrubleTicketButton.Location.X, splitContainer.Panel1.Height - 88);
            addTrubleTicketbutton.Location = new Point(openTrubleTicketButton.Location.X, splitContainer.Panel1.Height - 59);
            exitButton.Location = new Point(exitButton.Location.X, splitContainer.Panel1.Height - 30);
        }

        private void SplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            troubleTicketsDataGridView.Size = splitContainer.Panel2.Size;
        }

        private void OpenTrubleTicketButton_Click(object sender, EventArgs e)
        {
            if (troubleTicketsDataGridView.SelectedRows.Count != 0)
            {
                var ticketId = Convert.ToInt32(troubleTicketsDataGridView.SelectedCells[0].Value);

                var resolvedUser = Convert.ToInt32(provider.GetTroubleTicket(ticketId).ResolveUser != null ? user.Id : -1);

                if (user.IsEmployee && resolvedUser == -1)
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
                treeView.SelectedNode = treeView.Nodes["trubleTicketlist"].Nodes["openTrubleTicket"];
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
                if (treeView.SelectedNode.Parent.Name == "trubleTicketlist" || treeView.SelectedNode.Parent.Name == "statusTrubleTicketNode")
                {
                    openTrubleTicketButton.PerformClick();
                }

                if (treeView.SelectedNode.Parent.Name == "usersNode")
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
                isSupport = user.Department == "Техническая поддержка";
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
                if (treeView.SelectedNode.Parent.Name == "trubleTicketlist" || treeView.SelectedNode.Parent.Name == "statusTrubleTicketNode")
                {
                    RefreshTroubleTicketsDataGrid();
                    editUserButton.Enabled = false;
                    openTrubleTicketButton.Enabled = true;
                }

                if (treeView.SelectedNode.Parent.Name == "usersNode")
                {
                    RefreshUsersDataGrid();
                    editUserButton.Enabled = true;
                    openTrubleTicketButton.Enabled = false;
                }
            }
            else
            {
                editUserButton.Enabled = false;
                openTrubleTicketButton.Enabled = false;
            }
        }

        private void ShowUserTreeNode()
        {
            if (!user.IsEmployee || user.Department == "Техническая поддержка")
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
            TreeNode treeNode1 = new TreeNode("Все пользователи");
            TreeNode treeNode2 = new TreeNode("Клиенты");
            TreeNode treeNode3 = new TreeNode("Сотрудники");
            TreeNode treeNode4 = new TreeNode("Пользователи", new TreeNode[] { treeNode1, treeNode2, treeNode3 });

            treeNode1.Name = "allUsersNode";
            treeNode2.Name = "clientsNode";
            treeNode3.Name = "EmployeeNode";
            treeNode4.Name = "usersNode";

            treeView.Nodes.AddRange(new TreeNode[] { treeNode4 });
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
                case "allUsersNode":
                    FillUsersDataGridView(provider.GetAllUsers());
                    break;
                case "clientsNode":
                    FillUsersDataGridView(provider.GetAllUsers().Where(u => !u.IsEmployee).ToList());
                    break;
                case "EmployeeNode":
                    FillUsersDataGridView(provider.GetAllUsers().Where(u => u.IsEmployee).ToList());
                    break;
                default:
                    break;
            }
        }

        private void RefreshTroubleTicketsDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;

            if (selectedNode == "statusTrubleTicketNode")
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
                case "allTrubleTicket":
                    FillTroubleTicketsDataGridView(troubleTickets);
                    break;
                case "openTrubleTicket":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.IsSolved == false).ToList());
                    break;
                case "closedTrubleTicket":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.IsSolved == true).ToList());
                    break;
                case "overdueTrubleTicketNode":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => (DateTime.Now - s.Deadline).TotalSeconds > 0).ToList());
                    break;
                case "registeredTrubleTicketNode":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == "Зарегистрирована").ToList());
                    break;
                case "workTrubleTicketNode":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == "В работе").ToList());
                    break;
                case "completedTrubleTicketNode":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == "Выполнена").ToList());
                    break;
                case "rejectedTrubleTicketNode":
                    FillTroubleTicketsDataGridView(troubleTickets.Where(s => s.Status == "Отклонена").ToList());
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

            var countRow = allTroubleTickets.Count;
            var allUsers = provider.GetAllUsers();

            for (int i = 0; i < countRow; i++)
            {
                var user = allUsers.Where(u => u.Id == allTroubleTickets[i].CreateUser).FirstOrDefault();
                var resolveUser = allUsers.Where(u => u.Id == allTroubleTickets[i].ResolveUser).FirstOrDefault();

                troubleTicketsDataGridView.Rows.Add();

                troubleTicketsDataGridView.Rows[i].Cells[0].Value = allTroubleTickets[i].Id;

                if (allTroubleTickets[i].IsSolved)
                {
                    troubleTicketsDataGridView.Rows[i].Cells[1].Value = "Да";
                    troubleTicketsDataGridView.Rows[i].DefaultCellStyle.BackColor = allTroubleTickets[i].Status == "Выполнена" ? Color.LightGreen : Color.LightGray;
                }
                else
                {
                    troubleTicketsDataGridView.Rows[i].Cells[1].Value = "Нет";

                    if ((DateTime.Now - allTroubleTickets[i].Deadline).TotalSeconds > 0)
                    {
                        troubleTicketsDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }

                    if (allTroubleTickets[i].Status == "В работе")
                    {
                        troubleTicketsDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }

                troubleTicketsDataGridView.Rows[i].Cells[2].Value = allTroubleTickets[i].Status;

                if (allTroubleTickets[i].Text.Length > 50)
                {
                    troubleTicketsDataGridView.Rows[i].Cells[3].Value = $"{allTroubleTickets[i].Text.Substring(0, 47)}...";
                }
                else
                {
                    troubleTicketsDataGridView.Rows[i].Cells[3].Value = allTroubleTickets[i].Text;
                }

                troubleTicketsDataGridView.Rows[i].Cells[4].Value = allTroubleTickets[i].Resolve;
                troubleTicketsDataGridView.Rows[i].Cells[5].Value = resolveUser != null ? resolveUser.Name : string.Empty;
                troubleTicketsDataGridView.Rows[i].Cells[6].Value = allTroubleTickets[i].Created;
                troubleTicketsDataGridView.Rows[i].Cells[7].Value = allTroubleTickets[i].ResolveTime;
                troubleTicketsDataGridView.Rows[i].Cells[8].Value = allTroubleTickets[i].Deadline;
                troubleTicketsDataGridView.Rows[i].Cells[9].Value = $"{user.Name} \\ {user.Email}";
            }

            troubleTicketsDataGridView.ClearSelection();
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