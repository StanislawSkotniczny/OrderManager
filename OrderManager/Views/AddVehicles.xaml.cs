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
    /// Interaction logic for AddVehicles.xaml
    /// </summary>
    public partial class AddVehicles : Page
    {
        public AddVehicles()
        {
            InitializeComponent();
        }

        private void AddVehicleSubmit_Click(object sender, RoutedEventArgs e)
        {
            using OrderManagerContext context = new OrderManagerContext();
            Entities.Transport transport = new  Entities.Transport()
            {
                CarName = ((TextBox)FindName("CarName")).Text ?? "Empty",
                CarRegistration = ((TextBox)FindName("CarReg")).Text ?? "Empty",
                
            };

            context.Transports.Add(transport);

            context.SaveChanges();


            Page newPage = new Transport();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
