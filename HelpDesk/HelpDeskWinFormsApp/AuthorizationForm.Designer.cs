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
            loginTextBox.Location = new System.Drawing.Point(14, 100);
            loginTextBox.Margin = new Padding(3, 4, 3, 4);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new System.Drawing.Size(318, 27);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Enabled = false;
            passwordTextBox.Location = new System.Drawing.Point(14, 185);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(318, 27);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginLabel
            // 
            loginLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loginLabel.Location = new System.Drawing.Point(14, 56);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(319, 40);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "&Логин";
            loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordLabel
            // 
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            passwordLabel.Location = new System.Drawing.Point(14, 135);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(319, 47);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "&Пароль";
            passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButton
            // 
            loginButton.DialogResult = DialogResult.OK;
            loginButton.Enabled = false;
            loginButton.Location = new System.Drawing.Point(14, 269);
            loginButton.Margin = new Padding(3, 4, 3, 4);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(319, 44);
            loginButton.TabIndex = 4;
            loginButton.Text = "&Вход";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(14, 373);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(319, 44);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "В&ыход";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // registrationButton
            // 
            registrationButton.Enabled = false;
            registrationButton.Location = new System.Drawing.Point(14, 321);
            registrationButton.Margin = new Padding(3, 4, 3, 4);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new System.Drawing.Size(319, 44);
            registrationButton.TabIndex = 6;
            registrationButton.Text = "&Регистрация";
            registrationButton.UseVisualStyleBackColor = true;
            registrationButton.Click += RegistrationButton_Click;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(7, 3, 0, 3);
            mainMenuStrip.Size = new System.Drawing.Size(346, 30);
            mainMenuStrip.TabIndex = 9;
            mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            fileToolStripMenuItem.Text = "&Файл";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            exitToolStripMenuItem.Text = "&Выход";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // AuthorizationForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(346, 445);
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
            Margin = new Padding(3, 4, 3, 4);
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