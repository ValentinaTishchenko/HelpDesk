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
            nameLabel = new System.Windows.Forms.Label();
            nameTextBox = new System.Windows.Forms.TextBox();
            loginLabel = new System.Windows.Forms.Label();
            loginTextBox = new System.Windows.Forms.TextBox();
            changePasswordLabel = new System.Windows.Forms.Label();
            changePasswordTextBox = new System.Windows.Forms.TextBox();
            confurmChangePasswordLabel = new System.Windows.Forms.Label();
            confurmChangePasswordTextBox = new System.Windows.Forms.TextBox();
            emailLabel = new System.Windows.Forms.Label();
            emailTextBox = new System.Windows.Forms.TextBox();
            userTypeLabel = new System.Windows.Forms.Label();
            userTypeComboBox = new System.Windows.Forms.ComboBox();
            functionLabel = new System.Windows.Forms.Label();
            deparmentLabel = new System.Windows.Forms.Label();
            saveButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            functionComboBox = new System.Windows.Forms.ComboBox();
            deparmentComboBox = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nameLabel.Location = new System.Drawing.Point(14, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(319, 40);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(14, 56);
            nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(318, 27);
            nameTextBox.TabIndex = 1;
            // 
            // loginLabel
            // 
            loginLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loginLabel.Location = new System.Drawing.Point(14, 91);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(319, 40);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "Логин";
            loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new System.Drawing.Point(14, 135);
            loginTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new System.Drawing.Size(318, 27);
            loginTextBox.TabIndex = 3;
            // 
            // changePasswordLabel
            // 
            changePasswordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            changePasswordLabel.Location = new System.Drawing.Point(14, 169);
            changePasswordLabel.Name = "changePasswordLabel";
            changePasswordLabel.Size = new System.Drawing.Size(319, 40);
            changePasswordLabel.TabIndex = 4;
            changePasswordLabel.Text = "Изменение пароля";
            changePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // changePasswordTextBox
            // 
            changePasswordTextBox.Location = new System.Drawing.Point(14, 213);
            changePasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            changePasswordTextBox.Name = "changePasswordTextBox";
            changePasswordTextBox.Size = new System.Drawing.Size(318, 27);
            changePasswordTextBox.TabIndex = 5;
            changePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confurmChangePasswordLabel
            // 
            confurmChangePasswordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            confurmChangePasswordLabel.Location = new System.Drawing.Point(14, 248);
            confurmChangePasswordLabel.Name = "confurmChangePasswordLabel";
            confurmChangePasswordLabel.Size = new System.Drawing.Size(319, 40);
            confurmChangePasswordLabel.TabIndex = 6;
            confurmChangePasswordLabel.Text = "Повтор пароля";
            confurmChangePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confurmChangePasswordTextBox
            // 
            confurmChangePasswordTextBox.Location = new System.Drawing.Point(14, 292);
            confurmChangePasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            confurmChangePasswordTextBox.Name = "confurmChangePasswordTextBox";
            confurmChangePasswordTextBox.Size = new System.Drawing.Size(318, 27);
            confurmChangePasswordTextBox.TabIndex = 7;
            confurmChangePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // emailLabel
            // 
            emailLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            emailLabel.Location = new System.Drawing.Point(14, 327);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(319, 40);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "E-Mail";
            emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(14, 371);
            emailTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(318, 27);
            emailTextBox.TabIndex = 9;
            // 
            // userTypeLabel
            // 
            userTypeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            userTypeLabel.Location = new System.Drawing.Point(14, 405);
            userTypeLabel.Name = "userTypeLabel";
            userTypeLabel.Size = new System.Drawing.Size(319, 40);
            userTypeLabel.TabIndex = 10;
            userTypeLabel.Text = "Тип пользователя";
            userTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userTypeComboBox
            // 
            userTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            userTypeComboBox.FormattingEnabled = true;
            userTypeComboBox.Items.AddRange(new object[] { "Клиент", "Сотрудник" });
            userTypeComboBox.Location = new System.Drawing.Point(14, 449);
            userTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            userTypeComboBox.Name = "userTypeComboBox";
            userTypeComboBox.Size = new System.Drawing.Size(318, 28);
            userTypeComboBox.TabIndex = 11;
            userTypeComboBox.SelectedValueChanged += UserTypeComboBox_SelectedValueChanged;
            // 
            // functionLabel
            // 
            functionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            functionLabel.Location = new System.Drawing.Point(14, 563);
            functionLabel.Name = "functionLabel";
            functionLabel.Size = new System.Drawing.Size(319, 40);
            functionLabel.TabIndex = 14;
            functionLabel.Text = "Функция";
            functionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deparmentLabel
            // 
            deparmentLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            deparmentLabel.Location = new System.Drawing.Point(14, 484);
            deparmentLabel.Name = "deparmentLabel";
            deparmentLabel.Size = new System.Drawing.Size(319, 40);
            deparmentLabel.TabIndex = 12;
            deparmentLabel.Text = "Отдел";
            deparmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            saveButton.Location = new System.Drawing.Point(14, 663);
            saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(319, 44);
            saveButton.TabIndex = 16;
            saveButton.Text = "&Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(14, 715);
            cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(319, 44);
            cancelButton.TabIndex = 17;
            cancelButton.Text = "&Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // functionComboBox
            // 
            functionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            functionComboBox.FormattingEnabled = true;
            functionComboBox.Items.AddRange(new object[] { "Тестировщик", "Разработчик" });
            functionComboBox.Location = new System.Drawing.Point(14, 607);
            functionComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            functionComboBox.Name = "functionComboBox";
            functionComboBox.Size = new System.Drawing.Size(318, 28);
            functionComboBox.TabIndex = 15;
            // 
            // deparmentComboBox
            // 
            deparmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            deparmentComboBox.FormattingEnabled = true;
            deparmentComboBox.Items.AddRange(new object[] { "Техническая поддержка", "Разработка" });
            deparmentComboBox.Location = new System.Drawing.Point(14, 528);
            deparmentComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            deparmentComboBox.Name = "deparmentComboBox";
            deparmentComboBox.Size = new System.Drawing.Size(318, 28);
            deparmentComboBox.TabIndex = 13;
            deparmentComboBox.SelectedValueChanged += DeparmentComboBox_SelectedValueChanged;
            // 
            // EditUserForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(344, 772);
            ControlBox = false;
            Controls.Add(deparmentComboBox);
            Controls.Add(functionComboBox);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(deparmentLabel);
            Controls.Add(functionLabel);
            Controls.Add(userTypeComboBox);
            Controls.Add(userTypeLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(confurmChangePasswordTextBox);
            Controls.Add(confurmChangePasswordLabel);
            Controls.Add(changePasswordTextBox);
            Controls.Add(changePasswordLabel);
            Controls.Add(loginTextBox);
            Controls.Add(loginLabel);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "EditUserForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "HelpDesk Редактирование пользователя";
            FormClosing += EditUserForm_FormClosing;
            Shown += EditUserForm_Shown;
            ResumeLayout(false);
            PerformLayout();

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