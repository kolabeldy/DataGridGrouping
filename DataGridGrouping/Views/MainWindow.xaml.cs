using DataGridGrouping.ViewModels;
using System.Windows;

namespace DataGridGrouping.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}