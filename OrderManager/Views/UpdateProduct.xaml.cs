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
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Page
    {
        private Product Product;
        public UpdateProduct(Product product)
        {
            Product = product;
            InitializeComponent();
        }

        private void ProductSubmit_Click(object sender, RoutedEventArgs e)
        {
            using (OrderManagerContext context = new OrderManagerContext())
            {
                Product productToUpdate = context.Products.FirstOrDefault();

                if (productToUpdate != null)
                {
                    if (decimal.TryParse(((TextBox)FindName("Price")).Text, out decimal price))
                    {
                        productToUpdate.Name = ((TextBox)FindName("Name")).Text ?? "Empty";
                            productToUpdate.Price = price;   
                    }
                    else
                    {

                    }
                    context.SaveChanges();

                    Button button = (Button)sender;
                    button.Content = $"{productToUpdate.Name} {productToUpdate.Price}$";
                }

                Products newPage = new Products();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(newPage);
            }
        }
    }
}
