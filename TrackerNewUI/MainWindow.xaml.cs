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
        
        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            UpdateWorkPanel(Panel.Processing);
            BindControls();
        }

        private void BindControls()
        {
            ProcessingCategoryComboBox.ItemsSource = TrackerLogic.GetCategories();
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
    }
}