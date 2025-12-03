namespace HelpDeskWinFormsApp
{
    partial class EditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.changePasswordLabel = new System.Windows.Forms.Label();
            this.changePasswordTextBox = new System.Windows.Forms.TextBox();
            this.confurmChangePasswordLabel = new System.Windows.Forms.Label();
            this.confurmChangePasswordTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.userTypeLabel = new System.Windows.Forms.Label();
            this.userTypeComboBox = new System.Windows.Forms.ComboBox();
            this.functionLabel = new System.Windows.Forms.Label();
            this.deparmentLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.deparmentComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(279, 30);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(279, 23);
            this.nameTextBox.TabIndex = 1;
            // 
            // loginLabel
            // 
            this.loginLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginLabel.Location = new System.Drawing.Point(12, 68);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(279, 30);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Логин";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(12, 101);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(279, 23);
            this.loginTextBox.TabIndex = 3;
            // 
            // changePasswordLabel
            // 
            this.changePasswordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.changePasswordLabel.Location = new System.Drawing.Point(12, 127);
            this.changePasswordLabel.Name = "changePasswordLabel";
            this.changePasswordLabel.Size = new System.Drawing.Size(279, 30);
            this.changePasswordLabel.TabIndex = 4;
            this.changePasswordLabel.Text = "Изменение пароля";
            this.changePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // changePasswordTextBox
            // 
            this.changePasswordTextBox.Location = new System.Drawing.Point(12, 160);
            this.changePasswordTextBox.Name = "changePasswordTextBox";
            this.changePasswordTextBox.Size = new System.Drawing.Size(279, 23);
            this.changePasswordTextBox.TabIndex = 5;
            this.changePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confurmChangePasswordLabel
            // 
            this.confurmChangePasswordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confurmChangePasswordLabel.Location = new System.Drawing.Point(12, 186);
            this.confurmChangePasswordLabel.Name = "confurmChangePasswordLabel";
            this.confurmChangePasswordLabel.Size = new System.Drawing.Size(279, 30);
            this.confurmChangePasswordLabel.TabIndex = 6;
            this.confurmChangePasswordLabel.Text = "Повтор пароля";
            this.confurmChangePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confurmChangePasswordTextBox
            // 
            this.confurmChangePasswordTextBox.Location = new System.Drawing.Point(12, 219);
            this.confurmChangePasswordTextBox.Name = "confurmChangePasswordTextBox";
            this.confurmChangePasswordTextBox.Size = new System.Drawing.Size(279, 23);
            this.confurmChangePasswordTextBox.TabIndex = 7;
            this.confurmChangePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // emailLabel
            // 
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailLabel.Location = new System.Drawing.Point(12, 245);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(279, 30);
            this.emailLabel.TabIndex = 8;
            this.emailLabel.Text = "E-Mail";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 278);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(279, 23);
            this.emailTextBox.TabIndex = 9;
            // 
            // userTypeLabel
            // 
            this.userTypeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userTypeLabel.Location = new System.Drawing.Point(12, 304);
            this.userTypeLabel.Name = "userTypeLabel";
            this.userTypeLabel.Size = new System.Drawing.Size(279, 30);
            this.userTypeLabel.TabIndex = 10;
            this.userTypeLabel.Text = "Тип пользователя";
            this.userTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userTypeComboBox
            // 
            this.userTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userTypeComboBox.FormattingEnabled = true;
            this.userTypeComboBox.Items.AddRange(new object[] {
            "Клиент",
            "Сотрудник"});
            this.userTypeComboBox.Location = new System.Drawing.Point(12, 337);
            this.userTypeComboBox.Name = "userTypeComboBox";
            this.userTypeComboBox.Size = new System.Drawing.Size(279, 23);
            this.userTypeComboBox.TabIndex = 11;
            this.userTypeComboBox.SelectedValueChanged += new System.EventHandler(this.UserTypeComboBox_SelectedValueChanged);
            // 
            // functionLabel
            // 
            this.functionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.functionLabel.Location = new System.Drawing.Point(12, 422);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(279, 30);
            this.functionLabel.TabIndex = 14;
            this.functionLabel.Text = "Функция";
            this.functionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deparmentLabel
            // 
            this.deparmentLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deparmentLabel.Location = new System.Drawing.Point(12, 363);
            this.deparmentLabel.Name = "deparmentLabel";
            this.deparmentLabel.Size = new System.Drawing.Size(279, 30);
            this.deparmentLabel.TabIndex = 12;
            this.deparmentLabel.Text = "Отдел";
            this.deparmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(12, 497);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(279, 33);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "&Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 536);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(279, 33);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "&Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // functionComboBox
            // 
            this.functionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionComboBox.FormattingEnabled = true;
            this.functionComboBox.Items.AddRange(new object[] {
            "Тестировщик",
            "Разработчик"});
            this.functionComboBox.Location = new System.Drawing.Point(12, 455);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(279, 23);
            this.functionComboBox.TabIndex = 15;
            // 
            // deparmentComboBox
            // 
            this.deparmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deparmentComboBox.FormattingEnabled = true;
            this.deparmentComboBox.Items.AddRange(new object[] {
            "Техническая поддержка",
            "Разработка"});
            this.deparmentComboBox.Location = new System.Drawing.Point(12, 396);
            this.deparmentComboBox.Name = "deparmentComboBox";
            this.deparmentComboBox.Size = new System.Drawing.Size(279, 23);
            this.deparmentComboBox.TabIndex = 13;
            this.deparmentComboBox.SelectedValueChanged += new System.EventHandler(this.DeparmentComboBox_SelectedValueChanged);
            // 
            // EditUserForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(301, 579);
            this.ControlBox = false;
            this.Controls.Add(this.deparmentComboBox);
            this.Controls.Add(this.functionComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deparmentLabel);
            this.Controls.Add(this.functionLabel);
            this.Controls.Add(this.userTypeComboBox);
            this.Controls.Add(this.userTypeLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.confurmChangePasswordTextBox);
            this.Controls.Add(this.confurmChangePasswordLabel);
            this.Controls.Add(this.changePasswordTextBox);
            this.Controls.Add(this.changePasswordLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelpDesk Редактирование пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditUserForm_FormClosing);
            this.Shown += new System.EventHandler(this.EditUserForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label changePasswordLabel;
        private System.Windows.Forms.TextBox changePasswordTextBox;
        private System.Windows.Forms.Label confurmChangePasswordLabel;
        private System.Windows.Forms.TextBox confurmChangePasswordTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label userTypeLabel;
        private System.Windows.Forms.ComboBox userTypeComboBox;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Label deparmentLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.ComboBox deparmentComboBox;
    }
}