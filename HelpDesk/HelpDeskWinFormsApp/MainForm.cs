using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Application;
using HelpDesk.Common.Models;
using HelpDesk.Common.System;
using HelpDesk.Common.Constants;
using HelpDeskWinFormsApp.Costants;

namespace HelpDeskWinFormsApp
{
    public partial class MainForm : Form
    {
        private User user = new();
        private readonly IUserProvider userProvider;
        private readonly ITroubleTicketProvider troubleTicketProvider;
        public const int InvalidId = -1;

        public MainForm(ApplicationDIController controller,
                IUserProvider userProvider,
                ITroubleTicketProvider troubleTicketProvider)
        {
            this.userProvider = userProvider;
            this.troubleTicketProvider = troubleTicketProvider;

            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            var login = AuthorizationUser();

            if (!string.IsNullOrEmpty(login))
            {
                InitializeUserSession(login);
            }
        }

        private void InitializeUserSession(string login)
        {
            user = userProvider.GetUser(login);

            SetupUserInterface();
            SetupTreeViewLayout();
            SetupDataGridViewLayout();

            UpdateUserInfoUI();
        }

        private void SetupUserInterface()
        {
            ShowUserTreeNode();
            SetWindowHeaderText();
            ShowExportSubMenu();
        }

        private void SetupTreeViewLayout()
        {
            treeView.Width = splitContainer.Panel1.Width;
            treeView.Height = splitContainer.Panel1.Height - UIConstants.TreeViewBottomMargin;
        }

        private void SetupDataGridViewLayout()
        {
            troubleTicketsDataGridView.Size = splitContainer.Panel2.Size;
        }

        private void UpdateUserInfoUI()
        {
            userNameToolStripStatusLabel.Text = $"Имя: {user.Name}";
            loginToolStripStatusLabel.Text = $"Логин: {user.Login}";
            userNameToolStripMenuItem.Text = $"&{user.Name}";
        }

        private void ShowExportSubMenu()
        {
            exportToolStripMenuItem.Visible = user.IsEmployee;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
            Hide();

            var login = AuthorizationUser();

            if (!string.IsNullOrEmpty(login))
            {
                user = userProvider.GetUser(login);
                SetWindowHeaderText();
                UpdateUserInfoUI();
                ResetTreeViewSelection();
                ShowUserTreeNode();
                ShowExportSubMenu();
                Show();
            }
        }

        private void ClearDataGridView()
        {
            troubleTicketsDataGridView.Rows.Clear();
            troubleTicketsDataGridView.Columns.Clear();
        }

        private void ResetTreeViewSelection()
        {
            treeView.SelectedNode = treeView.Nodes[0];
        }

        private void SplitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            UpdateTreeViewLayout();
            UpdateButtonPositions();
        }

        private void UpdateTreeViewLayout()
        {
            treeView.Width = splitContainer.Panel1.Width;
            treeView.Height = splitContainer.Panel1.Height - UIConstants.TreeViewBottomMargin;
        }

        private void UpdateButtonPositions()
        {
            var panelHeight = splitContainer.Panel1.Height;

            editUserButton.Location = new Point(
                openTroubleTicketButton.Location.X,
                panelHeight - UIConstants.EditButtonOffset);

            openTroubleTicketButton.Location = new Point(
                openTroubleTicketButton.Location.X,
                panelHeight - UIConstants.OpenButtonOffset);

            addTroubleTicketbutton.Location = new Point(
                openTroubleTicketButton.Location.X,
                panelHeight - UIConstants.AddButtonOffset);

            exitButton.Location = new Point(
                exitButton.Location.X,
                panelHeight - UIConstants.ExitButtonOffset);
        }

        private void SplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            troubleTicketsDataGridView.Size = splitContainer.Panel2.Size;
        }

        private void OpenTroubleTicketButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedTicketId(out int ticketId))
            {
                OpenTroubleTicketForm(ticketId);
            }
        }

        private bool TryGetSelectedTicketId(out int ticketId)
        {
            ticketId = InvalidId;

            if (troubleTicketsDataGridView.SelectedRows.Count > 0)
            {
                ticketId = Convert.ToInt32(troubleTicketsDataGridView.SelectedCells[0].Value);
                return true;
            }

            return false;
        }

        private void OpenTroubleTicketForm(int ticketId)
        {
            var resolveUserId = GetResolveUserIdForTicket(ticketId);

            using (var ticketForm = new TroubleTicketForm(ticketId, user.IsEmployee, resolveUserId, troubleTicketProvider, userProvider))
            {
                if (ticketForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshTroubleTicketsDataGrid();
                }
            }
        }

        private int GetResolveUserIdForTicket(int ticketId)
        {
            var ticket = troubleTicketProvider.GetTroubleTicket(ticketId);

            if (ticket.ResolveUser != null)
            {
                return (int)ticket.ResolveUser;
            }

            return user.IsEmployee ? user.Id : InvalidId;
        }

        private void AddTroubleTicketButton_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddTroubleTicketForm(user, troubleTicketProvider))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    SelectOpenTroubleTicketsNode();
                    RefreshTroubleTicketsDataGrid();
                }
            }
        }

        private void SelectOpenTroubleTicketsNode()
        {
            treeView.SelectedNode = treeView.Nodes[TreeViewNodes.TroubleTicketList]
                .Nodes[TreeViewNodes.OpenTroubleTickets];
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refreshToolStripMenuItem.PerformClick();
        }

        private void RefreshDataGridBasedOnSelectedNode()
        {
            if (treeView.SelectedNode?.Parent == null) return;

            var parentName = treeView.SelectedNode.Parent.Name;

            UpdateButtonStates(parentName);

            if (parentName == TreeViewNodes.TroubleTicketList ||
                parentName == TreeViewNodes.StatusTroubleTicket)
            {
                RefreshTroubleTicketsDataGrid();
                return;
            }
            if (parentName == TreeViewNodes.Users)
            {
                RefreshUsersDataGrid();
                return;
            }
        }

        private void UpdateButtonStates(string parentName)
        {
            var isUsersNode = parentName == TreeViewNodes.Users;

            editUserButton.Enabled = isUsersNode;
            openTroubleTicketButton.Enabled = !isUsersNode;
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDataGridBasedOnSelectedNode();
        }

        private void ListTTDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (treeView.SelectedNode?.Parent == null) return;

            var parentName = treeView.SelectedNode.Parent.Name;

            if (parentName == TreeViewNodes.TroubleTicketList ||
                parentName == TreeViewNodes.StatusTroubleTicket)
            {
                openTroubleTicketButton.PerformClick();
                return;
            }
            if (parentName == TreeViewNodes.Users)
            {
                editUserButton.PerformClick();
                return;
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isSupport = user.IsEmployee && user.Department == Departments.TechnicalSupport;

            using (var exportForm = new ExportForm(isSupport, userProvider, troubleTicketProvider))
            {
                exportForm.ShowDialog();
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedUserId(out int userId))
            {
                OpenEditUserForm(userId);
            }
        }

        private bool TryGetSelectedUserId(out int userId)
        {
            userId = InvalidId;

            if (troubleTicketsDataGridView.SelectedRows.Count > 0)
            {
                userId = Convert.ToInt32(troubleTicketsDataGridView.SelectedCells[0].Value);
                return true;
            }

            return false;
        }

        private void OpenEditUserForm(int userId)
        {
            using (var editForm = new EditUserForm(userId, userProvider))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshUsersDataGrid();
                }
            }
        }

        private void SetWindowHeaderText()
        {
            var userType = user.IsEmployee ? $"{user.Function}: {user.Name}" : $"Клиент: {user.Name}";
            Text = $"HelpDesk. {userType}/{user.Login}";
        }

        private void RemoveUserTreeNode()
        {
            if (treeView.Nodes.Count > 1)
            {
                treeView.Nodes.RemoveAt(1);
            }
        }

        private void ShowUserTreeNode()
        {
            var shouldShowUsersNode = user.IsEmployee && user.Department != Departments.TechnicalSupport;

            editUserButton.Visible = shouldShowUsersNode;

            if (!shouldShowUsersNode)
            {
                RemoveUserTreeNode();
                return;
            }

            if (treeView.Nodes.Count == 1)
            {
                var usersNode = CreateUsersTreeStructure();
                treeView.Nodes.Add(usersNode); 
            }      

           
        }

        private TreeNode CreateUsersTreeStructure()
        {
            var allUsersNode = new TreeNode("Все пользователи")
            {
                Name = TreeViewNodes.AllUsers
            };

            var clientsNode = new TreeNode("Клиенты")
            {
                Name = TreeViewNodes.Clients
            };

            var employeesNode = new TreeNode("Сотрудники")
            {
                Name = TreeViewNodes.Employees
            };

            return new TreeNode("Пользователи", new TreeNode[] { allUsersNode, clientsNode, employeesNode })
            {
                Name = TreeViewNodes.Users
            };
        }

        private string AuthorizationUser()
        {
            var authorizationForm = new AuthorizationForm(userProvider);

            if (authorizationForm.ShowDialog() == DialogResult.OK)
            {
                return authorizationForm.loginTextBox.Text;
            }

            return HandleAuthorizationFailure(authorizationForm.RegistrationChoice);
        }

        private string HandleAuthorizationFailure(bool isNeedRegistration)
        {
            if (!isNeedRegistration)
            {
                Environment.Exit(0);
                return string.Empty;
            }

            return ProcessRegistration();
        }

        private string ProcessRegistration()
        {
            using (var registrationForm = new RegistrationForm(userProvider))
            {
                DialogResult result = registrationForm.ShowDialog();

                switch (result)
                {
                    case DialogResult.OK:
                        return registrationForm.loginTextBox.Text;
                    case DialogResult.Cancel:
                        Application.Restart();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }

            return string.Empty;
        }

        private void RefreshUsersDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;
            var users = GetFilteredUsers(selectedNode);

            ClearAndSetupDataGridViewForUsers();
            FillUsersDataGridView(users);
        }

        private List<User> GetFilteredUsers(string nodeName)
        {
           var allUsers = userProvider.GetAllUsers();

            return nodeName switch
            {
                TreeViewNodes.AllUsers => allUsers,
                TreeViewNodes.Clients => allUsers.Where(u => !u.IsEmployee).ToList(),
                TreeViewNodes.Employees => allUsers.Where(u => u.IsEmployee).ToList(),
                _ => new List<User>()
            };
        }

        private void ClearAndSetupDataGridViewForUsers()
        {
            troubleTicketsDataGridView.Columns.Clear();
            AddUserColumnsToDataGridView();
        }

        private void AddUserColumnsToDataGridView()
        {
            troubleTicketsDataGridView.Columns.Add("id", "ID");
            troubleTicketsDataGridView.Columns.Add("name", "Имя");
            troubleTicketsDataGridView.Columns.Add("login", "Логин");
            troubleTicketsDataGridView.Columns.Add("email", "E-Mail");
            troubleTicketsDataGridView.Columns.Add("discriminator", "Тип");
            troubleTicketsDataGridView.Columns.Add("function", "Функция");
            troubleTicketsDataGridView.Columns.Add("department", "Отдел");
        }

        private void FillUsersDataGridView(List<User> users)
        {
            troubleTicketsDataGridView.Rows.Clear();

            foreach (var userData in users)
            {
                var rowIndex = troubleTicketsDataGridView.Rows.Add();
                var row = troubleTicketsDataGridView.Rows[rowIndex];

                PopulateUserRow(row, userData);
            }

            troubleTicketsDataGridView.ClearSelection();
        }

        private void PopulateUserRow(DataGridViewRow row, User userData)
        {
            row.Cells[0].Value = userData.Id;
            row.Cells[1].Value = userData.Name;
            row.Cells[2].Value = userData.Login;
            row.Cells[3].Value = userData.Email;
            row.Cells[4].Value = userData.IsEmployee ? "Сотрудник" : "Клиент";

            if (userData.IsEmployee)
            {
                row.Cells[5].Value = userData.Function;
                row.Cells[6].Value = userData.Department;
                return;
            }
                        
            row.Cells[5].Style.BackColor = Color.Gray;
            row.Cells[6].Style.BackColor = Color.Gray;
            
        }

        private void RefreshTroubleTicketsDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;

            if (selectedNode == TreeViewNodes.StatusTroubleTicket)
            {
                return;
            }

           var tickets = GetFilteredTroubleTickets(selectedNode);

            ClearAndSetupDataGridViewForTickets();
            FillTroubleTicketsDataGridView(tickets);
        }

        private List<TroubleTicket> GetFilteredTroubleTickets(string nodeName)
        {
            var allTickets = GetAllRelevantTickets();

            return nodeName switch
            {
                TreeViewNodes.AllTroubleTickets => allTickets,
                TreeViewNodes.OpenTroubleTickets => allTickets.Where(t => !t.IsSolved).ToList(),
                TreeViewNodes.ClosedTroubleTickets => allTickets.Where(t => t.IsSolved).ToList(),
                TreeViewNodes.OverdueTroubleTickets => allTickets.Where(t => DateTime.Now > t.Deadline).ToList(),
                TreeViewNodes.RegisteredTroubleTickets => allTickets.Where(t => t.Status == TicketStatuses.Registered).ToList(),
                TreeViewNodes.WorkTroubleTickets => allTickets.Where(t => t.Status == TicketStatuses.InProgress).ToList(),
                TreeViewNodes.CompletedTroubleTickets => allTickets.Where(t => t.Status == TicketStatuses.Completed).ToList(),
                TreeViewNodes.RejectedTroubleTickets => allTickets.Where(t => t.Status == TicketStatuses.Rejected).ToList(),
                _ => new List<TroubleTicket>()
            };
        }

        private List<TroubleTicket> GetAllRelevantTickets()
        {
            return user.IsEmployee
                ? troubleTicketProvider.GetAllTroubleTickets()
                : troubleTicketProvider.GetAllTroubleTickets().Where(t => t.CreateUserId == user.Id).ToList();
        }

        private void ClearAndSetupDataGridViewForTickets()
        {
            troubleTicketsDataGridView.Columns.Clear();
            AddTicketColumnsToDataGridView();
        }

        private void FillTroubleTicketsDataGridView(List<TroubleTicket> tickets)
        {
            troubleTicketsDataGridView.Rows.Clear();
            var allUsers = userProvider.GetAllUsers();

            foreach (var ticket in tickets)
            {
                var rowIndex = troubleTicketsDataGridView.Rows.Add();
                var row = troubleTicketsDataGridView.Rows[rowIndex];

                PopulateTicketRow(row, ticket, allUsers);
            }

            troubleTicketsDataGridView.ClearSelection();
        }

        private void PopulateTicketRow(DataGridViewRow row, TroubleTicket ticket, List<User> allUsers)
        {
            var createUser = allUsers.FirstOrDefault(u => u.Id == ticket.CreateUserId);
            var resolveUser = allUsers.FirstOrDefault(u => u.Id == ticket.ResolveUser);

            row.Cells[0].Value = ticket.Id;
            row.Cells[1].Value = ticket.IsSolved ? "Да" : "Нет";
            row.Cells[2].Value = ticket.Status;
            row.Cells[3].Value = GetPreviewText(ticket.Text);
            row.Cells[4].Value = ticket.Resolve;
            row.Cells[5].Value = resolveUser?.Name ?? string.Empty;
            row.Cells[6].Value = ticket.Created;
            row.Cells[7].Value = ticket.ResolveTime;
            row.Cells[8].Value = ticket.Deadline;
            row.Cells[9].Value = $"{createUser?.Name} \\ {createUser?.Email}";

            ApplyRowStylingBasedOnTicket(row, ticket);
        }

        private void ApplyRowStylingBasedOnTicket(DataGridViewRow row, TroubleTicket ticket)
        {
            if (ticket.IsSolved)
            {
                row.DefaultCellStyle.BackColor = ticket.Status == TicketStatuses.Completed
                    ? Color.LightGreen
                    : Color.LightGray;
                     return;
            }
            if (DateTime.Now > ticket.Deadline)
            {
                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                return;
            }
                        
            if (ticket.Status == TicketStatuses.InProgress)
            {
                row.DefaultCellStyle.BackColor = Color.LightYellow;
                return;
            }
            row.DefaultCellStyle.BackColor = Color.Empty;
        }

        private string GetPreviewText(string text)
        {
            if (text.Length > UIConstants.TextPreviewLength)
            {
                return $"{text.Substring(0, UIConstants.TextPreviewEllipsisLength)}...";
            }
            return text;
        }

        private void AddTicketColumnsToDataGridView()
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