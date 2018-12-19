namespace BinCompeteSoft
{
    partial class JudgeDashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.navigationGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listCompetitionsButton = new System.Windows.Forms.Button();
            this.addCompetitionButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.softwareNameLabel = new System.Windows.Forms.Label();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.categoryStatisticsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.notificationsExListBox = new BinCompeteSoft.exListBox();
            this.navigationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.notificationsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationGroupBox
            // 
            this.navigationGroupBox.Controls.Add(this.pictureBox1);
            this.navigationGroupBox.Controls.Add(this.listCompetitionsButton);
            this.navigationGroupBox.Controls.Add(this.addCompetitionButton);
            this.navigationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationGroupBox.Location = new System.Drawing.Point(12, 60);
            this.navigationGroupBox.Name = "navigationGroupBox";
            this.navigationGroupBox.Size = new System.Drawing.Size(200, 378);
            this.navigationGroupBox.TabIndex = 0;
            this.navigationGroupBox.TabStop = false;
            this.navigationGroupBox.Text = "Navigation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BinCompeteSoft.Properties.Resources.Logo_WeDeb;
            this.pictureBox1.Location = new System.Drawing.Point(6, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // listCompetitionsButton
            // 
            this.listCompetitionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listCompetitionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCompetitionsButton.Location = new System.Drawing.Point(6, 73);
            this.listCompetitionsButton.Name = "listCompetitionsButton";
            this.listCompetitionsButton.Size = new System.Drawing.Size(188, 38);
            this.listCompetitionsButton.TabIndex = 14;
            this.listCompetitionsButton.Text = "List competitions";
            this.listCompetitionsButton.UseVisualStyleBackColor = true;
            this.listCompetitionsButton.Click += new System.EventHandler(this.listCompetitionsButton_Click);
            // 
            // addCompetitionButton
            // 
            this.addCompetitionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCompetitionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCompetitionButton.Location = new System.Drawing.Point(6, 29);
            this.addCompetitionButton.Name = "addCompetitionButton";
            this.addCompetitionButton.Size = new System.Drawing.Size(188, 38);
            this.addCompetitionButton.TabIndex = 13;
            this.addCompetitionButton.Text = "Add competition";
            this.addCompetitionButton.UseVisualStyleBackColor = true;
            this.addCompetitionButton.Click += new System.EventHandler(this.addCompetitionButton_Click);
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
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(276, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(529, 25);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "Welcome username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // softwareNameLabel
            // 
            this.softwareNameLabel.AutoSize = true;
            this.softwareNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softwareNameLabel.Location = new System.Drawing.Point(115, 19);
            this.softwareNameLabel.Name = "softwareNameLabel";
            this.softwareNameLabel.Size = new System.Drawing.Size(155, 25);
            this.softwareNameLabel.TabIndex = 8;
            this.softwareNameLabel.Text = "BinCompeteSoft";
            // 
            // notificationsGroupBox
            // 
            this.notificationsGroupBox.Controls.Add(this.notificationsExListBox);
            this.notificationsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsGroupBox.Location = new System.Drawing.Point(218, 60);
            this.notificationsGroupBox.Name = "notificationsGroupBox";
            this.notificationsGroupBox.Size = new System.Drawing.Size(250, 378);
            this.notificationsGroupBox.TabIndex = 15;
            this.notificationsGroupBox.TabStop = false;
            this.notificationsGroupBox.Text = "Notifications";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(474, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 378);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contests yet to happen";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(238, 299);
            this.dataGridView1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 38);
            this.button1.TabIndex = 15;
            this.button1.Text = "Contest details";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.categoryStatisticsChart);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(730, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 378);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // categoryStatisticsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.categoryStatisticsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.categoryStatisticsChart.Legends.Add(legend1);
            this.categoryStatisticsChart.Location = new System.Drawing.Point(6, 29);
            this.categoryStatisticsChart.Name = "categoryStatisticsChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "CategoryStatistics";
            this.categoryStatisticsChart.Series.Add(series1);
            this.categoryStatisticsChart.Size = new System.Drawing.Size(246, 113);
            this.categoryStatisticsChart.TabIndex = 0;
            this.categoryStatisticsChart.Text = "Projects by theme";
            // 
            // notificationsExListBox
            // 
            this.notificationsExListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.notificationsExListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsExListBox.FormattingEnabled = true;
            this.notificationsExListBox.ItemHeight = 60;
            this.notificationsExListBox.Location = new System.Drawing.Point(6, 29);
            this.notificationsExListBox.Name = "notificationsExListBox";
            this.notificationsExListBox.Size = new System.Drawing.Size(238, 304);
            this.notificationsExListBox.TabIndex = 16;
            // 
            // JudgeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.notificationsGroupBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.navigationGroupBox);
            this.Controls.Add(this.separatorLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.softwareNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JudgeDashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.JudgeDashboardForm_Load);
            this.navigationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.notificationsGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox navigationGroupBox;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label softwareNameLabel;
        private System.Windows.Forms.Button listCompetitionsButton;
        private System.Windows.Forms.Button addCompetitionButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox notificationsGroupBox;
        private exListBox notificationsExListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart categoryStatisticsChart;
    }
}