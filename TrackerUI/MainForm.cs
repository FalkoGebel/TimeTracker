using System.Data;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class MainForm : Form
    {
        private TrackedTimeModel? currentTrackedTimeModel;

        public MainForm()
        {
            InitializeComponent();

            StopTimeTrackingButton.Enabled = false;

            UpdateCategoryComboBox();
        }

        /// <summary>
        /// Updates the category combo box items from the data source.
        /// </summary>
        private void UpdateCategoryComboBox()
        {
            CategoryComboBox.ResetText();
            CategoryComboBox.Items.Clear();

            foreach (var c in TrackerLogic.GetCategories().Where(c => c.Active))
            {
                CategoryComboBox.Items.Add(c.Name);
            }
        }

        private void StartTimeTrackingButton_Click(object sender, EventArgs e)
        {
            StartTimeTracking();
        }

        /// <summary>
        /// Starts time tracking if possible. Shows error message, if not.
        /// </summary>
        private void StartTimeTracking()
        {
            if (CategoryComboBox.SelectedItem == null)
            {
                ShowError(Properties.Resources.ERR_MISSING_CATEGORY);
            }
            else
            {
                currentTrackedTimeModel = TrackerLogic.Start(CategoryComboBox.SelectedItem.ToString());
                StartTimeTrackingButton.Enabled = false;
                StopTimeTrackingButton.Enabled = true;
                CategoryComboBox.Enabled = false;
                EditCategoriesButton.Enabled = false;
                ShowTrackedTimesButton.Enabled = false;
            }
        }

        /// <summary>
        /// Shows a message box designed for errors
        /// </summary>
        /// <param name="msg">Error message to show.</param>
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, Properties.Resources.ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows a message box designed for questions and returns true, if OK was clicked.
        /// </summary>
        /// <param name="msg">Confirm message to show.</param>
        /// <returns>True, if OK - otherwise False.</returns>
        public static bool ShowConfirm(string msg)
        {
            var msgResult = MessageBox.Show(msg,
                Properties.Resources.CONFIRM_CAPTION,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return msgResult == DialogResult.Yes;
        }

        private void StopTimeTrackingButton_Click(object sender, EventArgs e)
        {
            StopTimeTracking();
        }

        /// <summary>
        /// Stops the current time tracking.
        /// </summary>
        private void StopTimeTracking()
        {
            if (currentTrackedTimeModel == null)
                return;

            TrackerLogic.Stop(currentTrackedTimeModel);
            currentTrackedTimeModel = null;
            StartTimeTrackingButton.Enabled = true;
            StopTimeTrackingButton.Enabled = false;
            CategoryComboBox.Enabled = true;
            EditCategoriesButton.Enabled = true;
            ShowTrackedTimesButton.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimeTracking();
        }

        private void EditCategoriesButton_Click(object sender, EventArgs e)
        {
            ShowCategoriesForm();
        }

        /// <summary>
        /// Shows the category form for categories update in data and update the category combo box.
        /// </summary>
        private void ShowCategoriesForm()
        {
            CategoriesForm cf = new();
            cf.ShowDialog();
            UpdateCategoryComboBox();
        }

        private void ShowTrackedTimesButton_Click(object sender, EventArgs e)
        {
            ShowTrackedTimesForm();
        }

        /// <summary>
        /// Shows the tracked times form with the tracked times.
        /// </summary>
        private static void ShowTrackedTimesForm()
        {
            TrackedTimesForm ttf = new();
            ttf.ShowDialog();
        }
    }
}
