namespace TrackerUI
{
    partial class CategoriesForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            CategoriesDataGridView = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            activeDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            categoryModelBindingSource = new BindingSource(components);
            NewButton = new Button();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CategoriesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoryModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // CategoriesDataGridView
            // 
            CategoriesDataGridView.AllowUserToAddRows = false;
            CategoriesDataGridView.AllowUserToDeleteRows = false;
            CategoriesDataGridView.AllowUserToResizeColumns = false;
            CategoriesDataGridView.AllowUserToResizeRows = false;
            CategoriesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CategoriesDataGridView.AutoGenerateColumns = false;
            CategoriesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            CategoriesDataGridView.BackgroundColor = Color.FromArgb(254, 250, 224);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.IndianRed;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            CategoriesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            CategoriesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoriesDataGridView.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, activeDataGridViewCheckBoxColumn });
            CategoriesDataGridView.DataSource = categoryModelBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(254, 250, 224);
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(40, 54, 24);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(221, 161, 94);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(40, 54, 24);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            CategoriesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            CategoriesDataGridView.GridColor = Color.FromArgb(96, 108, 56);
            CategoriesDataGridView.Location = new Point(12, 12);
            CategoriesDataGridView.MultiSelect = false;
            CategoriesDataGridView.Name = "CategoriesDataGridView";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(221, 161, 94);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(221, 161, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(221, 161, 94);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(221, 161, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            CategoriesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            CategoriesDataGridView.RowHeadersWidth = 18;
            CategoriesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            CategoriesDataGridView.ScrollBars = ScrollBars.Vertical;
            CategoriesDataGridView.Size = new Size(360, 198);
            CategoriesDataGridView.TabIndex = 0;
            CategoriesDataGridView.CellEndEdit += CategoriesDataGridView_CellEndEdit;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 77;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            activeDataGridViewCheckBoxColumn.Width = 59;
            // 
            // categoryModelBindingSource
            // 
            categoryModelBindingSource.DataSource = typeof(TrackerLibrary.CategoryModel);
            // 
            // NewButton
            // 
            NewButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            NewButton.AutoSize = true;
            NewButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            NewButton.BackColor = Color.FromArgb(221, 161, 94);
            NewButton.BackgroundImageLayout = ImageLayout.Center;
            NewButton.FlatStyle = FlatStyle.Flat;
            NewButton.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewButton.Location = new Point(306, 216);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(66, 37);
            NewButton.TabIndex = 7;
            NewButton.Text = "New";
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += NewButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DeleteButton.AutoSize = true;
            DeleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteButton.BackColor = Color.FromArgb(221, 161, 94);
            DeleteButton.BackgroundImageLayout = ImageLayout.Center;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeleteButton.Location = new Point(216, 216);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(84, 37);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 224);
            ClientSize = new Size(384, 261);
            Controls.Add(DeleteButton);
            Controls.Add(NewButton);
            Controls.Add(CategoriesDataGridView);
            Font = new Font("Bahnschrift", 12F);
            ForeColor = Color.FromArgb(40, 54, 24);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriesForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Time Tracker -> Categories";
            FormClosing += CategoriesForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)CategoriesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoryModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView CategoriesDataGridView;
        private BindingSource categoryModelBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private Button NewButton;
        private Button DeleteButton;
    }
}