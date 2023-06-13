using Microsoft.EntityFrameworkCore;
using OrderManager.Classes;
using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        public Customers()
        {
            InitializeComponent();
            using OrderManagerContext context = new OrderManagerContext();
            var customers = from Customer in context.Customers
                       select Customer;
            foreach (var customer in customers)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) }); 
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) }); 
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) }); 

                Button button = new Button();
                Button button2 = new Button();
                Button button3 = new Button();
                Label label = new Label();

                button.Content = $"{customer.Name} {customer.SecondName} {customer.Email}";
                button2.Content = "Update";
                button3.Content = "Delete";


                // Ustawienie stylu przycisków
                button.Style = FindResource("RoundedAddCustomer") as Style;
                button2.Style = FindResource("RoundedAddCustomer") as Style;
                button3.Style = FindResource("RoundedAddCustomer") as Style;

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

               
                button2.Click += (sender, e) => GoToUpdateCustomer(customer);
                button3.Click += (sender, e) => DeleteCustomer(customer);

               
                Grid.SetColumn(button, 0); 
                Grid.SetColumn(button2, 1);
                Grid.SetColumn(button3, 2); 

                grid.Children.Add(button);
                grid.Children.Add(button2);
                grid.Children.Add(button3);

                CustomerList.Children.Add(grid);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer newPage = new AddCustomer();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }

        private void DeleteCustomer(Customer customer)
        {
            using OrderManagerContext context = new OrderManagerContext();

            if (context.Entry(customer).State == EntityState.Detached)
            {
                context.Attach(customer);
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            Page newPage = new Customers();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }

        private void GoToUpdateCustomer(Customer customer)
        {
            UpdateCustomer updatePage = new UpdateCustomer(customer);
            NavigationService.Navigate(updatePage);
        }


    } 
}
