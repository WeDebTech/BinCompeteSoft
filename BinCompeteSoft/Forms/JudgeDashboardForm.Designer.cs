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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.navigationGroupBox = new System.Windows.Forms.GroupBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.listCompetitionsButton = new System.Windows.Forms.Button();
            this.addCompetitionButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.softwareNameLabel = new System.Windows.Forms.Label();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.contestsGroupBox = new System.Windows.Forms.GroupBox();
            this.contestsDataGridView = new System.Windows.Forms.DataGridView();
            this.contestDetailsButton = new System.Windows.Forms.Button();
            this.statisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.categoryStatisticsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.categoriesStatisticsLabel = new System.Windows.Forms.Label();
            this.bestProjectsLabel = new System.Windows.Forms.Label();
            this.totalProjectsLabel = new System.Windows.Forms.Label();
            this.bestProjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.totalCompetitionsLabel = new System.Windows.Forms.Label();
            this.projectAvgLabel = new System.Windows.Forms.Label();
            this.projectAvgResultLabel = new System.Windows.Forms.Label();
            this.totalContestsResultLabel = new System.Windows.Forms.Label();
            this.totalProjectsResultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.previousYearButton = new System.Windows.Forms.Button();
            this.nextYearButton = new System.Windows.Forms.Button();
            this.notificationsExListBox = new BinCompeteSoft.exListBox();
            this.navigationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.notificationsGroupBox.SuspendLayout();
            this.contestsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contestsDataGridView)).BeginInit();
            this.statisticsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestProjectsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationGroupBox
            // 
            this.navigationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navigationGroupBox.Controls.Add(this.logoPictureBox);
            this.navigationGroupBox.Controls.Add(this.listCompetitionsButton);
            this.navigationGroupBox.Controls.Add(this.addCompetitionButton);
            this.navigationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationGroupBox.Location = new System.Drawing.Point(12, 60);
            this.navigationGroupBox.Name = "navigationGroupBox";
            this.navigationGroupBox.Size = new System.Drawing.Size(181, 378);
            this.navigationGroupBox.TabIndex = 0;
            this.navigationGroupBox.TabStop = false;
            this.navigationGroupBox.Text = "Navigation";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::BinCompeteSoft.Properties.Resources.Logo_WeDeb;
            this.logoPictureBox.Location = new System.Drawing.Point(6, 174);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(169, 92);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // listCompetitionsButton
            // 
            this.listCompetitionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listCompetitionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCompetitionsButton.Location = new System.Drawing.Point(6, 73);
            this.listCompetitionsButton.Name = "listCompetitionsButton";
            this.listCompetitionsButton.Size = new System.Drawing.Size(169, 38);
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
            this.addCompetitionButton.Size = new System.Drawing.Size(169, 38);
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
            this.notificationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.notificationsGroupBox.Controls.Add(this.notificationsExListBox);
            this.notificationsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsGroupBox.Location = new System.Drawing.Point(199, 60);
            this.notificationsGroupBox.Name = "notificationsGroupBox";
            this.notificationsGroupBox.Size = new System.Drawing.Size(209, 378);
            this.notificationsGroupBox.TabIndex = 15;
            this.notificationsGroupBox.TabStop = false;
            this.notificationsGroupBox.Text = "Notifications";
            // 
            // contestsGroupBox
            // 
            this.contestsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestsGroupBox.Controls.Add(this.contestsDataGridView);
            this.contestsGroupBox.Controls.Add(this.contestDetailsButton);
            this.contestsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestsGroupBox.Location = new System.Drawing.Point(414, 60);
            this.contestsGroupBox.Name = "contestsGroupBox";
            this.contestsGroupBox.Size = new System.Drawing.Size(255, 378);
            this.contestsGroupBox.TabIndex = 17;
            this.contestsGroupBox.TabStop = false;
            this.contestsGroupBox.Text = "Contests yet to happen";
            // 
            // contestsDataGridView
            // 
            this.contestsDataGridView.AllowUserToAddRows = false;
            this.contestsDataGridView.AllowUserToDeleteRows = false;
            this.contestsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contestsDataGridView.Location = new System.Drawing.Point(6, 29);
            this.contestsDataGridView.Name = "contestsDataGridView";
            this.contestsDataGridView.ReadOnly = true;
            this.contestsDataGridView.Size = new System.Drawing.Size(243, 299);
            this.contestsDataGridView.TabIndex = 16;
            // 
            // contestDetailsButton
            // 
            this.contestDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestDetailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestDetailsButton.Location = new System.Drawing.Point(6, 334);
            this.contestDetailsButton.Name = "contestDetailsButton";
            this.contestDetailsButton.Size = new System.Drawing.Size(243, 38);
            this.contestDetailsButton.TabIndex = 15;
            this.contestDetailsButton.Text = "See contest details";
            this.contestDetailsButton.UseVisualStyleBackColor = true;
            // 
            // statisticsGroupBox
            // 
            this.statisticsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticsGroupBox.Controls.Add(this.nextYearButton);
            this.statisticsGroupBox.Controls.Add(this.previousYearButton);
            this.statisticsGroupBox.Controls.Add(this.yearLabel);
            this.statisticsGroupBox.Controls.Add(this.label3);
            this.statisticsGroupBox.Controls.Add(this.label2);
            this.statisticsGroupBox.Controls.Add(this.label1);
            this.statisticsGroupBox.Controls.Add(this.totalProjectsResultLabel);
            this.statisticsGroupBox.Controls.Add(this.totalContestsResultLabel);
            this.statisticsGroupBox.Controls.Add(this.projectAvgResultLabel);
            this.statisticsGroupBox.Controls.Add(this.projectAvgLabel);
            this.statisticsGroupBox.Controls.Add(this.totalCompetitionsLabel);
            this.statisticsGroupBox.Controls.Add(this.bestProjectsDataGridView);
            this.statisticsGroupBox.Controls.Add(this.totalProjectsLabel);
            this.statisticsGroupBox.Controls.Add(this.bestProjectsLabel);
            this.statisticsGroupBox.Controls.Add(this.categoriesStatisticsLabel);
            this.statisticsGroupBox.Controls.Add(this.categoryStatisticsChart);
            this.statisticsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsGroupBox.Location = new System.Drawing.Point(675, 60);
            this.statisticsGroupBox.Name = "statisticsGroupBox";
            this.statisticsGroupBox.Size = new System.Drawing.Size(313, 378);
            this.statisticsGroupBox.TabIndex = 17;
            this.statisticsGroupBox.TabStop = false;
            this.statisticsGroupBox.Text = "Statistics";
            // 
            // categoryStatisticsChart
            // 
            chartArea10.Name = "ChartArea1";
            this.categoryStatisticsChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.categoryStatisticsChart.Legends.Add(legend10);
            this.categoryStatisticsChart.Location = new System.Drawing.Point(5, 74);
            this.categoryStatisticsChart.Name = "categoryStatisticsChart";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series10.Legend = "Legend1";
            series10.Name = "CategoryStatistics";
            this.categoryStatisticsChart.Series.Add(series10);
            this.categoryStatisticsChart.Size = new System.Drawing.Size(302, 115);
            this.categoryStatisticsChart.TabIndex = 0;
            this.categoryStatisticsChart.Text = "Projects by theme";
            // 
            // categoriesStatisticsLabel
            // 
            this.categoriesStatisticsLabel.AutoSize = true;
            this.categoriesStatisticsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesStatisticsLabel.Location = new System.Drawing.Point(1, 51);
            this.categoriesStatisticsLabel.Name = "categoriesStatisticsLabel";
            this.categoriesStatisticsLabel.Size = new System.Drawing.Size(151, 20);
            this.categoriesStatisticsLabel.TabIndex = 18;
            this.categoriesStatisticsLabel.Text = "Projects by category";
            // 
            // bestProjectsLabel
            // 
            this.bestProjectsLabel.AutoSize = true;
            this.bestProjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestProjectsLabel.Location = new System.Drawing.Point(1, 193);
            this.bestProjectsLabel.Name = "bestProjectsLabel";
            this.bestProjectsLabel.Size = new System.Drawing.Size(236, 20);
            this.bestProjectsLabel.TabIndex = 19;
            this.bestProjectsLabel.Text = "Projects with the best evaluation";
            // 
            // totalProjectsLabel
            // 
            this.totalProjectsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalProjectsLabel.AutoSize = true;
            this.totalProjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProjectsLabel.Location = new System.Drawing.Point(2, 332);
            this.totalProjectsLabel.Name = "totalProjectsLabel";
            this.totalProjectsLabel.Size = new System.Drawing.Size(177, 18);
            this.totalProjectsLabel.TabIndex = 20;
            this.totalProjectsLabel.Text = "Total number of projects: ";
            // 
            // bestProjectsDataGridView
            // 
            this.bestProjectsDataGridView.AllowUserToAddRows = false;
            this.bestProjectsDataGridView.AllowUserToDeleteRows = false;
            this.bestProjectsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bestProjectsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.bestProjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bestProjectsDataGridView.Location = new System.Drawing.Point(6, 216);
            this.bestProjectsDataGridView.Name = "bestProjectsDataGridView";
            this.bestProjectsDataGridView.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bestProjectsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.bestProjectsDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestProjectsDataGridView.Size = new System.Drawing.Size(301, 94);
            this.bestProjectsDataGridView.TabIndex = 21;
            // 
            // totalCompetitionsLabel
            // 
            this.totalCompetitionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalCompetitionsLabel.AutoSize = true;
            this.totalCompetitionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCompetitionsLabel.Location = new System.Drawing.Point(2, 352);
            this.totalCompetitionsLabel.Name = "totalCompetitionsLabel";
            this.totalCompetitionsLabel.Size = new System.Drawing.Size(205, 18);
            this.totalCompetitionsLabel.TabIndex = 22;
            this.totalCompetitionsLabel.Text = "Total number of competitions:";
            // 
            // projectAvgLabel
            // 
            this.projectAvgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectAvgLabel.AutoSize = true;
            this.projectAvgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectAvgLabel.Location = new System.Drawing.Point(2, 313);
            this.projectAvgLabel.Name = "projectAvgLabel";
            this.projectAvgLabel.Size = new System.Drawing.Size(271, 18);
            this.projectAvgLabel.TabIndex = 23;
            this.projectAvgLabel.Text = "Average number of projects per contest:";
            // 
            // projectAvgResultLabel
            // 
            this.projectAvgResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectAvgResultLabel.AutoSize = true;
            this.projectAvgResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectAvgResultLabel.Location = new System.Drawing.Point(292, 313);
            this.projectAvgResultLabel.Name = "projectAvgResultLabel";
            this.projectAvgResultLabel.Size = new System.Drawing.Size(15, 18);
            this.projectAvgResultLabel.TabIndex = 24;
            this.projectAvgResultLabel.Text = "x";
            // 
            // totalContestsResultLabel
            // 
            this.totalContestsResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalContestsResultLabel.AutoSize = true;
            this.totalContestsResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalContestsResultLabel.Location = new System.Drawing.Point(292, 352);
            this.totalContestsResultLabel.Name = "totalContestsResultLabel";
            this.totalContestsResultLabel.Size = new System.Drawing.Size(15, 18);
            this.totalContestsResultLabel.TabIndex = 25;
            this.totalContestsResultLabel.Text = "x";
            // 
            // totalProjectsResultLabel
            // 
            this.totalProjectsResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalProjectsResultLabel.AutoSize = true;
            this.totalProjectsResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProjectsResultLabel.Location = new System.Drawing.Point(292, 332);
            this.totalProjectsResultLabel.Name = "totalProjectsResultLabel";
            this.totalProjectsResultLabel.Size = new System.Drawing.Size(15, 18);
            this.totalProjectsResultLabel.TabIndex = 26;
            this.totalProjectsResultLabel.Text = "x";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 2);
            this.label1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 2);
            this.label2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 2);
            this.label3.TabIndex = 28;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLabel.Location = new System.Drawing.Point(126, 21);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(53, 25);
            this.yearLabel.TabIndex = 18;
            this.yearLabel.Text = "Year";
            // 
            // previousYearButton
            // 
            this.previousYearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previousYearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousYearButton.Location = new System.Drawing.Point(100, 24);
            this.previousYearButton.Name = "previousYearButton";
            this.previousYearButton.Size = new System.Drawing.Size(20, 20);
            this.previousYearButton.TabIndex = 18;
            this.previousYearButton.Text = "◀";
            this.previousYearButton.UseVisualStyleBackColor = true;
            this.previousYearButton.Click += new System.EventHandler(this.previousYearButton_Click);
            // 
            // nextYearButton
            // 
            this.nextYearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextYearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextYearButton.Location = new System.Drawing.Point(185, 24);
            this.nextYearButton.Name = "nextYearButton";
            this.nextYearButton.Size = new System.Drawing.Size(20, 20);
            this.nextYearButton.TabIndex = 29;
            this.nextYearButton.Text = "▶";
            this.nextYearButton.UseVisualStyleBackColor = true;
            this.nextYearButton.Click += new System.EventHandler(this.nextYearButton_Click);
            // 
            // notificationsExListBox
            // 
            this.notificationsExListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notificationsExListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.notificationsExListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsExListBox.FormattingEnabled = true;
            this.notificationsExListBox.IntegralHeight = false;
            this.notificationsExListBox.ItemHeight = 60;
            this.notificationsExListBox.Location = new System.Drawing.Point(6, 29);
            this.notificationsExListBox.Name = "notificationsExListBox";
            this.notificationsExListBox.Size = new System.Drawing.Size(197, 341);
            this.notificationsExListBox.TabIndex = 16;
            // 
            // JudgeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.statisticsGroupBox);
            this.Controls.Add(this.contestsGroupBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.notificationsGroupBox.ResumeLayout(false);
            this.contestsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contestsDataGridView)).EndInit();
            this.statisticsGroupBox.ResumeLayout(false);
            this.statisticsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestProjectsDataGridView)).EndInit();
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
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.GroupBox notificationsGroupBox;
        private exListBox notificationsExListBox;
        private System.Windows.Forms.GroupBox contestsGroupBox;
        private System.Windows.Forms.GroupBox statisticsGroupBox;
        private System.Windows.Forms.Button contestDetailsButton;
        private System.Windows.Forms.DataGridView contestsDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart categoryStatisticsChart;
        private System.Windows.Forms.Label totalProjectsLabel;
        private System.Windows.Forms.Label bestProjectsLabel;
        private System.Windows.Forms.Label categoriesStatisticsLabel;
        private System.Windows.Forms.Label projectAvgLabel;
        private System.Windows.Forms.Label totalCompetitionsLabel;
        private System.Windows.Forms.DataGridView bestProjectsDataGridView;
        private System.Windows.Forms.Label totalProjectsResultLabel;
        private System.Windows.Forms.Label totalContestsResultLabel;
        private System.Windows.Forms.Label projectAvgResultLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Button previousYearButton;
        private System.Windows.Forms.Button nextYearButton;
    }
}