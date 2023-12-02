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
        /// <summary>
        /// Quand le bouton "Services" est cliqué, redirige vers la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Services_Click(object sender, RoutedEventArgs e)
        {
            ChargerPageAdmin(new Uri("AdminServices.xaml", UriKind.Relative));
        }
        /// <summary>
        /// Quand le bouton "Sites" est cliqué, redirige vers la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Sites_Click(object sender, RoutedEventArgs e)
        {
            ChargerPageAdmin(new Uri("AdminSites.xaml", UriKind.Relative));
        }
        /// <summary>
        /// Quand le bouton "Salariés" est cliqué, redirige vers la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Salaries_Click(object sender, RoutedEventArgs e)
        {
            ChargerPageAdmin(new Uri("AdminSalaries.xaml", UriKind.Relative));
        }
        /// <summary>
        /// Quand le bouton "Retourn" est cliqué, redirige vers l'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public async void Retour_Click(object sender, RoutedEventArgs e)
        {
            Accueil accueil = new Accueil();
            accueil.RedirectHome();
        }
        /// <summary>
        /// Charge la vue partielle dans la frame Admin
        /// </summary>
        /// <param name="uri"></param>
        private void ChargerPageAdmin(Uri uri)
        {
            AdminFrame.Navigate(uri);
        }
    }
}
