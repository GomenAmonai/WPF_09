using System.Windows;
using CityManagerApp.Models;
using CityManagerApp.ViewModels;

namespace CityManagerApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as CityManagerViewModel;
            viewModel?.AddCity();
        }

        private void RemoveCity_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as CityManagerViewModel;
            if (viewModel != null && CitiesDataGrid.SelectedItem is City selectedCity)
            {
                viewModel.RemoveCity(selectedCity);
            }
        }
    }
}
