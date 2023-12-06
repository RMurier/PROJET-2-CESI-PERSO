using AgroLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for UserSearchList.xaml
    /// </summary>
    public partial class UserSearchList : Page
    {
        private List<TSalarie> listeSalarie;
        private List<TSalarieWithAllInfos> listeSalarieWithAllInfos;
        private readonly ServicesService _service;
        private readonly SitesService _site;
        private List<TSite> ListeSite { get; set; }
        private List<TService> ListeService { get; set; }

        public UserSearchList(List<TSalarie> salarieList)
        {
            InitializeComponent();
            listeSalarie = salarieList;
            _site = new SitesService();
            _service = new ServicesService();

            ListeService = _service.GetServices().Result;
            ListeSite = _site.GetSites().Result;
            listeSalarieWithAllInfos = new List<TSalarieWithAllInfos>();
            foreach(TSalarie salarie in listeSalarie)
            {
                TSalarieWithAllInfos newUser = new TSalarieWithAllInfos();
                newUser.Id = salarie.Id;
                newUser.Email = salarie.Email;
                newUser.Nom = salarie.Nom;
                newUser.Prenom = salarie.Prenom;
                newUser.Site = ListeSite.Where(x => x.Id == salarie.RefSite).First().Nom;
                newUser.RefSite = salarie.RefSite;
                newUser.Service = ListeService.Where(x => x.Id == salarie.RefService).First().Nom;
                newUser.RefService = salarie.RefService;
                newUser.RefRole = salarie.RefRole;
                newUser.TelephoneFixe = salarie.TelephoneFixe;
                newUser.TelephoneMobile = salarie.TelephoneMobile;
                listeSalarieWithAllInfos.Add(newUser);
            }
            salarieDataGrid.ItemsSource = listeSalarieWithAllInfos;
           
        }
        /// <summary>
        /// Quand appuie sur le bouton pour séléctionner le salarié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectButtonClick(object sender, RoutedEventArgs e)
        {
            // Récupérez le salarié associé au bouton sélectionné
            Button button = (Button)sender;
            TSalarie selectedSalarie = (TSalarie)button.Tag;

            // Faites quelque chose avec le salarié sélectionné, par exemple, affichez un message
            NavigationService.Navigate(new UserInformations(selectedSalarie));
        }
    }
}
