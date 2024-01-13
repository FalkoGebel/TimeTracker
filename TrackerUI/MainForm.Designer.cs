namespace TrackerUI
{
    partial class MainForm
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
            CategoryLabel = new Label();
            CategoryComboBox = new ComboBox();
            EditCategoriesButton = new Button();
            CategoryGroupOuterBorderPanel = new Panel();
            CategoryGroupInnerBorderPanel = new Panel();
            CategoryComboBoxBorderPanel = new Panel();
            StartTimeTrackingButton = new Button();
            StopTimeTrackingButton = new Button();
            CategoryGroupOuterBorderPanel.SuspendLayout();
            CategoryGroupInnerBorderPanel.SuspendLayout();
            CategoryComboBoxBorderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(3, 7);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(75, 19);
            CategoryLabel.TabIndex = 2;
            CategoryLabel.Text = "Category";
            CategoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CategoryComboBox
            // 
            CategoryComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CategoryComboBox.AutoCompleteMode = AutoCompleteMode.Append;
            CategoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            CategoryComboBox.BackColor = Color.FromArgb(254, 250, 224);
            CategoryComboBox.FlatStyle = FlatStyle.Flat;
            CategoryComboBox.ForeColor = Color.FromArgb(40, 54, 24);
            CategoryComboBox.FormattingEnabled = true;
            CategoryComboBox.Location = new Point(1, 1);
            CategoryComboBox.Name = "CategoryComboBox";
            CategoryComboBox.Size = new Size(239, 27);
            CategoryComboBox.Sorted = true;
            CategoryComboBox.TabIndex = 4;
            // 
            // EditCategoriesButton
            // 
            EditCategoriesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditCategoriesButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            EditCategoriesButton.BackColor = Color.FromArgb(221, 161, 94);
            EditCategoriesButton.BackgroundImage = Properties.Resources.Pen_24x24;
            EditCategoriesButton.BackgroundImageLayout = ImageLayout.Center;
            EditCategoriesButton.FlatStyle = FlatStyle.Flat;
            EditCategoriesButton.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditCategoriesButton.Location = new Point(329, 3);
            EditCategoriesButton.Name = "EditCategoriesButton";
            EditCategoriesButton.Size = new Size(29, 29);
            EditCategoriesButton.TabIndex = 5;
            EditCategoriesButton.UseVisualStyleBackColor = true;
            EditCategoriesButton.Click += EditCategoriesButton_Click;
            // 
            // CategoryGroupOuterBorderPanel
            // 
            CategoryGroupOuterBorderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CategoryGroupOuterBorderPanel.BackColor = Color.FromArgb(96, 108, 56);
            CategoryGroupOuterBorderPanel.BorderStyle = BorderStyle.FixedSingle;
            CategoryGroupOuterBorderPanel.Controls.Add(CategoryGroupInnerBorderPanel);
            CategoryGroupOuterBorderPanel.Location = new Point(9, 9);
            CategoryGroupOuterBorderPanel.Margin = new Padding(0);
            CategoryGroupOuterBorderPanel.Name = "CategoryGroupOuterBorderPanel";
            CategoryGroupOuterBorderPanel.Size = new Size(366, 40);
            CategoryGroupOuterBorderPanel.TabIndex = 0;
            // 
            // CategoryGroupInnerBorderPanel
            // 
            CategoryGroupInnerBorderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CategoryGroupInnerBorderPanel.BackColor = Color.FromArgb(254, 250, 224);
            CategoryGroupInnerBorderPanel.BorderStyle = BorderStyle.FixedSingle;
            CategoryGroupInnerBorderPanel.Controls.Add(CategoryComboBoxBorderPanel);
            CategoryGroupInnerBorderPanel.Controls.Add(CategoryLabel);
            CategoryGroupInnerBorderPanel.Controls.Add(EditCategoriesButton);
            CategoryGroupInnerBorderPanel.Location = new Point(0, 0);
            CategoryGroupInnerBorderPanel.Margin = new Padding(0);
            CategoryGroupInnerBorderPanel.Name = "CategoryGroupInnerBorderPanel";
            CategoryGroupInnerBorderPanel.Size = new Size(364, 38);
            CategoryGroupInnerBorderPanel.TabIndex = 1;
            // 
            // CategoryComboBoxBorderPanel
            // 
            CategoryComboBoxBorderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CategoryComboBoxBorderPanel.BackColor = Color.FromArgb(96, 108, 56);
            CategoryComboBoxBorderPanel.Controls.Add(CategoryComboBox);
            CategoryComboBoxBorderPanel.Location = new Point(84, 3);
            CategoryComboBoxBorderPanel.Margin = new Padding(0);
            CategoryComboBoxBorderPanel.Name = "CategoryComboBoxBorderPanel";
            CategoryComboBoxBorderPanel.Size = new Size(241, 29);
            CategoryComboBoxBorderPanel.TabIndex = 3;
            // 
            // StartTimeTrackingButton
            // 
            StartTimeTrackingButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartTimeTrackingButton.AutoSize = true;
            StartTimeTrackingButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartTimeTrackingButton.BackColor = Color.FromArgb(221, 161, 94);
            StartTimeTrackingButton.BackgroundImageLayout = ImageLayout.Center;
            StartTimeTrackingButton.FlatStyle = FlatStyle.Flat;
            StartTimeTrackingButton.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartTimeTrackingButton.Location = new Point(82, 118);
            StartTimeTrackingButton.Name = "StartTimeTrackingButton";
            StartTimeTrackingButton.Size = new Size(71, 37);
            StartTimeTrackingButton.TabIndex = 6;
            StartTimeTrackingButton.Text = "Start";
            StartTimeTrackingButton.UseVisualStyleBackColor = true;
            StartTimeTrackingButton.Click += StartTimeTrackingButton_Click;
            // 
            // StopTimeTrackingButton
            // 
            StopTimeTrackingButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StopTimeTrackingButton.AutoSize = true;
            StopTimeTrackingButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StopTimeTrackingButton.BackColor = Color.FromArgb(221, 161, 94);
            StopTimeTrackingButton.BackgroundImageLayout = ImageLayout.Center;
            StopTimeTrackingButton.FlatStyle = FlatStyle.Flat;
            StopTimeTrackingButton.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StopTimeTrackingButton.Location = new Point(232, 118);
            StopTimeTrackingButton.Name = "StopTimeTrackingButton";
            StopTimeTrackingButton.Size = new Size(66, 37);
            StopTimeTrackingButton.TabIndex = 7;
            StopTimeTrackingButton.Text = "Stop";
            StopTimeTrackingButton.UseVisualStyleBackColor = true;
            StopTimeTrackingButton.Click += StopTimeTrackingButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 224);
            ClientSize = new Size(384, 261);
            Controls.Add(StopTimeTrackingButton);
            Controls.Add(StartTimeTrackingButton);
            Controls.Add(CategoryGroupOuterBorderPanel);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(40, 54, 24);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Time Tracker";
            FormClosing += MainForm_FormClosing;
            CategoryGroupOuterBorderPanel.ResumeLayout(false);
            CategoryGroupInnerBorderPanel.ResumeLayout(false);
            CategoryGroupInnerBorderPanel.PerformLayout();
            CategoryComboBoxBorderPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CategoryLabel;
        private ComboBox CategoryComboBox;
        private Button EditCategoriesButton;
        private Panel CategoryGroupOuterBorderPanel;
        private Panel CategoryGroupInnerBorderPanel;
        private Panel CategoryComboBoxBorderPanel;
        private Button StartTimeTrackingButton;
        private Button StopTimeTrackingButton;
    }
}