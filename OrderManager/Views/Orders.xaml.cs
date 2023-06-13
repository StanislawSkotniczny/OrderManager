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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
            using OrderManagerContext context = new OrderManagerContext();
            var orders = from Order in context.Orders
                            select Order;
            foreach (var order in orders)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

                Button button = new Button();
                Button button2 = new Button();
                Button button3 = new Button();
                Label label = new Label();

                button.Content = $"{order.OrderNumber} {order.OrderDate}";
                button2.Content = "Update";
                button3.Content = "Delete";

                button.Style = FindResource("AddOrderRoundedbtn") as Style;
                button2.Style = FindResource("AddOrderRoundedbtn") as Style;
                button3.Style = FindResource("AddOrderRoundedbtn") as Style;

                button.Background = Brushes.BlanchedAlmond;
                button2.Background = Brushes.Yellow;
                button3.Background = Brushes.Red;

                button.Width = 300;
                button.Height = 25;
                button2.Width = 100;
                button2.Height = 25;
                button3.Width = 100;
                button3.Height = 25;

                button.Margin = new Thickness(10);
                button2.Margin = new Thickness(10);
                button3.Margin = new Thickness(10);

                button.FontWeight = FontWeights.Bold;
                button2.FontWeight = FontWeights.Bold;
                button3.FontWeight = FontWeights.Bold;

                button3.Click += (sender, e) => DeleteOrder(order);

                Grid.SetColumn(button, 0);
                Grid.SetColumn(button2, 1);
                Grid.SetColumn(button3, 2);

                grid.Children.Add(button);
                grid.Children.Add(button2);
                grid.Children.Add(button3);

                OrderList.Children.Add(grid);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrder newPage = new AddOrder();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }


        private void DeleteOrder(Order order)
        {
            using OrderManagerContext context = new OrderManagerContext();

            if (context.Entry(order).State == EntityState.Detached)
            {
                context.Attach(order);
            }

            //context.Customers.Remove(order);
            context.SaveChanges();
            Page newPage = new Orders();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }

    }
}
