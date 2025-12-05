
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Models;

namespace HelpDeskWinFormsApp
{
    public partial class RegistrationForm : Form
    {
        private readonly IProvider provider;

        public RegistrationForm(IProvider provider)
        {
            InitializeComponent();

            this.provider = provider;
        }

        private bool ValidateAllFields()
        {
            var validations = new[]
            {
                InputValidator.ValidateName(nameTextBox.Text),
                InputValidator.ValidateLogin(loginTextBox.Text),
                InputValidator.ValidatePassword(passwordTextBox.Text),
                InputValidator.ValidatePasswordMatch(passwordTextBox.Text, replyPasswordTextBox.Text),
                InputValidator.ValidateEmail(emailTextBox.Text)
            };

            foreach (var validation in validations)
            {
                if (!validation.IsValid)
                {
                    MessageBox.Show(validation.Message, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.Abort)
            {
                return;
            }
            if (!ValidateAllFields())
            {
                e.Cancel = true;
                return;
            }

            var user = new User
            {
                Name = nameTextBox.Text,
                Login = loginTextBox.Text,
                Password = Methods.GetHashMD5(passwordTextBox.Text),
                Email = emailTextBox.Text
            };

            provider.AddUser(user);
        }

        private void RegistrationButton_Click(object sender, System.EventArgs e)
        {
            if (!ValidateAllFields())
            {
                DialogResult = DialogResult.None;
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
