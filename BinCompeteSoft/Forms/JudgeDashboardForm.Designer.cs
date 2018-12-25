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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.navigationGroupBox = new System.Windows.Forms.GroupBox();
            this.refreshContestsButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.listContestsButton = new System.Windows.Forms.Button();
            this.addContestButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.softwareNameLabel = new System.Windows.Forms.Label();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsExListBox = new BinCompeteSoft.exListBox();
            this.contestsGroupBox = new System.Windows.Forms.GroupBox();
            this.contestsDataGridView = new System.Windows.Forms.DataGridView();
            this.contestDetailsButton = new System.Windows.Forms.Button();
            this.statisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.nextYearButton = new System.Windows.Forms.Button();
            this.previousYearButton = new System.Windows.Forms.Button();
            this.yearLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.totalProjectsResultLabel = new System.Windows.Forms.Label();
            this.totalContestsResultLabel = new System.Windows.Forms.Label();
            this.projectAvgResultLabel = new System.Windows.Forms.Label();
            this.projectAvgLabel = new System.Windows.Forms.Label();
            this.totalCompetitionsLabel = new System.Windows.Forms.Label();
            this.bestProjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.totalProjectsLabel = new System.Windows.Forms.Label();
            this.bestProjectsLabel = new System.Windows.Forms.Label();
            this.categoriesStatisticsLabel = new System.Windows.Forms.Label();
            this.categoryStatisticsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resetPasswordButton = new System.Windows.Forms.Button();
            this.navigationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.notificationsGroupBox.SuspendLayout();
            this.contestsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contestsDataGridView)).BeginInit();
            this.statisticsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bestProjectsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationGroupBox
            // 
            this.navigationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navigationGroupBox.Controls.Add(this.refreshContestsButton);
            this.navigationGroupBox.Controls.Add(this.logoPictureBox);
            this.navigationGroupBox.Controls.Add(this.listContestsButton);
            this.navigationGroupBox.Controls.Add(this.addContestButton);
            this.navigationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationGroupBox.Location = new System.Drawing.Point(12, 60);
            this.navigationGroupBox.Name = "navigationGroupBox";
            this.navigationGroupBox.Size = new System.Drawing.Size(181, 378);
            this.navigationGroupBox.TabIndex = 0;
            this.navigationGroupBox.TabStop = false;
            this.navigationGroupBox.Text = "Navigation";
            // 
            // refreshContestsButton
            // 
            this.refreshContestsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshContestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshContestsButton.Location = new System.Drawing.Point(6, 117);
            this.refreshContestsButton.Name = "refreshContestsButton";
            this.refreshContestsButton.Size = new System.Drawing.Size(169, 38);
            this.refreshContestsButton.TabIndex = 15;
            this.refreshContestsButton.Text = "Refresh contests";
            this.refreshContestsButton.UseVisualStyleBackColor = true;
            this.refreshContestsButton.Click += new System.EventHandler(this.refreshContestsButton_Click);
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
            // listContestsButton
            // 
            this.listContestsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listContestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listContestsButton.Location = new System.Drawing.Point(6, 73);
            this.listContestsButton.Name = "listContestsButton";
            this.listContestsButton.Size = new System.Drawing.Size(169, 38);
            this.listContestsButton.TabIndex = 14;
            this.listContestsButton.Text = "List contests";
            this.listContestsButton.UseVisualStyleBackColor = true;
            this.listContestsButton.Click += new System.EventHandler(this.listContestsButton_Click);
            // 
            // addContestButton
            // 
            this.addContestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addContestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addContestButton.Location = new System.Drawing.Point(6, 29);
            this.addContestButton.Name = "addContestButton";
            this.addContestButton.Size = new System.Drawing.Size(169, 38);
            this.addContestButton.TabIndex = 13;
            this.addContestButton.Text = "Add contest";
            this.addContestButton.UseVisualStyleBackColor = true;
            this.addContestButton.Click += new System.EventHandler(this.addContestButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(907, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(81, 38);
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
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(276, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(459, 25);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contestsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.contestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.contestsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.contestDetailsButton.Click += new System.EventHandler(this.contestDetailsButton_Click);
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
            // bestProjectsDataGridView
            // 
            this.bestProjectsDataGridView.AllowUserToAddRows = false;
            this.bestProjectsDataGridView.AllowUserToDeleteRows = false;
            this.bestProjectsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bestProjectsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.bestProjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bestProjectsDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.bestProjectsDataGridView.Location = new System.Drawing.Point(6, 216);
            this.bestProjectsDataGridView.Name = "bestProjectsDataGridView";
            this.bestProjectsDataGridView.ReadOnly = true;
            this.bestProjectsDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestProjectsDataGridView.Size = new System.Drawing.Size(301, 94);
            this.bestProjectsDataGridView.TabIndex = 21;
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
            // categoryStatisticsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.categoryStatisticsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.categoryStatisticsChart.Legends.Add(legend1);
            this.categoryStatisticsChart.Location = new System.Drawing.Point(5, 74);
            this.categoryStatisticsChart.Name = "categoryStatisticsChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "CategoryStatistics";
            this.categoryStatisticsChart.Series.Add(series1);
            this.categoryStatisticsChart.Size = new System.Drawing.Size(302, 115);
            this.categoryStatisticsChart.TabIndex = 0;
            this.categoryStatisticsChart.Text = "Projects by theme";
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetPasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPasswordButton.Location = new System.Drawing.Point(741, 12);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(160, 38);
            this.resetPasswordButton.TabIndex = 18;
            this.resetPasswordButton.Text = "Reset password";
            this.resetPasswordButton.UseVisualStyleBackColor = true;
            this.resetPasswordButton.Click += new System.EventHandler(this.resetPasswordButton_Click);
            // 
            // JudgeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.resetPasswordButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.bestProjectsDataGridView)).EndInit();
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
        private System.Windows.Forms.Button listContestsButton;
        private System.Windows.Forms.Button addContestButton;
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
        private System.Windows.Forms.Button refreshContestsButton;
        private System.Windows.Forms.Button resetPasswordButton;
    }
}