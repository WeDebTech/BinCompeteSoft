﻿namespace BinCompeteSoft
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
            this.createContestutton = new System.Windows.Forms.Button();
            this.contestDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.openContestButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
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
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(418, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(196, 25);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Bem vindo username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separatorLabel
            // 
            this.separatorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Location = new System.Drawing.Point(0, 55);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(800, 2);
            this.separatorLabel.TabIndex = 2;
            // 
            // createContestutton
            // 
            this.createContestutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createContestutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createContestutton.Location = new System.Drawing.Point(12, 400);
            this.createContestutton.Name = "createContestutton";
            this.createContestutton.Size = new System.Drawing.Size(191, 38);
            this.createContestutton.TabIndex = 3;
            this.createContestutton.Text = "Create new contest";
            this.createContestutton.UseVisualStyleBackColor = true;
            this.createContestutton.Click += new System.EventHandler(this.createContestutton_Click);
            // 
            // contestDataGridView
            // 
            this.contestDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contestDataGridView.Location = new System.Drawing.Point(12, 104);
            this.contestDataGridView.Name = "contestDataGridView";
            this.contestDataGridView.Size = new System.Drawing.Size(776, 290);
            this.contestDataGridView.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(620, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Filter Contests";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // openContestButton
            // 
            this.openContestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openContestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openContestButton.Location = new System.Drawing.Point(620, 400);
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
            this.logoutButton.Location = new System.Drawing.Point(620, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 38);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // MainJudgeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.openContestButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.contestDataGridView);
            this.Controls.Add(this.createContestutton);
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
        private System.Windows.Forms.Button createContestutton;
        private System.Windows.Forms.DataGridView contestDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button openContestButton;
        private System.Windows.Forms.Button logoutButton;
    }
}