﻿using Microsoft.EntityFrameworkCore;
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
            var orders = from ORder1 in context.ORder1s
                            select ORder1;
            
            foreach (var order in orders)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength (1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                

                Button button = new Button();
                Button button2 = new Button();
                Button button3 = new Button();
                Label label = new Label();
                 
                button.Content = $"Order: {order.OrderNumber} Date: {order.OrderDate} Customer: {order.CustomerId} Product: {order.ProductId} Amount: {order.Quantity} ";
                button2.Content = "Update";
                button3.Content = "Delete";

              

                button.Background = Brushes.BlanchedAlmond;
                button2.Background = Brushes.Yellow;
                button3.Background = Brushes.Red;

                button.Width = 600;
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

                button2.Click += (sender, e) => GoToUpdateOrder(order);
                button3.Click += (sender, e) => DeleteOrder(order);

                Grid.SetColumnSpan(button, 3);
                Grid.SetColumn(button2, 1);
                Grid.SetColumn(button3, 2);

                Grid.SetRow(button, 0);
                Grid.SetRow(button2, 1);
                Grid.SetRow(button3, 1);

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


        private void DeleteOrder(ORder1 order)
        {
            using OrderManagerContext context = new OrderManagerContext();

            if (context.Entry(order).State == EntityState.Detached)
            {
                context.Attach(order);
            }


            context.ORder1s.Remove(order);
            context.SaveChanges();
            Page newPage = new Orders();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }


        private void GoToUpdateOrder(ORder1 order)
        {
            UpdateOrder updatePage = new UpdateOrder(order);
            NavigationService.Navigate(updatePage);
        }

    }
}
