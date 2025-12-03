using HelpDesk.Common;
using HelpDesk.Common.Models;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class TroubleTicketForm : Form
    {
        int ticketId;
        TroubleTicket troubleTicket;
        User userCreate;
        bool isEmployee;
        int resolveUserId;
        string lastStatus;
        private readonly IProvider provider;

        public TroubleTicketForm(int ticketId, bool isEmployee, int resolveUserId, IProvider provider)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            this.isEmployee = isEmployee;
            this.resolveUserId = resolveUserId;
            this.provider = provider;
        }

        private void TroubleTicketForm_Shown(object sender, System.EventArgs e)
        {
            troubleTicket = provider.GetTroubleTicket(ticketId);
            userCreate = provider.GetUser(troubleTicket.CreateUser);
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
            if (DialogResult == DialogResult.OK)
            {
                if (resolveRichTextBox.Text == string.Empty && (statusTroubleTicketComboBox.Text == "Выполнена" || statusTroubleTicketComboBox.Text == "Отклонена"))
                {
                    e.Cancel = true;
                    MessageBox.Show("Пожалуйста заполните решение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (statusTroubleTicketComboBox.Text != lastStatus)
                {
                    if (statusTroubleTicketComboBox.Text == "Выполнена" || statusTroubleTicketComboBox.Text == "Отклонена")
                    {
                        provider.ResolveTroubleTicket(troubleTicket.Id, statusTroubleTicketComboBox.Text, resolveRichTextBox.Text, resolveUserId);
                    }
                    else if (statusTroubleTicketComboBox.Text == "Зарегистрирована" && lastStatus != "Зарегистрирована")
                    {
                        e.Cancel = true;
                        MessageBox.Show("Возврат в статус \"Зарегистрирована\" запрещён.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        provider.ChangeStatusTroubleTicket(troubleTicket.Id, statusTroubleTicketComboBox.Text, resolveUserId);
                    }
                }
            }
        }
    }
}
