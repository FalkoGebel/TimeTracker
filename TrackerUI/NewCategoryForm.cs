using TrackerLibrary;

namespace TrackerUI
{
    public partial class NewCategoryForm : Form
    {
        public NewCategoryForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MainForm.ShowError(Properties.Resources.ERR_MISSING_CATEGORY_NAME);
                return;
            }

            if (TrackerLogic.CategoryExists(NameTextBox.Text))
            {
                MainForm.ShowError(Properties.Resources.ERR_CATEGORY_EXISTS);
                return;
            }

            TrackerLogic.AddCategory(NameTextBox.Text);
            
            Close();
        }
    }
}
