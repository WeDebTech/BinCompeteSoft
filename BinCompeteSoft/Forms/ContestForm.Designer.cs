namespace BinCompeteSoft
{
    partial class ContestForm
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
            this.contestNameLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.softwareNameLabel = new System.Windows.Forms.Label();
            this.contestNameTextBox = new System.Windows.Forms.TextBox();
            this.limitDateLabel = new System.Windows.Forms.Label();
            this.contestLimitDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.judgesDataGridView = new System.Windows.Forms.DataGridView();
            this.projectsDataGridView = new System.Windows.Forms.DataGridView();
            this.addJudgeButton = new System.Windows.Forms.Button();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.addDescriptionButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.criteriaDataGridView = new System.Windows.Forms.DataGridView();
            this.addCriteriaButton = new System.Windows.Forms.Button();
            this.contestStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.criteriaValuesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.judgesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contestNameLabel
            // 
            this.contestNameLabel.AutoSize = true;
            this.contestNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestNameLabel.Location = new System.Drawing.Point(6, 68);
            this.contestNameLabel.Name = "contestNameLabel";
            this.contestNameLabel.Size = new System.Drawing.Size(183, 31);
            this.contestNameLabel.TabIndex = 0;
            this.contestNameLabel.Text = "Contest name";
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(820, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 38);
            this.logoutButton.TabIndex = 11;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // separatorLabel
            // 
            this.separatorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Location = new System.Drawing.Point(0, 55);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(1000, 2);
            this.separatorLabel.TabIndex = 10;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(627, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(187, 25);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "Welcome username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // softwareNameLabel
            // 
            this.softwareNameLabel.AutoSize = true;
            this.softwareNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softwareNameLabel.Location = new System.Drawing.Point(120, 19);
            this.softwareNameLabel.Name = "softwareNameLabel";
            this.softwareNameLabel.Size = new System.Drawing.Size(155, 25);
            this.softwareNameLabel.TabIndex = 8;
            this.softwareNameLabel.Text = "BinCompeteSoft";
            // 
            // contestNameTextBox
            // 
            this.contestNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestNameTextBox.Location = new System.Drawing.Point(195, 65);
            this.contestNameTextBox.Name = "contestNameTextBox";
            this.contestNameTextBox.Size = new System.Drawing.Size(793, 38);
            this.contestNameTextBox.TabIndex = 12;
            // 
            // limitDateLabel
            // 
            this.limitDateLabel.AutoSize = true;
            this.limitDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitDateLabel.Location = new System.Drawing.Point(339, 108);
            this.limitDateLabel.Name = "limitDateLabel";
            this.limitDateLabel.Size = new System.Drawing.Size(131, 31);
            this.limitDateLabel.TabIndex = 13;
            this.limitDateLabel.Text = "Limit date";
            // 
            // contestLimitDateTimePicker
            // 
            this.contestLimitDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestLimitDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.contestLimitDateTimePicker.Location = new System.Drawing.Point(476, 109);
            this.contestLimitDateTimePicker.Name = "contestLimitDateTimePicker";
            this.contestLimitDateTimePicker.Size = new System.Drawing.Size(184, 30);
            this.contestLimitDateTimePicker.TabIndex = 16;
            // 
            // judgesDataGridView
            // 
            this.judgesDataGridView.AllowUserToAddRows = false;
            this.judgesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.judgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.judgesDataGridView.Location = new System.Drawing.Point(12, 196);
            this.judgesDataGridView.Name = "judgesDataGridView";
            this.judgesDataGridView.ReadOnly = true;
            this.judgesDataGridView.Size = new System.Drawing.Size(320, 198);
            this.judgesDataGridView.TabIndex = 17;
            this.judgesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.judgesDataGridView_CellContentClick);
            // 
            // projectsDataGridView
            // 
            this.projectsDataGridView.AllowUserToAddRows = false;
            this.projectsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsDataGridView.Location = new System.Drawing.Point(340, 196);
            this.projectsDataGridView.Name = "projectsDataGridView";
            this.projectsDataGridView.ReadOnly = true;
            this.projectsDataGridView.Size = new System.Drawing.Size(320, 198);
            this.projectsDataGridView.TabIndex = 18;
            this.projectsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectsDataGridView_CellContentClick);
            // 
            // addJudgeButton
            // 
            this.addJudgeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addJudgeButton.Location = new System.Drawing.Point(12, 152);
            this.addJudgeButton.Name = "addJudgeButton";
            this.addJudgeButton.Size = new System.Drawing.Size(320, 38);
            this.addJudgeButton.TabIndex = 19;
            this.addJudgeButton.Text = "Add judge";
            this.addJudgeButton.UseVisualStyleBackColor = true;
            this.addJudgeButton.Click += new System.EventHandler(this.addJudgeButton_Click);
            // 
            // addProjectButton
            // 
            this.addProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProjectButton.Location = new System.Drawing.Point(340, 152);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(320, 38);
            this.addProjectButton.TabIndex = 20;
            this.addProjectButton.Text = "Add project";
            this.addProjectButton.UseVisualStyleBackColor = true;
            this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
            // 
            // addDescriptionButton
            // 
            this.addDescriptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addDescriptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDescriptionButton.Location = new System.Drawing.Point(668, 107);
            this.addDescriptionButton.Name = "addDescriptionButton";
            this.addDescriptionButton.Size = new System.Drawing.Size(320, 38);
            this.addDescriptionButton.TabIndex = 21;
            this.addDescriptionButton.Text = "Add description";
            this.addDescriptionButton.UseVisualStyleBackColor = true;
            this.addDescriptionButton.Click += new System.EventHandler(this.addDescriptionButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(17, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(97, 38);
            this.backButton.TabIndex = 22;
            this.backButton.Text = "Go back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // criteriaDataGridView
            // 
            this.criteriaDataGridView.AllowUserToAddRows = false;
            this.criteriaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.criteriaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criteriaDataGridView.Location = new System.Drawing.Point(668, 196);
            this.criteriaDataGridView.Name = "criteriaDataGridView";
            this.criteriaDataGridView.ReadOnly = true;
            this.criteriaDataGridView.Size = new System.Drawing.Size(320, 198);
            this.criteriaDataGridView.TabIndex = 26;
            this.criteriaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.criteriaDataGridView_CellContentClick);
            // 
            // addCriteriaButton
            // 
            this.addCriteriaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCriteriaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCriteriaButton.Location = new System.Drawing.Point(668, 152);
            this.addCriteriaButton.Name = "addCriteriaButton";
            this.addCriteriaButton.Size = new System.Drawing.Size(320, 38);
            this.addCriteriaButton.TabIndex = 27;
            this.addCriteriaButton.Text = "Add criteria";
            this.addCriteriaButton.UseVisualStyleBackColor = true;
            this.addCriteriaButton.Click += new System.EventHandler(this.addCriteriaButton_Click);
            // 
            // contestStartDateTimePicker
            // 
            this.contestStartDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.contestStartDateTimePicker.Location = new System.Drawing.Point(150, 109);
            this.contestStartDateTimePicker.Name = "contestStartDateTimePicker";
            this.contestStartDateTimePicker.Size = new System.Drawing.Size(183, 30);
            this.contestStartDateTimePicker.TabIndex = 29;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLabel.Location = new System.Drawing.Point(12, 111);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(132, 31);
            this.startDateLabel.TabIndex = 28;
            this.startDateLabel.Text = "Start date";
            // 
            // criteriaValuesButton
            // 
            this.criteriaValuesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.criteriaValuesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaValuesButton.Location = new System.Drawing.Point(668, 400);
            this.criteriaValuesButton.Name = "criteriaValuesButton";
            this.criteriaValuesButton.Size = new System.Drawing.Size(320, 38);
            this.criteriaValuesButton.TabIndex = 30;
            this.criteriaValuesButton.Text = "Insert criteria values and finish";
            this.criteriaValuesButton.UseVisualStyleBackColor = true;
            this.criteriaValuesButton.Click += new System.EventHandler(this.criteriaValuesButton_Click);
            // 
            // ContestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.criteriaValuesButton);
            this.Controls.Add(this.contestStartDateTimePicker);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.addCriteriaButton);
            this.Controls.Add(this.criteriaDataGridView);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.addDescriptionButton);
            this.Controls.Add(this.addProjectButton);
            this.Controls.Add(this.addJudgeButton);
            this.Controls.Add(this.projectsDataGridView);
            this.Controls.Add(this.judgesDataGridView);
            this.Controls.Add(this.contestLimitDateTimePicker);
            this.Controls.Add(this.limitDateLabel);
            this.Controls.Add(this.contestNameTextBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.separatorLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.softwareNameLabel);
            this.Controls.Add(this.contestNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContestForm";
            this.Text = "Edit Contest";
            this.Load += new System.EventHandler(this.EditContestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.judgesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contestNameLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label softwareNameLabel;
        private System.Windows.Forms.TextBox contestNameTextBox;
        private System.Windows.Forms.Label limitDateLabel;
        private System.Windows.Forms.DateTimePicker contestLimitDateTimePicker;
        private System.Windows.Forms.DataGridView judgesDataGridView;
        private System.Windows.Forms.DataGridView projectsDataGridView;
        private System.Windows.Forms.Button addJudgeButton;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.Button addDescriptionButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridView criteriaDataGridView;
        private System.Windows.Forms.Button addCriteriaButton;
        private System.Windows.Forms.DateTimePicker contestStartDateTimePicker;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Button criteriaValuesButton;
    }
}