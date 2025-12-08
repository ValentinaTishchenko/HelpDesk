using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Windows.Forms;
using HelpDesk.Common.Constants;

namespace HelpDeskWinFormsApp
{
    public partial class AddTroubleTicketForm : Form
    {
        private User user;
        private readonly ITroubleTicketProvider ticketProvider;
        private const int MinTroubleTextLength = 5;

        public AddTroubleTicketForm(User user, ITroubleTicketProvider ticketProvider)
        {
            InitializeComponent();

            this.ticketProvider = ticketProvider;
            this.user = user;
        }

        private void AddTroubleTicketForm_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Text = $"{user.Name} \\ {user.Login}";
        }

        private void AddTroubleTicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var troubelTicket = new TroubleTicket
                {
                    CreateUserId = user.Id,
                    Text = troubleRichTextBox.Text,
                    Status = TicketStatuses.Registered,
                    Created = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(4)
                };

                ticketProvider.AddTroubleTicket(troubelTicket);
            }
        }

        private void TroubleRichTextBox_TextChanged(object sender, EventArgs e)
        {
            createTroubleTicketButton.Enabled = troubleRichTextBox.Text.Length >= MinTroubleTextLength;
        }
    }
}
