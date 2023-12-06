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
    public partial class AdminSites : Page
    {
        public SitesService _sites { get; set; }
        public List<TSite> ListeSites { get; set; }
        public List<TTypeSite> ListeTypes { get; set; }

        public AdminSites()
        {
            InitializeComponent();
            _sites = new SitesService();
            DataContext = this;
            ListeTypes = _sites.GetTypesSite().Result;
            ListeSites = _sites.GetSites().Result;
            SitesGrid.ItemsSource = ListeSites;
        }

        private async void Site_AddItem(object sender, DataGridRowEditEndingEventArgs e)
        {
            TSite nouveauSite = e.Row.Item as TSite;
            if (nouveauSite != null)
            {
                if (string.IsNullOrEmpty(nouveauSite.Nom) || nouveauSite.RefType == null)
                {
                    return;
                }

                if (e.EditAction == DataGridEditAction.Commit && !e.Row.IsNewItem)
                {
                    await _sites.UpdateSite(nouveauSite);
                    MessageBox.Show("Site modifié");
                    
                }
                else
                {
                    await _sites.AddSite(nouveauSite);
                    MessageBox.Show("Site ajouté");
                }

                ListeSites = await _sites.GetSites();
                SitesGrid.ItemsSource = ListeSites;
                SitesGrid.Items.Refresh();
            }
        }

        private async void DeleteSite(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).Tag;
            await _sites.DeleteSite(Id);
            ListeSites = await _sites.GetSites();
            SitesGrid.ItemsSource = ListeSites;
            SitesGrid.Items.Refresh();
            MessageBox.Show("Site supprimé");
        }
    }
}
