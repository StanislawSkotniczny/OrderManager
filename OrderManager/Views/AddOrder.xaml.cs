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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        public AddOrder()
        {
            InitializeComponent();
        }

    
        private void AddOrderSubmit_Click(object sender, RoutedEventArgs e)
        {
            using OrderManagerContext context = new OrderManagerContext();
            Order order = new Order()
            {
                OrderNumber = ((TextBox)FindName("FirstName")).Text ?? "Empty",
                OrderDate = ((DatePicker)FindName("OrderDate")).SelectedDate ?? DateTime.MinValue,
                // CustomerId = ((TextBox)FindName("Email")).Text ?? "Empty",
            };

            context.Orders.Add(order);

            context.SaveChanges();


            Page newPage = new Customers();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);

        }
    }
}
