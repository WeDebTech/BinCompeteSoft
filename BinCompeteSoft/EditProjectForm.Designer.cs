namespace BinCompeteSoft
{
    partial class EditProjectForm
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
            this.projectDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.projectDescriptionLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.projectNameText = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectDescriptionTextBox
            // 
            this.projectDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDescriptionTextBox.Location = new System.Drawing.Point(12, 81);
            this.projectDescriptionTextBox.Multiline = true;
            this.projectDescriptionTextBox.Name = "projectDescriptionTextBox";
            this.projectDescriptionTextBox.Size = new System.Drawing.Size(776, 313);
            this.projectDescriptionTextBox.TabIndex = 2;
            // 
            // projectDescriptionLabel
            // 
            this.projectDescriptionLabel.AutoSize = true;
            this.projectDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDescriptionLabel.Location = new System.Drawing.Point(12, 47);
            this.projectDescriptionLabel.Name = "projectDescriptionLabel";
            this.projectDescriptionLabel.Size = new System.Drawing.Size(238, 31);
            this.projectDescriptionLabel.TabIndex = 28;
            this.projectDescriptionLabel.Text = "Project description";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(12, 400);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(168, 38);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // projectNameText
            // 
            this.projectNameText.AutoSize = true;
            this.projectNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameText.Location = new System.Drawing.Point(12, 9);
            this.projectNameText.Name = "projectNameText";
            this.projectNameText.Size = new System.Drawing.Size(173, 31);
            this.projectNameText.TabIndex = 30;
            this.projectNameText.Text = "Project name";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameTextBox.Location = new System.Drawing.Point(191, 6);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(597, 38);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(620, 400);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(168, 38);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // EditProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.projectNameText);
            this.Controls.Add(this.projectDescriptionTextBox);
            this.Controls.Add(this.projectDescriptionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProjectForm";
            this.ShowIcon = false;
            this.Text = "Edit Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectDescriptionTextBox;
        private System.Windows.Forms.Label projectDescriptionLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label projectNameText;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Button acceptButton;
    }
}