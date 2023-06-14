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

namespace OrderManager.Views
{
    /// <summary>
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Page
    {
        public ObservableCollection<Customer> InitialCustomers { get; } = new ObservableCollection<Customer>();
        public ObservableCollection<Product> InitialProducts { get; } = new ObservableCollection<Product>();

        private ORder1 ORder1;
        public UpdateOrder(ORder1 order)
        {
            ORder1 = order;
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

        private void UpdateOrderSubmit_Click(object sender, RoutedEventArgs e)
        {
            using (OrderManagerContext context = new OrderManagerContext())
            {
                ORder1 orderToUpdate = context.ORder1s.FirstOrDefault();




                if (orderToUpdate != null)
                {
                    if (int.TryParse(((ComboBox)FindName("CustomerId")).Text, out int customerId))
                    {
                        
                        {
                            orderToUpdate.CustomerId = customerId;
                            orderToUpdate.OrderNumber = ((TextBox)FindName("OrderNumber")).Text ?? "Empty";
                            orderToUpdate.OrderDate = ((DatePicker)FindName("OrderDate")).SelectedDate ?? DateTime.MinValue;
                            orderToUpdate.Quantity = int.TryParse(((TextBox)FindName("Quantity")).Text, out int quantity) ? quantity : 0;
                            orderToUpdate.ProductId = int.TryParse(((ComboBox)FindName("ProductId")).Text, out int productId) ? productId : 0;
                        };





                        context.SaveChanges();
                    }
                    else
                    {
                        // Obsługa błędu
                    }

                }
             


                Orders newPage = new Orders();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(newPage);
            }
        }
    }
}
