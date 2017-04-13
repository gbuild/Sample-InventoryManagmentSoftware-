using IMS.Pages;
using System;
using System.Windows;

namespace IMS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingPlace.NavigationService.Navigate(new Uri("Pages/Product.xaml", UriKind.Relative));
        }

        private void DeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingPlace.NavigationService.Navigate(new Uri("Pages/Delivery.xaml", UriKind.Relative));
        }
    }
}
