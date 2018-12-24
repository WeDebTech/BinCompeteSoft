namespace BinCompeteSoft
{
    partial class EditCriteriaValues
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
            this.criteriaValuesDataGridView = new System.Windows.Forms.DataGridView();
            this.criteriaValuesLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.legendLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaValuesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // criteriaValuesDataGridView
            // 
            this.criteriaValuesDataGridView.AllowUserToAddRows = false;
            this.criteriaValuesDataGridView.AllowUserToDeleteRows = false;
            this.criteriaValuesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.criteriaValuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criteriaValuesDataGridView.Location = new System.Drawing.Point(12, 43);
            this.criteriaValuesDataGridView.Name = "criteriaValuesDataGridView";
            this.criteriaValuesDataGridView.Size = new System.Drawing.Size(976, 321);
            this.criteriaValuesDataGridView.TabIndex = 0;
            this.criteriaValuesDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.criteriaValuesDataGridView_CellValidating);
            // 
            // criteriaValuesLabel
            // 
            this.criteriaValuesLabel.AutoSize = true;
            this.criteriaValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaValuesLabel.Location = new System.Drawing.Point(6, 9);
            this.criteriaValuesLabel.Name = "criteriaValuesLabel";
            this.criteriaValuesLabel.Size = new System.Drawing.Size(271, 31);
            this.criteriaValuesLabel.TabIndex = 1;
            this.criteriaValuesLabel.Text = "Assign criteria values";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(12, 400);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(168, 38);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(818, 400);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(168, 38);
            this.acceptButton.TabIndex = 35;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // legendLabel
            // 
            this.legendLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.legendLabel.AutoSize = true;
            this.legendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.legendLabel.Location = new System.Drawing.Point(12, 367);
            this.legendLabel.Name = "legendLabel";
            this.legendLabel.Size = new System.Drawing.Size(773, 30);
            this.legendLabel.TabIndex = 37;
            this.legendLabel.Text = "Legend: 1 - Same importance; 3 - somewhat more important; 5- More important; 7 - " +
    "Very much more important; 9 - Absolutely more important\r\n2,4,6,8 - Intermediate " +
    "values";
            // 
            // EditCriteriaValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.legendLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.criteriaValuesLabel);
            this.Controls.Add(this.criteriaValuesDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCriteriaValues";
            this.Text = "EditCriteriaValues";
            ((System.ComponentModel.ISupportInitialize)(this.criteriaValuesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView criteriaValuesDataGridView;
        private System.Windows.Forms.Label criteriaValuesLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label legendLabel;
    }
}