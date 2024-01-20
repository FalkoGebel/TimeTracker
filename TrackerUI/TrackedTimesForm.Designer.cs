namespace TrackerUI
{
    partial class TrackedTimesForm
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
            TrackedTimesGridView = new DataGridView();
            trackedTimeModelBindingSource = new BindingSource(components);
            OuterBorderPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)TrackedTimesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackedTimeModelBindingSource).BeginInit();
            OuterBorderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TrackedTimesGridView
            // 
            TrackedTimesGridView.AllowUserToAddRows = false;
            TrackedTimesGridView.AllowUserToDeleteRows = false;
            TrackedTimesGridView.AllowUserToResizeColumns = false;
            TrackedTimesGridView.AllowUserToResizeRows = false;
            TrackedTimesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            TrackedTimesGridView.BackgroundColor = Color.FromArgb(254, 250, 224);
            TrackedTimesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 54, 24);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            TrackedTimesGridView.DefaultCellStyle = dataGridViewCellStyle1;
            TrackedTimesGridView.Dock = DockStyle.Fill;
            TrackedTimesGridView.GridColor = Color.FromArgb(96, 108, 56);
            TrackedTimesGridView.Location = new Point(0, 0);
            TrackedTimesGridView.Name = "TrackedTimesGridView";
            TrackedTimesGridView.ReadOnly = true;
            TrackedTimesGridView.RowHeadersWidth = 18;
            TrackedTimesGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            TrackedTimesGridView.ScrollBars = ScrollBars.Vertical;
            TrackedTimesGridView.Size = new Size(611, 420);
            TrackedTimesGridView.TabIndex = 0;
            // 
            // trackedTimeModelBindingSource
            // 
            trackedTimeModelBindingSource.DataSource = typeof(TrackerLibrary.TrackedTimeModel);
            // 
            // OuterBorderPanel
            // 
            OuterBorderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OuterBorderPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OuterBorderPanel.Controls.Add(TrackedTimesGridView);
            OuterBorderPanel.Location = new Point(12, 12);
            OuterBorderPanel.Name = "OuterBorderPanel";
            OuterBorderPanel.Size = new Size(611, 420);
            OuterBorderPanel.TabIndex = 1;
            // 
            // TrackedTimesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(254, 250, 224);
            ClientSize = new Size(634, 441);
            Controls.Add(OuterBorderPanel);
            Font = new Font("Bahnschrift", 12F);
            ForeColor = Color.FromArgb(40, 54, 24);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrackedTimesForm";
            Padding = new Padding(35);
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Time Tracker -> Tracked Times";
            ((System.ComponentModel.ISupportInitialize)TrackedTimesGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackedTimeModelBindingSource).EndInit();
            OuterBorderPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView TrackedTimesGridView;
        private BindingSource trackedTimeModelBindingSource;
        private Panel OuterBorderPanel;
    }
}