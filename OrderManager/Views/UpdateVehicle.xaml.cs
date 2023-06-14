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
    /// Interaction logic for UpdateVehicle.xaml
    /// </summary>
    public partial class UpdateVehicle : Page
    {
        private Entities.Transport Transport;
        public UpdateVehicle(Entities.Transport transport)
        {
            Transport = transport;
            InitializeComponent();
        }

        private void UpdateVehicleSubmit_Click(object sender, RoutedEventArgs e)
        {

            using (OrderManagerContext context = new OrderManagerContext())
            {
                
                Entities.Transport transportToUpdate = context.Transports.FirstOrDefault();

                if (transportToUpdate != null)
                {
                    transportToUpdate.CarName = ((TextBox)FindName("CarName")).Text;
                    transportToUpdate.CarRegistration = ((TextBox)FindName("CarReg")).Text;
                    
                    context.SaveChanges();


                    Button button = (Button)sender;
                    button.Content = $"{transportToUpdate.CarName} Registration{transportToUpdate.CarRegistration} ";
                }

                Transport newPage = new Transport();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(newPage);
            }
        }
    }
}
