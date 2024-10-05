using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrackerLibrary;

namespace TrackerNewUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Panel { Processing, Reporting, Administration };
        private enum ConfirmAction { DeleteCategory };
        private ConfirmAction? CurrentConfirmAction;
        private List<CategoryModel> Categories = [];
        private TrackedTimeModel? TrackedTimeModel;
        private List<TrackedTimeModel> TrackedTimes = [];

        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            UpdateWorkPanel(Panel.Processing);
            UpdateCategoriesFromData();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateWorkPanel(Panel p)
        {
            ProcessingPanel.Visibility = p == Panel.Processing ? Visibility.Visible : Visibility.Hidden;
            ReportingPanel.Visibility = p == Panel.Reporting ? Visibility.Visible : Visibility.Hidden;
            AdministrationPanel.Visibility = p == Panel.Administration ? Visibility.Visible : Visibility.Hidden;

            if (ReportingPanel.Visibility == Visibility.Visible)
                UpdateTrackedTimesFromData();
        }

        private void ProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWorkPanel(Panel.Processing);
        }

        private void ReportingButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWorkPanel(Panel.Reporting);
        }

        private void AdministrationButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWorkPanel(Panel.Administration);
        }

        private void ProcessingStartButton_Click(object sender, RoutedEventArgs e)
        {
            StartProcessing();
        }

        private void StartProcessing()
        {
            if (ProcessingCategoryComboBox.SelectedItem == null)
            {
                ShowErorr(Properties.Resources.ERROR_NO_CATEGORY_CHOSEN);
                return;
            }

            ProcessingStartButton.IsEnabled = false;
            ProcessingCategoryComboBox.IsEnabled = false;
            NavigationPanel.IsEnabled = false;
            TrackedTimeModel = TrackerLogic.Start(((CategoryModel)ProcessingCategoryComboBox.SelectedItem).Name);
            ProcessingStopButton.IsEnabled = true;
        }

        private void ShowErorr(string msg)
        {
            ErrorPanelMessageTextBlock.Text = msg;
            ErrorPanel.Visibility = Visibility.Visible;
        }

        private void ShowConfirm(string msg)
        {
            ConfirmPanelMessageTextBlock.Text = msg;
            ConfirmPanel.Visibility = Visibility.Visible;
        }

        private void ErrorPanelOkButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorPanel.Visibility = Visibility.Hidden;
        }

        private void ProcessingStopButton_Click(object sender, RoutedEventArgs e)
        {
            StopProcessing();
        }

        private void StopProcessing()
        {
            if (TrackedTimeModel == null)
                return;

            ProcessingStopButton.IsEnabled = false;
            TrackerLogic.Stop(TrackedTimeModel);
            TrackedTimeModel = null;
            NavigationPanel.IsEnabled = true;
            ProcessingCategoryComboBox.IsEnabled = true;
            ProcessingStartButton.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopProcessing();
        }

        private void HeaderLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void HeaderMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void AdministrationNewButton_Click(object sender, RoutedEventArgs e)
        {
            InsertCategory();
        }

        private void InsertCategory()
        {
            NewCategoryPanelTextBox.Text = string.Empty;
            NewCategoryPanel.Visibility = Visibility.Visible;
            NewCategoryPanelTextBox.Focus();
        }

        private void AdministrationDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteCategory();
        }

        private void DeleteCategory()
        {
            CategoryModel? cm = (CategoryModel)AdministrationCategoriesDataGrid.SelectedItem;

            if (cm == null)
            {
                ShowErorr(Properties.Resources.ERROR_NO_CATEGORY_CHOSEN);
                return;
            }

            if (cm.Active)
            {
                ShowErorr(Properties.Resources.ERROR_CATEGORY_IS_ACTIVE);
                return;
            }

            CurrentConfirmAction = ConfirmAction.DeleteCategory;
            ShowConfirm(Properties.Resources.CONFIRM_CATEGORY_DELETE.Replace("{CATEGORY_NAME}", cm.Name));
        }

        /// <summary>
        /// Gets the categories from the data and update all binded controls.
        /// </summary>
        private void UpdateCategoriesFromData()
        {
            Categories = TrackerLogic.GetCategories();
            AdministrationCategoriesDataGrid.ItemsSource = null;
            AdministrationCategoriesDataGrid.ItemsSource = Categories;
            ProcessingCategoryComboBox.ItemsSource = null;
            ProcessingCategoryComboBox.ItemsSource = Categories.Where(c => c.Active);
        }

        /// <summary>
        /// Gets the tracked times from the data and update all binded controls.
        /// </summary>
        private void UpdateTrackedTimesFromData()
        {
            TrackedTimes = TrackerLogic.GetTrackedTimes();
            ReportingTrackedTimesDataGrid.ItemsSource = null;
            TrackedTimes.Reverse();
            ReportingTrackedTimesDataGrid.ItemsSource = TrackedTimes;
        }

        private void ConfirmPanelNoButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmPanel.Visibility = Visibility.Hidden;
        }

        private void ConfirmPanelYesButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentConfirmAction == ConfirmAction.DeleteCategory)
            {
                CategoryModel cm = (CategoryModel)AdministrationCategoriesDataGrid.SelectedItem;
                TrackerLogic.RemoveCategory(cm.Name);
                UpdateCategoriesFromData();
            }
            ConfirmPanel.Visibility = Visibility.Hidden;
        }

        private void NewCategoryPanelCancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewCategoryPanel.Visibility = Visibility.Hidden;
        }

        private void NewCategoryPanelOkButton_Click(object sender, RoutedEventArgs e)
        {
            string cat = NewCategoryPanelTextBox.Text;


            if (cat == "")
            {
                ShowErorr(Properties.Resources.ERROR_NO_CATEGORY_CHOSEN);
                return;
            }

            if (Categories.Exists(c => c.Name == cat))
            {
                ShowErorr(Properties.Resources.NEW_CATEGORY_CAT_EXISTS.Replace("{CATEGORY_NAME}", cat));
                return;
            }

            TrackerLogic.AddCategory(cat);
            UpdateCategoriesFromData();
            NewCategoryPanel.Visibility = Visibility.Hidden;
        }

        private void AdministrationCategoriesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == Properties.Resources.ADMIN_CAT_TABLE_ACTIVE)
                ToggleActiveFlagForCategory((CategoryModel)e.Row.DataContext);
        }

        private void ToggleActiveFlagForCategory(CategoryModel cm)
        {
            if (cm.Active)
                TrackerLogic.DeactivateCategory(cm.Name);
            else
                TrackerLogic.ActivateCategory(cm.Name);

            UpdateCategoriesFromData();
        }
    }
}