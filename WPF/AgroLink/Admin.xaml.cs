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

namespace AgroLink
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            DataContext = this;
        }

        public async void Services_Click(object sender, RoutedEventArgs e)
        {
            ChargerPage(new Uri("AdminServices.xaml", UriKind.Relative));
        }
        public async void Sites_Click(object sender, RoutedEventArgs e)
        {
            ChargerPage(new Uri("AdminSites.xaml", UriKind.Relative));
        }
        public async void Salaries_Click(object sender, RoutedEventArgs e)
        {
            ChargerPage(new Uri("AdminSalaries.xaml", UriKind.Relative));
        }

        private void ChargerPage(Uri uri)
        {
            AdminFrame.Navigate(uri);
        }
    }
}
