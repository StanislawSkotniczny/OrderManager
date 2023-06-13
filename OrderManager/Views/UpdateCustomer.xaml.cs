using OrderManager.Classes;
using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Page
    {
        private Customer Customer;
        public UpdateCustomer(Customer customer)
        {
            Customer = customer;
            InitializeComponent();
        }

        private void CustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            using OrderManagerContext context = new OrderManagerContext();
            Customer.Name = ((TextBox)FindName("FirstName")).Text;
            Customer.SecondName = ((TextBox)FindName("SecondName")).Text;
            Customer.Email = ((TextBox)FindName("Email")).Text;
            context.SaveChanges();
            Customers newPage = new Customers();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
