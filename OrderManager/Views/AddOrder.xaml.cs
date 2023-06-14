using OrderManager.Classes;
using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace OrderManager.Views
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {


        public ObservableCollection<Customer> InitialCustomers { get; } = new ObservableCollection<Customer>();
        public ObservableCollection<Product> InitialProducts { get; } = new ObservableCollection<Product>();
        public AddOrder()
        {
           
        InitializeComponent();
            using OrderManagerContext context = new OrderManagerContext();
            var customers = context.Customers.ToList();
            foreach (var customer in customers)
            {
                InitialCustomers.Add(customer);
            }

            var products = context.Products.ToList();
            foreach (var product in products)
            {
                InitialProducts.Add(product);
            }

            CustomerId.ItemsSource = InitialCustomers;
            ProductId.ItemsSource = InitialProducts;
        }

    
        private void AddOrderSubmit_Click(object sender, RoutedEventArgs e)
        {
          //  using OrderManagerContext context = new OrderManagerContext();


            /*   if (int.TryParse(((ComboBox)FindName("CustomerId")).Text, out int customerId))
               {
                   Order order = new Order()
                   {
                       CustomerId = customerId,
                       OrderNumber = ((TextBox)FindName("OrderNumber")).Text ?? "Empty",
                       OrderDate = ((DatePicker)FindName("OrderDate")).SelectedDate ?? DateTime.MinValue,
                   };


                   OrderItem orderItem = new OrderItem()
                   {
                       Quantity = ((TextBox)FindName("Quantity")).Text ?? "Empty";
                       ProductId  = (ComboBox)FindName("CustomerId")).Text;
                   };

                   context.Orders.Add(order);
                   context.OrderItems.Add(orderItem);

                   context.SaveChanges();
           }

                if (int.TryParse(((TextBox) FindName("Quantity")).Text, out int quantity)
                   && int.TryParse(((ComboBox) FindName("ProductId")).Text, out int productId))
               {
                   Order order = new Order()
                   {
                       CustomerId = customerId,
                       OrderNumber = ((TextBox)FindName("OrderNumber")).Text ?? "Empty",
                       OrderDate = ((DatePicker)FindName("OrderDate")).SelectedDate ?? DateTime.MinValue,
                   };

                   OrderItem orderItem = new OrderItem()
                   {
                       Quantity = quantity,
                       ProductId = productId
                   };

                   context.Orders.Add(order);
                   context.OrderItems.Add(orderItem);

                   context.SaveChanges();
               }





               else
               {

               }

               Page newPage = new Orders();
               NavigationService navigationService = NavigationService.GetNavigationService(this);
               navigationService.Navigate(newPage);


                  */

            using OrderManagerContext context = new OrderManagerContext();

            if (int.TryParse(((ComboBox)FindName("CustomerId")).Text, out int customerId))
            {
                ORder1 order = new ORder1()
                {
                    CustomerId = customerId,
                    OrderNumber = ((TextBox)FindName("OrderNumber")).Text ?? "Empty",
                    OrderDate = ((DatePicker)FindName("OrderDate")).SelectedDate ?? DateTime.MinValue,
                    Quantity = int.TryParse(((TextBox)FindName("Quantity")).Text, out int quantity) ? quantity : 0,
                    ProductId = int.TryParse(((ComboBox)FindName("ProductId")).Text, out int productId) ? productId : 0
                };

                

                context.ORder1s.Add(order);
               

                context.SaveChanges();
            }
            else
            {
                // Obsługa błędu
            }

            Page newPage = new Orders();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);


        }
    }
}
