namespace BinCompeteSoft
{
    partial class MainJudgeDashboardForm
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
            this.softwareNameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.createContestButton = new System.Windows.Forms.Button();
            this.contestDataGridView = new System.Windows.Forms.DataGridView();
            this.filterContestButton = new System.Windows.Forms.Button();
            this.openContestButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contestDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // softwareNameLabel
            // 
            this.softwareNameLabel.AutoSize = true;
            this.softwareNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softwareNameLabel.Location = new System.Drawing.Point(115, 19);
            this.softwareNameLabel.Name = "softwareNameLabel";
            this.softwareNameLabel.Size = new System.Drawing.Size(155, 25);
            this.softwareNameLabel.TabIndex = 0;
            this.softwareNameLabel.Text = "BinCompeteSoft";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(276, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(529, 25);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Welcome username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // separatorLabel
            // 
            this.separatorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Location = new System.Drawing.Point(0, 55);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(1000, 2);
            this.separatorLabel.TabIndex = 2;
            // 
            // createContestButton
            // 
            this.createContestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createContestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createContestButton.Location = new System.Drawing.Point(12, 400);
            this.createContestButton.Name = "createContestButton";
            this.createContestButton.Size = new System.Drawing.Size(191, 38);
            this.createContestButton.TabIndex = 3;
            this.createContestButton.Text = "Create new contest";
            this.createContestButton.UseVisualStyleBackColor = true;
            this.createContestButton.Click += new System.EventHandler(this.createContestButton_Click);
            // 
            // contestDataGridView
            // 
            this.contestDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contestDataGridView.Location = new System.Drawing.Point(12, 104);
            this.contestDataGridView.Name = "contestDataGridView";
            this.contestDataGridView.Size = new System.Drawing.Size(976, 290);
            this.contestDataGridView.TabIndex = 4;
            // 
            // filterContestButton
            // 
            this.filterContestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterContestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterContestButton.Location = new System.Drawing.Point(820, 60);
            this.filterContestButton.Name = "filterContestButton";
            this.filterContestButton.Size = new System.Drawing.Size(168, 38);
            this.filterContestButton.TabIndex = 5;
            this.filterContestButton.Text = "Filter Contests";
            this.filterContestButton.UseVisualStyleBackColor = true;
            this.filterContestButton.Click += new System.EventHandler(this.filterContestButton_Click);
            // 
            // openContestButton
            // 
            this.openContestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openContestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openContestButton.Location = new System.Drawing.Point(820, 400);
            this.openContestButton.Name = "openContestButton";
            this.openContestButton.Size = new System.Drawing.Size(168, 38);
            this.openContestButton.TabIndex = 6;
            this.openContestButton.Text = "Open Contest";
            this.openContestButton.UseVisualStyleBackColor = true;
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(820, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 38);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(12, 60);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(168, 38);
            this.refreshButton.TabIndex = 8;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // MainJudgeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.openContestButton);
            this.Controls.Add(this.filterContestButton);
            this.Controls.Add(this.contestDataGridView);
            this.Controls.Add(this.createContestButton);
            this.Controls.Add(this.separatorLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.softwareNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainJudgeDashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.MainJudgeDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contestDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label softwareNameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Button createContestButton;
        private System.Windows.Forms.DataGridView contestDataGridView;
        private System.Windows.Forms.Button filterContestButton;
        private System.Windows.Forms.Button openContestButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button refreshButton;
    }
}