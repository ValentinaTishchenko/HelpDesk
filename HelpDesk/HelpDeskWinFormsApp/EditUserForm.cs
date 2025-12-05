using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Windows.Forms;

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

                userTypeComboBox.Text = AppConstants.UserTypeEmployee;
                deparmentComboBox.Text = user.Department;
                functionComboBox.Text = user.Function;
            }
            else
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;

                userTypeComboBox.Text = AppConstants.UserTypeClient;
            }

            nameTextBox.Text = user.Name;
            loginTextBox.Text = user.Login;
            emailTextBox.Text = user.Email;
        }

       
        private void UserTypeComboBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (userTypeComboBox.Text == AppConstants.UserTypeEmployee)
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;
            }
            else if (userTypeComboBox.Text == AppConstants.UserTypeClient)
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

            if (userTypeComboBox.Text == AppConstants.UserTypeEmployee && !user.IsEmployee)
            {
                provider.ChangeUserToEmployee(user, functionComboBox.Text, deparmentComboBox.Text);
            }
            else if (userTypeComboBox.Text == AppConstants.UserTypeClient && user.IsEmployee)
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
            if (deparmentComboBox.Text == AppConstants.DepartmentTechnicalSupport)
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add(AppConstants.FunctionOperator);
                functionComboBox.Items.Add(AppConstants.FunctionTechnicalSpecialist);
                functionComboBox.Text = AppConstants.FunctionOperator;
            }
            else if (deparmentComboBox.Text == AppConstants.DepartmentDevelopment)
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add(AppConstants.FunctionTester);
                functionComboBox.Items.Add(AppConstants.FunctionDeveloper);
                functionComboBox.Text = AppConstants.FunctionTester;
            }
        }

        private bool ValidateAllFields()
        {
            var validations = new[]
            {
                InputValidator.ValidateName(nameTextBox.Text),
                InputValidator.ValidateLogin(loginTextBox.Text),
                InputValidator.ValidateEmail(emailTextBox.Text)
            };
            
            if (!string.IsNullOrEmpty(changePasswordTextBox.Text))
            {
                var passwordValidation = InputValidator.ValidatePassword(changePasswordTextBox.Text);
                if (!passwordValidation.IsValid)
                {
                    MessageBox.Show(passwordValidation.Message, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var matchValidation = InputValidator.ValidatePasswordMatch(
                    changePasswordTextBox.Text,
                    confurmChangePasswordTextBox.Text);
                if (!matchValidation.IsValid)
                {
                    MessageBox.Show(matchValidation.Message, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

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
