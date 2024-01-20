namespace TrackerUI
{
    partial class NewCategoryForm
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
            CancelButton = new Button();
            OkButton = new Button();
            NameTextBox = new TextBox();
            NameLabel = new Label();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.AutoSize = true;
            CancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton.BackColor = Color.FromArgb(221, 161, 94);
            CancelButton.BackgroundImageLayout = ImageLayout.Center;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(128, 56);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(87, 37);
            CancelButton.TabIndex = 8;
            CancelButton.TabStop = false;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.AutoSize = true;
            OkButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OkButton.BackColor = Color.FromArgb(221, 161, 94);
            OkButton.BackgroundImageLayout = ImageLayout.Center;
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OkButton.Location = new Point(221, 56);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(51, 37);
            OkButton.TabIndex = 9;
            OkButton.TabStop = false;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameTextBox.BackColor = Color.FromArgb(254, 250, 224);
            NameTextBox.BorderStyle = BorderStyle.FixedSingle;
            NameTextBox.ForeColor = Color.FromArgb(40, 54, 24);
            NameTextBox.Location = new Point(70, 12);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(202, 27);
            NameTextBox.TabIndex = 0;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 15);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(52, 19);
            NameLabel.TabIndex = 11;
            NameLabel.Text = "Name";
            // 
            // NewCategoryForm
            // 
            AcceptButton = OkButton;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(254, 250, 224);
            CancelButton = CancelButton;
            ClientSize = new Size(284, 105);
            ControlBox = false;
            Controls.Add(NameLabel);
            Controls.Add(NameTextBox);
            Controls.Add(OkButton);
            Controls.Add(CancelButton);
            Font = new Font("Bahnschrift", 12F);
            ForeColor = Color.FromArgb(40, 54, 24);
            Margin = new Padding(4);
            Name = "NewCategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Category";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private new Button CancelButton;
        private Button OkButton;
        private TextBox NameTextBox;
        private Label NameLabel;
    }
}