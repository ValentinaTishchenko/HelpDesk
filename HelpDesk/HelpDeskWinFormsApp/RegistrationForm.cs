
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
            var nameValidation = InputValidator.ValidateName(nameTextBox.Text);
            if (!nameValidation.IsValid)
            {
                MessageBox.Show(nameValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return false;
            }

            var loginValidation = InputValidator.ValidateLogin(loginTextBox.Text);
            if (!loginValidation.IsValid)
            {
                MessageBox.Show(loginValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginTextBox.Focus();
                return false;
            }

            var passwordValidation = InputValidator.ValidatePassword(passwordTextBox.Text);
            if (!passwordValidation.IsValid)
            {
                MessageBox.Show(passwordValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                return false;
            }

            var matchValidation = InputValidator.ValidatePasswordMatch(
                passwordTextBox.Text, replyPasswordTextBox.Text);

            if (!matchValidation.IsValid)
            {
                MessageBox.Show(matchValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                replyPasswordTextBox.Focus();
                return false;
            }

            var emailValidation = InputValidator.ValidateEmail(emailTextBox.Text);
            if (!emailValidation.IsValid)
            {
                MessageBox.Show(emailValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTextBox.Focus();
                return false;
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
