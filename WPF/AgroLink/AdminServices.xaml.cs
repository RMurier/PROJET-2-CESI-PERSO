using AgroLink.Interfaces;
using AgroLink.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for AdminServices.xaml
    /// </summary>
    public partial class AdminServices : Page
    {
        public ServicesService _services { get; set; }
        public SalariesService _salaries { get; set; }
        public List<TService> ListServices { get; set; }
        public AdminServices()
        {
            InitializeComponent();
            _services = new ServicesService();
            _salaries = new SalariesService();

            ListServices = _services.GetServices().Result;
            ServicesGrid.ItemsSource = ListServices;
        }
        /// <summary>
        /// Quand MAJ / ajout d'un service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Service_AddItem(object sender, DataGridRowEditEndingEventArgs e)
        {
            TService nouveauService = e.Row.Item as TService;
            if (nouveauService != null)
            {
                if
                (
                    string.IsNullOrEmpty(nouveauService.Nom)
                )
                {
                    MessageBox.Show("Merci de remplir toutes les informations avant d'ajouter/modifier un service.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (e.EditAction == DataGridEditAction.Commit && !e.Row.IsNewItem)
                {

                    //Si en édition 
                    await _services.UpdateService(nouveauService);
                    MessageBox.Show("Service modifié");
                }
                else
                {
                    //Si en création
                    await _services.AddService(nouveauService);
                    MessageBox.Show("Service ajouté");
                }
                Task<List<TService>> listServices = _services.GetServices();
                ServicesGrid.ItemsSource = await listServices;
                ServicesGrid.Items.Refresh();
            }
        }
        /// <summary>
        /// Supprime un service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteService(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).Tag;
            List<TSalarie> salaries = _salaries.GetSalaries().Result;
            if(salaries.Where(x => x.RefService == Id).Any())
            {
                MessageBox.Show("Merci de changer le service de tous les utilisateurs liées à ce service avant de le supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            await _services.DeleteService(Id);
            Task<List<TService>> listServices = _services.GetServices();
            ServicesGrid.ItemsSource = await listServices;
            ServicesGrid.Items.Refresh();
            MessageBox.Show("Site supprimé");
        }
    }
}
