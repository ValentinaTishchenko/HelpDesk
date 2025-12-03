using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    partial class AuthorizationForm
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
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginLabel = new Label();
            passwordLabel = new Label();
            loginButton = new Button();
            cancelButton = new Button();
            registrationButton = new Button();
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Enabled = false;
            loginTextBox.Location = new System.Drawing.Point(12, 75);
            loginTextBox.Name = "LoginTextBox";
            loginTextBox.Size = new System.Drawing.Size(279, 23);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Enabled = false;
            passwordTextBox.Location = new System.Drawing.Point(12, 139);
            passwordTextBox.Name = "PasswordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(279, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginLabel
            // 
            loginLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loginLabel.Location = new System.Drawing.Point(12, 42);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(279, 30);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "&Логин";
            loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordLabel
            // 
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            passwordLabel.Location = new System.Drawing.Point(12, 101);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(279, 35);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "&Пароль";
            passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButton
            // 
            loginButton.DialogResult = DialogResult.OK;
            loginButton.Enabled = false;
            loginButton.Location = new System.Drawing.Point(12, 202);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(279, 33);
            loginButton.TabIndex = 4;
            loginButton.Text = "&Вход";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(12, 280);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(279, 33);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "В&ыход";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // registrationButton
            // 
            registrationButton.Enabled = false;
            registrationButton.Location = new System.Drawing.Point(12, 241);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new System.Drawing.Size(279, 33);
            registrationButton.TabIndex = 6;
            registrationButton.Text = "&Регистрация";
            registrationButton.UseVisualStyleBackColor = true;
            registrationButton.Click += RegistrationButton_Click;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(303, 24);
            mainMenuStrip.TabIndex = 9;
            mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            fileToolStripMenuItem.Text = "&Файл";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem.Text = "&Выход";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // AuthorizationForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(303, 328);
            ControlBox = false;
            Controls.Add(registrationButton);
            Controls.Add(cancelButton);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = mainMenuStrip;
            Name = "AuthorizationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HelpDesk Авторизация";
            FormClosing += AuthorizationForm_FormClosing;
            Shown += AuthorizationForm_Shown;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label loginLabel;
        private Label passwordLabel;
        private Button loginButton;
        private Button cancelButton;
        public TextBox loginTextBox;
        public TextBox passwordTextBox;
        private Button registrationButton;
        private ContextMenuStrip contextMenuStrip;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}