using AgroLink.Models;
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
using WpfNegosud.Services;

namespace AgroLink
{
    /// <summary>
    /// Interaction logic for UserInformations.xaml
    /// </summary>
    public partial class UserInformations : Page
    {
        public TSalarie Salarie { get; set; }
        public string Site { get; set; }
        public string Service { get; set; }
        private readonly ServicesService _services;
        private readonly SitesService _sites;
        public UserInformations(TSalarie salarie)
        {
            _sites = new SitesService();
            _services = new ServicesService();
            InitializeComponent();
            Salarie = salarie;
            Site = _sites.GetSites().Result.Where(x => x.Id == Salarie.RefSite).First().Nom;
            Service = _services.GetServices().Result.Where(x => x.Id == Salarie.RefService).First().Nom;
            InitializeUserData();
        }
        /// <summary>
        /// Initialise les données utilisateur
        /// </summary>
        private void InitializeUserData()
        {
            // Remplacez les valeurs ci-dessous par les données de l'utilisateur réelles
            NomTextBlock.Text = Salarie.Nom;
            PrenomTextBlock.Text = Salarie.Prenom;
            TelephoneFixeTextBlock.Text = Salarie.TelephoneFixe;
            TelephoneMobileTextBlock.Text = Salarie.TelephoneMobile;
            EmailTextBlock.Text = Salarie.Email;
            ServiceTextBlock.Text = Service;
            SiteTextBlock.Text = Site;
        }
    }
}
