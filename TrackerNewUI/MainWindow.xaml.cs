using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackerLibrary;

namespace TrackerNewUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Panel { Processing, Reporting, Administration };
        private List<CategoryModel> Categories = new();
        private TrackedTimeModel? trackedTimeModel;
        
        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            UpdateWorkPanel(Panel.Administration);
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
            trackedTimeModel = TrackerLogic.Start(((CategoryModel)ProcessingCategoryComboBox.SelectedItem).Name);
            ProcessingStopButton.IsEnabled = true;
        }

        private void ShowErorr(string msg)
        {
            // TODO - refactor from Label to TextBlock for message (create style use style for TextBlock)
            
            ErrorPanelMessageLabel.Content = msg;
            ErrorPanel.Visibility = Visibility.Visible;
        }

        private void ShowConfirm(string msg)
        {
            // TODO - use style for TextBlock

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
            if (trackedTimeModel == null)
                return;
            
            ProcessingStopButton.IsEnabled = false;
            TrackerLogic.Stop(trackedTimeModel);
            trackedTimeModel = null;
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
            ShowErorr("Not implemented");
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

        private void ConfirmPanelNoButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmPanel.Visibility = Visibility.Hidden;
        }

        private void ConfirmPanelYesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowErorr("Not implemented");
        }
    }
}