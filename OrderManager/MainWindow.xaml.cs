using OrderManager.Classes;
using OrderManager.Entities;
using OrderManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var page = new HomeView();
            mainFrame.Content = page;
        }

        private void CustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = new Customers();
            mainFrame.Content = page;

        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = new HomeView();
            mainFrame.Content = page;
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = new Products();
            mainFrame.Content = page;
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = new Orders();
            mainFrame.Content = page;
        }
    }
}
