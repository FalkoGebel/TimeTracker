using TrackerLibrary;

namespace TrackerUI
{
    public partial class CategoriesForm : Form
    {
        private readonly List<CategoryModel> Categories;

        public CategoriesForm()
        {
            Categories = [.. TrackerLogic.GetCategories().OrderBy(c => c.Name)];
            InitializeComponent();
            CategoriesDataGridView.DataSource = Categories;
        }

        public List<CategoryModel> GetCategories()
        {
            return Categories;
        }

        private void CategoriesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CategoriesDataGridView.EndEdit();
            TrackerLogic.UpdateCategories(Categories);
        }
    }
}
