using System;
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Models;
using HelpDeskWinFormsApp.Costants;

namespace HelpDeskWinFormsApp
{
    public partial class EditUserForm : Form
    {
        private int userId;
        private User user;
        private readonly IProvider provider;

        public EditUserForm(int userId, IProvider provider)
        {
            InitializeComponent();
            this.userId = userId;
            this.provider = provider;
        }

        private void EditUserForm_Shown(object sender, EventArgs e)
        {
            user = provider.GetUser(userId);

            if (user.IsEmployee)
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;

                userTypeComboBox.Text = UserInterfaceTexts.UserTypeEmployee;
                deparmentComboBox.Text = user.Department;
                functionComboBox.Text = user.Function;
            }
            else
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;

                userTypeComboBox.Text = UserInterfaceTexts.UserTypeClient;
            }

            nameTextBox.Text = user.Name;
            loginTextBox.Text = user.Login;
            emailTextBox.Text = user.Email;
        }

       
        private void UserTypeComboBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (userTypeComboBox.Text == UserInterfaceTexts.UserTypeEmployee)
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;
            }
            else if (userTypeComboBox.Text == UserInterfaceTexts.UserTypeClient)
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;
            }
        }

        private void EditUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;

            if (!ValidateAllFields())
            {
                e.Cancel = true;
                return;
            }

            user.Name = nameTextBox.Text;
            user.Login = loginTextBox.Text;

            if (changePasswordTextBox.Text != string.Empty)
            {
                user.Password = Methods.GetHashMD5(changePasswordTextBox.Text);
            }

            user.Email = emailTextBox.Text;

            if (user.IsEmployee)
            {
                user.Function = functionComboBox.Text;
                user.Department = deparmentComboBox.Text;
            }

            if (userTypeComboBox.Text == UserInterfaceTexts.UserTypeEmployee && !user.IsEmployee)
            {
                provider.ChangeUserToEmployee(user, functionComboBox.Text, deparmentComboBox.Text);
            }
            else if (userTypeComboBox.Text == UserInterfaceTexts.UserTypeClient && user.IsEmployee)
            {
                provider.ChangeEmployeeToUser(user);
            }
            else
            {
                provider.UpdateUser(user);
            }
        }

        private void DeparmentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (deparmentComboBox.Text == Departments.TechnicalSupport)
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add(Functions.Operator);
                functionComboBox.Items.Add(Functions.TechnicalSpecialist);
                functionComboBox.Text = Functions.Operator;
            }
            else if (deparmentComboBox.Text == Departments.Development)
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add(Functions.Tester);
                functionComboBox.Items.Add(Functions.Developer);
                functionComboBox.Text = Functions.Tester;
            }
        }

        private bool ValidateAllFields()
        {
            var nameValidation = InputValidator.ValidateName(nameTextBox.Text);
            if (!nameValidation.IsValid)
            {
                MessageBox.Show(nameValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var loginValidation = InputValidator.ValidateLogin(loginTextBox.Text);
            if (!loginValidation.IsValid)
            {
                MessageBox.Show(loginValidation.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!string.IsNullOrEmpty(changePasswordTextBox.Text))
            {
                var passwordValidation = InputValidator.ValidatePassword(changePasswordTextBox.Text);
                if (!passwordValidation.IsValid)
                {
                    MessageBox.Show(passwordValidation.Message, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    changePasswordTextBox.Focus();
                    return false;
                }

                var matchValidation = InputValidator.ValidatePasswordMatch(
                    changePasswordTextBox.Text,
                    confurmChangePasswordTextBox.Text);
                if (!matchValidation.IsValid)
                {
                    MessageBox.Show(matchValidation.Message, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confurmChangePasswordTextBox.Focus();
                    return false;
                }
            }            

            return true;
        }
        private void SaveButton_Click(object sender, EventArgs e)
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
