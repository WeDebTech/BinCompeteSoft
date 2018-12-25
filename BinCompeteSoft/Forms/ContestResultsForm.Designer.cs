namespace BinCompeteSoft
{
    partial class ContestResultsForm
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
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.acceptButton = new System.Windows.Forms.Button();
            this.contestResultsText = new System.Windows.Forms.Label();
            this.exportResultsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Location = new System.Drawing.Point(13, 43);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.Size = new System.Drawing.Size(775, 351);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(620, 400);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(168, 38);
            this.acceptButton.TabIndex = 35;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // contestResultsText
            // 
            this.contestResultsText.AutoSize = true;
            this.contestResultsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contestResultsText.Location = new System.Drawing.Point(12, 9);
            this.contestResultsText.Name = "contestResultsText";
            this.contestResultsText.Size = new System.Drawing.Size(205, 31);
            this.contestResultsText.TabIndex = 37;
            this.contestResultsText.Text = "Contest results:";
            // 
            // exportResultsButton
            // 
            this.exportResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportResultsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportResultsButton.Location = new System.Drawing.Point(13, 400);
            this.exportResultsButton.Name = "exportResultsButton";
            this.exportResultsButton.Size = new System.Drawing.Size(168, 38);
            this.exportResultsButton.TabIndex = 38;
            this.exportResultsButton.Text = "Export results";
            this.exportResultsButton.UseVisualStyleBackColor = true;
            this.exportResultsButton.Click += new System.EventHandler(this.exportResultsButton_Click);
            // 
            // ContestResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exportResultsButton);
            this.Controls.Add(this.contestResultsText);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.resultsDataGridView);
            this.Name = "ContestResultsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContestResultsForm";
            this.Load += new System.EventHandler(this.ContestResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label contestResultsText;
        private System.Windows.Forms.Button exportResultsButton;
    }
}