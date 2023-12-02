using AgroLink.Interfaces;
using AgroLink.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfNegosud.Services;

namespace AgroLink
{
    /// <summary>
    /// Interaction logic for AdminSites.xaml
    /// </summary>
    public partial class AdminSites : Page
    {
        public SitesService _sites { get; set; }
        public List<TSite> ListeSites { get; set; }
        public AdminSites()
        {
            InitializeComponent();
            _sites = new SitesService();

            ListeSites = _sites.GetSites().Result;
            SitesGrid.ItemsSource = ListeSites;
        }
        /// <summary>
        /// Quand MAJ / ajout d'un site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Site_AddItem(object sender, DataGridRowEditEndingEventArgs e)
        {
            TSite nouveauSite = e.Row.Item as TSite;
            if (nouveauSite != null)
            {
                if
                (
                    nouveauSite.Nom == null ||
                    nouveauSite.RefType == null
                )
                {
                    return;
                }
                if (e.EditAction == DataGridEditAction.Commit && !e.Row.IsNewItem)
                {

                    //Si en édition 
                    await _sites.UpdateSite(nouveauSite);
                    Task<List<TSite>> listSites = _sites.GetSites();
                    SitesGrid.ItemsSource = await listSites;
                    SitesGrid.Items.Refresh();
                }
                else
                {
                    //Si en création
                    await _sites.AddSite(nouveauSite);
                    Task<List<TSite>> listSites = _sites.GetSites();
                    SitesGrid.ItemsSource = await listSites;
                    SitesGrid.Items.Refresh();
                }
            }
        }
        /// <summary>
        /// Supprime un service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteSite(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).Tag;
            await _sites.DeleteSite(Id);
            Task<List<TSite>> listSites = _sites.GetSites();
            SitesGrid.ItemsSource = await listSites;
            SitesGrid.Items.Refresh();
        }
    }
}
