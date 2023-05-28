using OrderManager.Classes;
using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using OrderManagerContext context = new OrderManagerContext();

            Customer publisherx = new Customer()
            {
                Name = "Clown"
            };
            /*Author authorx = new Author()
            {
                Name = "AlohaDanceq"
            };*/
            context.Customers.Add(publisherx);
            /*context.Authors.Add(authorx);
            Book uncharted = new Book()
            {
                AuthorId = 1,
                Name = "Uncharted",
                Description = "qqweqwqewwqeqweqweqweewq"
            };
            context.Books.Add(uncharted);
            */
            context.SaveChanges();
           
        }
    }
}
