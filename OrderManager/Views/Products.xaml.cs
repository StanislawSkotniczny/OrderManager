using Microsoft.EntityFrameworkCore;
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
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

                Button button = new Button();
                Button button2 = new Button();
                Button button3 = new Button();
                Label label = new Label();

                button.Content = $"{product.Name} {product.Price}";
                button2.Content = "Update";
                button3.Content = "Delete";
                button3.Click += (sender, e) => DeleteProduct(product);

                Grid.SetColumn(button, 0);
                Grid.SetColumn(button2, 1);
                Grid.SetColumn(button3, 2);

                grid.Children.Add(button);
                grid.Children.Add(button2);
                grid.Children.Add(button3);

                ProductList.Children.Add(grid);
            }

        
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            AddProduct newPage = new AddProduct();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }

        private void DeleteProduct(Product product)
        {
            using OrderManagerContext context = new OrderManagerContext();

            if (context.Entry(product).State == EntityState.Detached)
            {
                context.Attach(product);
            }

            context.Products.Remove(product);
            context.SaveChanges();
            Page newPage = new Products();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }


    }

        


}

