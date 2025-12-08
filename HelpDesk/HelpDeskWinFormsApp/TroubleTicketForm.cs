using HelpDesk.Common;
using HelpDesk.Common.Models;
using System.Windows.Forms;
using HelpDesk.Common.Constants;

namespace HelpDeskWinFormsApp
{
    public partial class TroubleTicketForm : Form
    {
        private int ticketId;
        private TroubleTicket troubleTicket;
        private User userCreate;
        private bool isEmployee;
        private int resolveUserId;
        private string lastStatus;
        private readonly ITroubleTicketProvider troubleTicketProvider;
        private readonly IUserProvider userProvider;

        public TroubleTicketForm(int ticketId, bool isEmployee, int resolveUserId, ITroubleTicketProvider troubleTicketProvider, IUserProvider userProvider)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            this.isEmployee = isEmployee;
            this.resolveUserId = resolveUserId;
            this.troubleTicketProvider = troubleTicketProvider;
            this.userProvider = userProvider;
        }

        private void TroubleTicketForm_Shown(object sender, System.EventArgs e)
        {
            troubleTicket = troubleTicketProvider.GetTroubleTicket(ticketId);
            userCreate = userProvider.GetUser(troubleTicket.CreateUserId);
            lastStatus = troubleTicket.Status;

            Text = $"HelpDesk. Заяка №{troubleTicket.Id}";
            userCreateTextBox.Text = $"{userCreate.Name} \\ {userCreate.Email}";
            troubleTicketRichTextBox.Text = troubleTicket.Text;
            statusTroubleTicketComboBox.Text = troubleTicket.Status;

            if (troubleTicket.Resolve != null)
            {
                resolveRichTextBox.Text = $"Заявка решена {troubleTicket.ResolveTime}\n\r";
                resolveRichTextBox.Text += troubleTicket.Resolve;
                resolveRichTextBox.ReadOnly = true;
                statusTroubleTicketComboBox.Enabled = false;
                saveButton.Enabled = false;
            }

            if (!isEmployee)
            {
                saveButton.Visible = false;
                resolveRichTextBox.Enabled = false;
                statusTroubleTicketComboBox.Enabled = false;
            }
        }

        private void TroubleTicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var newStatus = statusTroubleTicketComboBox.Text;

            var isResolutionRequired = newStatus == TicketStatuses.Completed ||
                        newStatus == TicketStatuses.Rejected;
            if (isResolutionRequired && resolveRichTextBox.Text == string.Empty)
            {
                e.Cancel = true;
                MessageBox.Show("Пожалуйста заполните решение.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newStatus == lastStatus) return;

            if (newStatus == TicketStatuses.Registered && lastStatus != TicketStatuses.Registered)
            {
                e.Cancel = true;
                MessageBox.Show("Возврат в статус \"Зарегистрирована\" запрещён.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isResolutionRequired)
            {
                troubleTicketProvider.ResolveTroubleTicket(troubleTicket.Id, newStatus,
                    resolveRichTextBox.Text, resolveUserId);
                return;
            }

            troubleTicketProvider.ChangeStatusTroubleTicket(troubleTicket.Id, newStatus, resolveUserId);

        }
    }
}
