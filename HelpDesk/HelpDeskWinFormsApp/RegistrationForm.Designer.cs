namespace HelpDeskWinFormsApp
{
    partial class RegistrationForm
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
            passwordLabel = new System.Windows.Forms.Label();
            passwordTextBox = new System.Windows.Forms.TextBox();
            emailLabel = new System.Windows.Forms.Label();
            emailTextBox = new System.Windows.Forms.TextBox();
            registrationButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            exitButton = new System.Windows.Forms.Button();
            replyPasswordLabel = new System.Windows.Forms.Label();
            replyPasswordTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nameLabel.Location = new System.Drawing.Point(14, 7);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(319, 40);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "&Имя";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(14, 51);
            nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(318, 27);
            nameTextBox.TabIndex = 1;
            // 
            // loginLabel
            // 
            loginLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loginLabel.Location = new System.Drawing.Point(14, 85);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(319, 40);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "&Логин";
            loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new System.Drawing.Point(14, 129);
            loginTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new System.Drawing.Size(318, 27);
            loginTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            passwordLabel.Location = new System.Drawing.Point(14, 164);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(319, 40);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "&Пароль";
            passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new System.Drawing.Point(14, 208);
            passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(318, 27);
            passwordTextBox.TabIndex = 5;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // emailLabel
            // 
            emailLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            emailLabel.Location = new System.Drawing.Point(14, 321);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(319, 40);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "&E-Mail";
            emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(14, 365);
            emailTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(318, 27);
            emailTextBox.TabIndex = 9;
            // 
            // registrationButton
            // 
            registrationButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            registrationButton.Location = new System.Drawing.Point(14, 421);
            registrationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new System.Drawing.Size(319, 44);
            registrationButton.TabIndex = 10;
            registrationButton.Text = "&Регистрация";
            registrationButton.UseVisualStyleBackColor = true;
            registrationButton.Click += RegistrationButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(14, 473);
            cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(319, 44);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "&Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            exitButton.Location = new System.Drawing.Point(14, 525);
            exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(319, 44);
            exitButton.TabIndex = 12;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // replyPasswordLabel
            // 
            replyPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            replyPasswordLabel.Location = new System.Drawing.Point(14, 243);
            replyPasswordLabel.Name = "replyPasswordLabel";
            replyPasswordLabel.Size = new System.Drawing.Size(319, 40);
            replyPasswordLabel.TabIndex = 6;
            replyPasswordLabel.Text = "Повторите пароль";
            replyPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // replyPasswordTextBox
            // 
            replyPasswordTextBox.Location = new System.Drawing.Point(14, 287);
            replyPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            replyPasswordTextBox.Name = "replyPasswordTextBox";
            replyPasswordTextBox.Size = new System.Drawing.Size(318, 27);
            replyPasswordTextBox.TabIndex = 7;
            replyPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // RegistrationForm
            // 
            AcceptButton = registrationButton;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(346, 583);
            ControlBox = false;
            Controls.Add(replyPasswordTextBox);
            Controls.Add(replyPasswordLabel);
            Controls.Add(exitButton);
            Controls.Add(cancelButton);
            Controls.Add(registrationButton);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(loginTextBox);
            Controls.Add(loginLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrationForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "HelpDesk Регистрация";
            FormClosing += RegistrationForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button exitButton;
        public System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label replyPasswordLabel;
        private System.Windows.Forms.TextBox replyPasswordTextBox;
    }
}