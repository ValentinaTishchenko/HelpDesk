using System;
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Models;

namespace HelpDeskWinFormsApp
{
    public partial class AuthorizationForm : Form
    {
        public bool RegistrationChoice = false;
        private readonly IProvider provider;

        public AuthorizationForm(IProvider provider)
        {
            InitializeComponent();
            this.provider = provider;
        }


        private void AuthorizationForm_Shown(object sender, EventArgs e)
        {
            AddFirstEmployee();
            UnlockTextBox();
        }


        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            RegistrationChoice = true;
            cancelButton.PerformClick();
        }

        private void UnlockTextBox()
        {
            loginTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
            loginButton.Enabled = true;
            registrationButton.Enabled = true;
        }

        private void AddFirstEmployee()
        {
            var isEmptyUsers = provider.GetAllUsers();

            if (isEmptyUsers == null || isEmptyUsers.Count == 0)
            {
                var employee = new User
                {
                    Name = "startAdmin",
                    Login = "admin",
                    Password = Methods.GetHashMD5("admin"),
                    Email = "admin@admin.admin",
                    IsEmployee = true,
                    Department = "Разработка",
                    Function = "Разработчик"
                };

                provider.AddUser(employee);
            }
        }

        private bool ValidateAllFields()
        {
            var validations = new[]
            {
                InputValidator.ValidateLogin(loginTextBox.Text),
                InputValidator.ValidatePassword(passwordTextBox.Text)
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


        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }

            if (!ValidateAllFields())
            {
                e.Cancel = true;
                return;
            }

            if (!provider.IsCorrectLoginPassword(loginTextBox.Text, passwordTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
            {
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
