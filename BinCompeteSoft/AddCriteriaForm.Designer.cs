namespace BinCompeteSoft
{
    partial class AddCriteriaForm
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
            this.criteriaValueLabel = new System.Windows.Forms.Label();
            this.criteriaValueTrackBar = new System.Windows.Forms.TrackBar();
            this.criteriaActualValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaValueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // criteriaNameTextBox
            // 
            this.criteriaNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaNameTextBox.Location = new System.Drawing.Point(191, 9);
            this.criteriaNameTextBox.Name = "criteriaNameTextBox";
            this.criteriaNameTextBox.Size = new System.Drawing.Size(597, 38);
            this.criteriaNameTextBox.TabIndex = 31;
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
            this.criteriaDescriptionTextBox.Location = new System.Drawing.Point(12, 146);
            this.criteriaDescriptionTextBox.Multiline = true;
            this.criteriaDescriptionTextBox.Name = "criteriaDescriptionTextBox";
            this.criteriaDescriptionTextBox.Size = new System.Drawing.Size(776, 251);
            this.criteriaDescriptionTextBox.TabIndex = 32;
            // 
            // criteriaDescriptionLabel
            // 
            this.criteriaDescriptionLabel.AutoSize = true;
            this.criteriaDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaDescriptionLabel.Location = new System.Drawing.Point(12, 101);
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
            this.cancelButton.TabIndex = 34;
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
            this.acceptButton.TabIndex = 33;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // criteriaValueLabel
            // 
            this.criteriaValueLabel.AutoSize = true;
            this.criteriaValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaValueLabel.Location = new System.Drawing.Point(11, 59);
            this.criteriaValueLabel.Name = "criteriaValueLabel";
            this.criteriaValueLabel.Size = new System.Drawing.Size(174, 31);
            this.criteriaValueLabel.TabIndex = 37;
            this.criteriaValueLabel.Text = "Criteria value";
            // 
            // criteriaValueTrackBar
            // 
            this.criteriaValueTrackBar.Location = new System.Drawing.Point(226, 53);
            this.criteriaValueTrackBar.Maximum = 9;
            this.criteriaValueTrackBar.Minimum = 1;
            this.criteriaValueTrackBar.Name = "criteriaValueTrackBar";
            this.criteriaValueTrackBar.Size = new System.Drawing.Size(562, 45);
            this.criteriaValueTrackBar.TabIndex = 38;
            this.criteriaValueTrackBar.Value = 1;
            this.criteriaValueTrackBar.ValueChanged += new System.EventHandler(this.criteriaValueTrackBar_ValueChanged);
            // 
            // criteriaActualValueLabel
            // 
            this.criteriaActualValueLabel.AutoSize = true;
            this.criteriaActualValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaActualValueLabel.Location = new System.Drawing.Point(191, 59);
            this.criteriaActualValueLabel.Name = "criteriaActualValueLabel";
            this.criteriaActualValueLabel.Size = new System.Drawing.Size(29, 31);
            this.criteriaActualValueLabel.TabIndex = 39;
            this.criteriaActualValueLabel.Text = "1";
            // 
            // AddCriteriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.criteriaActualValueLabel);
            this.Controls.Add(this.criteriaValueTrackBar);
            this.Controls.Add(this.criteriaValueLabel);
            this.Controls.Add(this.criteriaNameTextBox);
            this.Controls.Add(this.criteriaNameText);
            this.Controls.Add(this.criteriaDescriptionTextBox);
            this.Controls.Add(this.criteriaDescriptionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddCriteriaForm";
            this.Text = "Add Criteria";
            ((System.ComponentModel.ISupportInitialize)(this.criteriaValueTrackBar)).EndInit();
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
        private System.Windows.Forms.Label criteriaValueLabel;
        private System.Windows.Forms.TrackBar criteriaValueTrackBar;
        private System.Windows.Forms.Label criteriaActualValueLabel;
    }
}