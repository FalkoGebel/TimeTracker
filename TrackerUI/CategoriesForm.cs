using System.Data;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CategoriesForm : Form
    {
        private List<CategoryModel> Categories;

        public CategoriesForm()
        {
            InitializeComponent();
            UpdateCategoryDataGridView();
        }

        private void CategoriesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CategoriesDataGridView.EndEdit();
            TrackerLogic.UpdateCategories(Categories);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            NewCategory();
        }

        private void NewCategory()
        {
            NewCategoryForm ncf = new();
            ncf.ShowDialog();
            UpdateCategoryDataGridView();
        }

        private void UpdateCategoryDataGridView()
        {
            Categories = [.. TrackerLogic.GetCategories().OrderBy(c => c.Name)];
            CategoriesDataGridView.DataSource = CreateCategoriesGridDataTable();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DeleteCategory())
                UpdateCategoryDataGridView();
        }

        /// <summary>
        /// Removes the category of the current line, if not active and with information that all
        /// tracked times will get lost.
        /// </summary>
        private bool DeleteCategory()
        {
            DataRowView cm = (DataRowView)CategoriesDataGridView.CurrentRow.DataBoundItem;

            // Check if active
            if (bool.Parse(cm[1].ToString()))
            {
                MainForm.ShowError(Properties.Resources.ERR_CATEGORY_ACTIVE);
                return false;
            }

            string categoryName = cm[0].ToString();

            // Confirm deletion
            if (MainForm.ShowConfirm(Properties.Resources.CON_DELETE_CATEGORY.Replace("{CATEGORY_NAME}", categoryName)))
            {
                TrackerLogic.RemoveCategory(categoryName);
                return true;
            }

            return false;
        }
        private DataTable CreateCategoriesGridDataTable()
        {
            DataTable output = new();

            // Header
            output.Columns.Add(Properties.Resources.CGRID_NAME_HEADER);
            output.Columns.Add(Properties.Resources.CGRID_ACTIVE_HEADER, typeof(bool));

            // Lines
            foreach (var category in Categories)
            {
                output.Rows.Add(category.Name, category.Active);
            }

            return output;
        }

        private void CategoriesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (CategoriesDataGridView.Columns[e.ColumnIndex].Name != "activeDataGridViewCheckBoxColumn")
                return;

            UpdateCategoriesFromGridView();
        }

        private void UpdateCategoriesFromGridView()
        {
            Categories.Clear();
            
            for (int i = 0; i < CategoriesDataGridView.RowCount; i++)
            {
                CategoryModel cm = new();

                for (int j = 0; j < CategoriesDataGridView.ColumnCount; j++)
                {
                    if (j == 0)
                        cm.Name = CategoriesDataGridView[j, i].Value.ToString();
                    else
                    {
                        cm.Active = (bool)CategoriesDataGridView[j, i].Value;
                        //cm.Active = CategoriesDataGridView[j, i].Value.ToString() == "True";
                        //CategoriesDataGridView[j, i].Value = cm.Active;
                    }
                }
                Categories.Add(cm);
            }

            TrackerLogic.UpdateCategories(Categories);
        }
    }
}
