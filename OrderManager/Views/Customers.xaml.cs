using OrderManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

namespace OrderManager.Views
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        public Customers()
        {
            InitializeComponent();
            using OrderManagerContext context = new OrderManagerContext();
            var customers = from Customer in context.Customers
                       select Customer;
            foreach (var customer in customers)
            {
                Button button = new Button();
                button.Content = $"{customer.Name} {customer.SecondName}";
                
                CustomerList.Children.Add(button);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer newPage = new AddCustomer();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }



    } 
}
