using System.Data;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

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
    }
}
