namespace BinCompeteSoft
{
    partial class CriteriaForm
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
            this.criteriaNameTextBox = new System.Windows.Forms.TextBox();
            this.criteriaNameText = new System.Windows.Forms.Label();
            this.criteriaDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.criteriaDescriptionLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // criteriaNameTextBox
            // 
            this.criteriaNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaNameTextBox.Location = new System.Drawing.Point(191, 9);
            this.criteriaNameTextBox.Name = "criteriaNameTextBox";
            this.criteriaNameTextBox.Size = new System.Drawing.Size(597, 38);
            this.criteriaNameTextBox.TabIndex = 0;
            // 
            // criteriaNameText
            // 
            this.criteriaNameText.AutoSize = true;
            this.criteriaNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaNameText.Location = new System.Drawing.Point(12, 12);
            this.criteriaNameText.Name = "criteriaNameText";
            this.criteriaNameText.Size = new System.Drawing.Size(176, 31);
            this.criteriaNameText.TabIndex = 36;
            this.criteriaNameText.Text = "Criteria name";
            // 
            // criteriaDescriptionTextBox
            // 
            this.criteriaDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaDescriptionTextBox.Location = new System.Drawing.Point(12, 84);
            this.criteriaDescriptionTextBox.Multiline = true;
            this.criteriaDescriptionTextBox.Name = "criteriaDescriptionTextBox";
            this.criteriaDescriptionTextBox.Size = new System.Drawing.Size(776, 313);
            this.criteriaDescriptionTextBox.TabIndex = 1;
            // 
            // criteriaDescriptionLabel
            // 
            this.criteriaDescriptionLabel.AutoSize = true;
            this.criteriaDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaDescriptionLabel.Location = new System.Drawing.Point(12, 50);
            this.criteriaDescriptionLabel.Name = "criteriaDescriptionLabel";
            this.criteriaDescriptionLabel.Size = new System.Drawing.Size(241, 31);
            this.criteriaDescriptionLabel.TabIndex = 35;
            this.criteriaDescriptionLabel.Text = "Criteria description";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(12, 403);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(168, 38);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(620, 403);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(168, 38);
            this.acceptButton.TabIndex = 2;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // CriteriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.criteriaNameTextBox);
            this.Controls.Add(this.criteriaNameText);
            this.Controls.Add(this.criteriaDescriptionTextBox);
            this.Controls.Add(this.criteriaDescriptionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CriteriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Criteria";
            this.Load += new System.EventHandler(this.CriteriaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox criteriaNameTextBox;
        private System.Windows.Forms.Label criteriaNameText;
        private System.Windows.Forms.TextBox criteriaDescriptionTextBox;
        private System.Windows.Forms.Label criteriaDescriptionLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
    }
}