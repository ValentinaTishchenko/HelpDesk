namespace HelpDeskWinFormsApp
{
    partial class TroubleTicketForm
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
            this.userCreateLabel = new System.Windows.Forms.Label();
            this.userCreateTextBox = new System.Windows.Forms.TextBox();
            this.troubleTicketRichLabel = new System.Windows.Forms.Label();
            this.troubleTicketRichTextBox = new System.Windows.Forms.RichTextBox();
            this.resolveRichLabel = new System.Windows.Forms.Label();
            this.resolveRichTextBox = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusTroubleTicketComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // userCreateLabel
            // 
            this.userCreateLabel.AutoSize = true;
            this.userCreateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userCreateLabel.Location = new System.Drawing.Point(12, 9);
            this.userCreateLabel.Name = "userCreateLabel";
            this.userCreateLabel.Size = new System.Drawing.Size(89, 19);
            this.userCreateLabel.TabIndex = 0;
            this.userCreateLabel.Text = "Кем создано";
            // 
            // userCreateTextBox
            // 
            this.userCreateTextBox.Location = new System.Drawing.Point(12, 31);
            this.userCreateTextBox.Name = "userCreateTextBox";
            this.userCreateTextBox.ReadOnly = true;
            this.userCreateTextBox.Size = new System.Drawing.Size(380, 23);
            this.userCreateTextBox.TabIndex = 1;
            // 
            // troubleTicketRichLabel
            // 
            this.troubleTicketRichLabel.AutoSize = true;
            this.troubleTicketRichLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.troubleTicketRichLabel.Location = new System.Drawing.Point(12, 57);
            this.troubleTicketRichLabel.Name = "troubleTicketRichLabel";
            this.troubleTicketRichLabel.Size = new System.Drawing.Size(119, 19);
            this.troubleTicketRichLabel.TabIndex = 2;
            this.troubleTicketRichLabel.Text = "Текст обращения";
            // 
            // troubleTicketRichTextBox
            // 
            this.troubleTicketRichTextBox.Location = new System.Drawing.Point(12, 79);
            this.troubleTicketRichTextBox.Name = "trubleTicketRichTextBox";
            this.troubleTicketRichTextBox.ReadOnly = true;
            this.troubleTicketRichTextBox.Size = new System.Drawing.Size(380, 244);
            this.troubleTicketRichTextBox.TabIndex = 3;
            this.troubleTicketRichTextBox.Text = "";
            // 
            // resolveRichLabel
            // 
            this.resolveRichLabel.AutoSize = true;
            this.resolveRichLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resolveRichLabel.Location = new System.Drawing.Point(12, 326);
            this.resolveRichLabel.Name = "resolveRichLabel";
            this.resolveRichLabel.Size = new System.Drawing.Size(65, 19);
            this.resolveRichLabel.TabIndex = 4;
            this.resolveRichLabel.Text = "Решение";
            // 
            // resolveRichTextBox
            // 
            this.resolveRichTextBox.Location = new System.Drawing.Point(12, 348);
            this.resolveRichTextBox.Name = "resolveRichTextBox";
            this.resolveRichTextBox.Size = new System.Drawing.Size(380, 165);
            this.resolveRichTextBox.TabIndex = 5;
            this.resolveRichTextBox.Text = "";
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(12, 582);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(380, 37);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "&Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 625);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(380, 37);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(12, 516);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 19);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Статус";
            // 
            // statusTroubleTicketComboBox
            // 
            this.statusTroubleTicketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusTroubleTicketComboBox.FormattingEnabled = true;
            this.statusTroubleTicketComboBox.Items.AddRange(new object[] {
            "Зарегистрирована",
            "В работе",
            "Выполнена",
            "Отклонена"});
            this.statusTroubleTicketComboBox.Location = new System.Drawing.Point(12, 538);
            this.statusTroubleTicketComboBox.Name = "statusTroubleTicketComboBox";
            this.statusTroubleTicketComboBox.Size = new System.Drawing.Size(380, 23);
            this.statusTroubleTicketComboBox.TabIndex = 9;
            // 
            // TroubleTicketForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(404, 673);
            this.ControlBox = false;
            this.Controls.Add(this.statusTroubleTicketComboBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resolveRichTextBox);
            this.Controls.Add(this.resolveRichLabel);
            this.Controls.Add(this.troubleTicketRichTextBox);
            this.Controls.Add(this.troubleTicketRichLabel);
            this.Controls.Add(this.userCreateTextBox);
            this.Controls.Add(this.userCreateLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TroubleTicketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TroubleTicketForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TroubleTicketForm_FormClosing);
            this.Shown += new System.EventHandler(this.TroubleTicketForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userCreateLabel;
        private System.Windows.Forms.TextBox userCreateTextBox;
        private System.Windows.Forms.Label troubleTicketRichLabel;
        private System.Windows.Forms.RichTextBox troubleTicketRichTextBox;
        private System.Windows.Forms.Label resolveRichLabel;
        private System.Windows.Forms.RichTextBox resolveRichTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusTroubleTicketComboBox;
    }
}