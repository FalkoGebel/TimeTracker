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
            }
        }

        /// <summary>
        /// Shows an message box designed for errors
        /// </summary>
        /// <param name="msg">Error message to show.</param>
        private static void ShowError(string msg)
        {
            MessageBox.Show(msg, Properties.Resources.ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CategoriesForm cf = new([.. TrackerLogic.GetCategories().OrderBy(c => c.Name)]);
            cf.ShowDialog();
            TrackerLogic.UpdateCategories(cf.GetCategories());
            UpdateCategoryComboBox();
        }
    }
}
