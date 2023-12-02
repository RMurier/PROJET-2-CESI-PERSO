using AgroLink.Interfaces;
using AgroLink.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
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
            DataContext = this;
            ListeSites = _sites.GetSites().Result;
            SitesComboBox.ItemsSource = ListeSites;
            ListeServices = _services.GetServices().Result;
            ServicesComboBox.ItemsSource = ListeServices;


        }

        private async Task<List<TService>> GetServices()
        {
            // Effectuez votre requête HTTP ici pour obtenir les données de l'API
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("https://localhost:7150/Services/GetAllServices").Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TService>>(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TService>();
                }
            }
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
                ChargerPage(new Uri("Admin.xaml", UriKind.Relative));
            }
        }

        private void ChargerPage(Uri uri)
        {
            MainFrame.Navigate(uri);
        }
    }
}
