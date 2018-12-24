namespace BinCompeteSoft
{
    partial class ProjectForm
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
            this.projectCategoryLabel = new System.Windows.Forms.Label();
            this.projectCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.projectPromoterTextBox = new System.Windows.Forms.TextBox();
            this.projectPromoterText = new System.Windows.Forms.Label();
            this.promoterAgeLabel = new System.Windows.Forms.Label();
            this.projectPromoterAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.refreshCategoriesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectPromoterAgeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // projectDescriptionTextBox
            // 
            this.projectDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDescriptionTextBox.Location = new System.Drawing.Point(12, 125);
            this.projectDescriptionTextBox.Multiline = true;
            this.projectDescriptionTextBox.Name = "projectDescriptionTextBox";
            this.projectDescriptionTextBox.Size = new System.Drawing.Size(776, 229);
            this.projectDescriptionTextBox.TabIndex = 2;
            // 
            // projectDescriptionLabel
            // 
            this.projectDescriptionLabel.AutoSize = true;
            this.projectDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDescriptionLabel.Location = new System.Drawing.Point(12, 91);
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
            this.projectNameTextBox.Location = new System.Drawing.Point(232, 6);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(556, 38);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(603, 400);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(185, 38);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // projectCategoryLabel
            // 
            this.projectCategoryLabel.AutoSize = true;
            this.projectCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectCategoryLabel.Location = new System.Drawing.Point(12, 357);
            this.projectCategoryLabel.Name = "projectCategoryLabel";
            this.projectCategoryLabel.Size = new System.Drawing.Size(211, 31);
            this.projectCategoryLabel.TabIndex = 31;
            this.projectCategoryLabel.Text = "Project category";
            // 
            // projectCategoryComboBox
            // 
            this.projectCategoryComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectCategoryComboBox.FormattingEnabled = true;
            this.projectCategoryComboBox.Location = new System.Drawing.Point(229, 360);
            this.projectCategoryComboBox.Name = "projectCategoryComboBox";
            this.projectCategoryComboBox.Size = new System.Drawing.Size(368, 33);
            this.projectCategoryComboBox.TabIndex = 32;
            // 
            // projectPromoterTextBox
            // 
            this.projectPromoterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectPromoterTextBox.Location = new System.Drawing.Point(232, 50);
            this.projectPromoterTextBox.Name = "projectPromoterTextBox";
            this.projectPromoterTextBox.Size = new System.Drawing.Size(556, 38);
            this.projectPromoterTextBox.TabIndex = 33;
            // 
            // projectPromoterText
            // 
            this.projectPromoterText.AutoSize = true;
            this.projectPromoterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectPromoterText.Location = new System.Drawing.Point(12, 53);
            this.projectPromoterText.Name = "projectPromoterText";
            this.projectPromoterText.Size = new System.Drawing.Size(214, 31);
            this.projectPromoterText.TabIndex = 34;
            this.projectPromoterText.Text = "Project promoter";
            // 
            // promoterAgeLabel
            // 
            this.promoterAgeLabel.AutoSize = true;
            this.promoterAgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promoterAgeLabel.Location = new System.Drawing.Point(531, 91);
            this.promoterAgeLabel.Name = "promoterAgeLabel";
            this.promoterAgeLabel.Size = new System.Drawing.Size(177, 31);
            this.promoterAgeLabel.TabIndex = 35;
            this.promoterAgeLabel.Text = "Promoter age";
            // 
            // projectPromoterAgeNumericUpDown
            // 
            this.projectPromoterAgeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectPromoterAgeNumericUpDown.Location = new System.Drawing.Point(714, 92);
            this.projectPromoterAgeNumericUpDown.Name = "projectPromoterAgeNumericUpDown";
            this.projectPromoterAgeNumericUpDown.Size = new System.Drawing.Size(74, 30);
            this.projectPromoterAgeNumericUpDown.TabIndex = 36;
            // 
            // refreshCategoriesButton
            // 
            this.refreshCategoriesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshCategoriesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshCategoriesButton.Location = new System.Drawing.Point(603, 357);
            this.refreshCategoriesButton.Name = "refreshCategoriesButton";
            this.refreshCategoriesButton.Size = new System.Drawing.Size(185, 38);
            this.refreshCategoriesButton.TabIndex = 37;
            this.refreshCategoriesButton.Text = "Refresh categories";
            this.refreshCategoriesButton.UseVisualStyleBackColor = true;
            this.refreshCategoriesButton.Click += new System.EventHandler(this.refreshCategoriesButton_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshCategoriesButton);
            this.Controls.Add(this.projectPromoterAgeNumericUpDown);
            this.Controls.Add(this.promoterAgeLabel);
            this.Controls.Add(this.projectPromoterTextBox);
            this.Controls.Add(this.projectPromoterText);
            this.Controls.Add(this.projectCategoryComboBox);
            this.Controls.Add(this.projectCategoryLabel);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.projectNameText);
            this.Controls.Add(this.projectDescriptionTextBox);
            this.Controls.Add(this.projectDescriptionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Project";
            this.Load += new System.EventHandler(this.EditProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectPromoterAgeNumericUpDown)).EndInit();
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
        private System.Windows.Forms.Label projectCategoryLabel;
        private System.Windows.Forms.ComboBox projectCategoryComboBox;
        private System.Windows.Forms.TextBox projectPromoterTextBox;
        private System.Windows.Forms.Label projectPromoterText;
        private System.Windows.Forms.Label promoterAgeLabel;
        private System.Windows.Forms.NumericUpDown projectPromoterAgeNumericUpDown;
        private System.Windows.Forms.Button refreshCategoriesButton;
    }
}