using AgroLink.Interfaces;
using AgroLink.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfNegosud.Services;

namespace AgroLink
{
    /// <summary>
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public SitesService _sites { get; set; }
        public ServicesService _services { get; set; }
        public SalariesService _salaries { get; set; }
        public List<TSite> ListeSites { get; set; }
        public List<TService> ListeServices { get; set; }
        public IConfiguration Configuration { get; set; }


        public Accueil()
        {
            InitializeComponent();
            _sites = new SitesService();
            _services = new ServicesService();
            _salaries = new SalariesService();

            ListeSites = new List<TSite>();
            ListeServices = new List<TService>();
            DataContext = this;

            //Ajoute les sites dans les variables
            ListeSites.Add(new TSite()
            {
                Id = 0,
                Nom = "Séléctionnez un site",
                RefType = 1
            });
            ListeSites.AddRange(_sites.GetSites().Result);

            //Ajoute les services dans les variables
            ListeServices.Add(new TService()
            {
                Id = 0,
                Nom = "Séléctionnez un service"
            });
            ListeServices.AddRange(_services.GetServices().Result);


            //Met les données dans les boxes
            SitesComboBox.ItemsSource = ListeSites;
            ServicesComboBox.ItemsSource = ListeServices;

            //Met les valeurs par défaut sur les combobox
            SitesComboBox.SelectedValue = 0;
            ServicesComboBox.SelectedValue = 0;
        }

        /// <summary>
        /// Vérifie si une combinaison de touches est respéctée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Affichage de la partie Admin
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) &&
                (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) &&
                e.Key == Key.A)
            {
                // La combinaison Ctrl + Shift + A a été pressée
                Popup popup = new Popup();
                DemandeMotDePasse demandeMotDePasse = new DemandeMotDePasse();

                // Afficher la fenêtre de demande de mot de passe en tant que boîte de dialogue modale
                if (demandeMotDePasse.ShowDialog() == true)
                {
                    ChargerPage(new Uri("Admin.xaml", UriKind.Relative));
                }
            }
        }
        /// <summary>
        /// Retourne à l'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RedirectHome()
        {
            MainFrame.Content = null;
            //Initialise les services
            _sites = new SitesService();
            _services = new ServicesService();
            _salaries = new SalariesService();

            //Ajoute les sites dans les variables
            ListeSites.Add(new TSite()
            {
                Id = 0,
                Nom = "Séléctionnez un site",
                RefType = 1
            });
            ListeSites.AddRange(_sites.GetSites().Result);

            //Ajoute les services dans les variables
            ListeServices.Add(new TService()
            {
                Id = 0,
                Nom = "Séléctionnez un service"
            });
            ListeServices.AddRange(_services.GetServices().Result);            

            //Met les données dans les boxes
            SitesComboBox.ItemsSource = ListeSites;
            ServicesComboBox.ItemsSource = ListeServices;

            //Met les valeurs par défaut sur les combobox
            SitesComboBox.SelectedValue = 0;
            ServicesComboBox.SelectedValue = 0;
        }
        /// <summary>
        /// Recherche une personne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Search_Click(object sender, RoutedEventArgs e)
        {
            string? name = filterName.Text;
            int? refService = Convert.ToInt32(ServicesComboBox.SelectedValue);
            if(refService == 0)
            {
                refService = null;
            }
            int? refSite = Convert.ToInt32(SitesComboBox.SelectedValue);
            if(refSite == 0)
            {
                refSite = null;
            }

            List<TSalarie>? salaries = _salaries.GetSalariesByFilters(name, refService, refSite).Result;
            switch(salaries.Count)
            {
                case 0:
                    ChargerPage(new Uri("404.xaml", UriKind.Relative));
                    break;
                case 1:
                    MainFrame.Navigate(new UserInformations(salaries.First()));
                    break;
                case > 1:
                    MainFrame.Navigate(new UserSearchList(salaries));
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Charge une page dans la MainFrame
        /// </summary>
        /// <param name="uri">URI de la page à charger</param>
        private void ChargerPage(Uri uri)
        {
            MainFrame.Navigate(uri);
        }
    }
}
