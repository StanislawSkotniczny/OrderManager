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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManager.Views
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            using OrderManagerContext  context = new OrderManagerContext();
            Customer customer = new Customer()
            {
                Name = ((TextBox)FindName("FirstName")).Text ?? "Empty",
                SecondName = ((TextBox)FindName("SecondName")).Text ?? "Empty",
                Email = ((TextBox)FindName("Email")).Text ?? "Empty",
            };

            context.Customers.Add(customer);

            context.SaveChanges();


            Page newPage = new Customers();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);

        }
    }
}
