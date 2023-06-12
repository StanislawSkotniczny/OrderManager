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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProductSubmit_Click(object sender, RoutedEventArgs e)
        {
            using OrderManagerContext context = new OrderManagerContext();
            Product product = new Product()
            {
                Name = ((TextBox)FindName("Name")).Text ?? "Empty",
               // Price = ((TextBox)FindName("Price")).Text ?? "Empty",
             
            };

            context.Products.Add(product);

            context.SaveChanges();


            Page newPage = new Products();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
