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
   

            if (int.TryParse(((TextBox)FindName("CustomerId")).Text, out int customerId))
            {
                Order order = new Order()
                {
                    CustomerId = customerId,
                    OrderNumber = ((TextBox)FindName("OrderNumber")).Text ?? "Empty",
                    OrderDate = ((DatePicker)FindName("OrderDate")).SelectedDate ?? DateTime.MinValue,
                };

                context.Orders.Add(order);

                context.SaveChanges();
            }
            else
            {
                
            }

            Page newPage = new Products();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);



        }
    }
}
