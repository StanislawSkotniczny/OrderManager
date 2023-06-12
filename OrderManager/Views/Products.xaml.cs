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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
            using OrderManagerContext context = new OrderManagerContext();
            var products = from Product in context.Products
                            select Product;
            foreach (var product in products)
            {
                Button button = new Button();
                button.Content = $"{product.Name} {product.Price}";

                ProductList.Children.Add(button);
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            AddProduct newPage = new AddProduct();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }

        
    }

