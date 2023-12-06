using System.Net.Http;
using Microsoft.Extensions.Configuration;
using AgroLink.Interfaces;
using AgroLink.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http.Json;

namespace WpfNegosud.Services
{
    public class SitesService : ISites
    {
        private readonly IConfiguration _config;

        public SitesService()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string appsettingsPath = Path.Combine(projectDirectory, "../appsettings.json");

            var builder = new ConfigurationBuilder()
             .AddJsonFile(appsettingsPath, optional: false, reloadOnChange: true);

            _config = builder.Build();
        }
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        public async Task<List<TSite>> GetSites()
        {
            // Effectuez votre requête HTTP ici pour obtenir les données de l'API
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{_config["ApiEndpoint"]}/Sites/GetAllSites").Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TSite>>(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TSite>();
                }
            }
        }
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        public async Task<List<TTypeSite>> GetTypesSite()
        {
            // Effectuez votre requête HTTP ici pour obtenir les données de l'API
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{_config["ApiEndpoint"]}/Sites/GetAllTypesSite").Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TTypeSite>>(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TTypeSite>();
                }
            }
        }
        /// <summary>
        /// Ajoute un site en BDD
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public async Task<bool> AddSite(TSite site)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Sites/AddSite"), site).Result;
                    response.EnsureSuccessStatusCode();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }
        /// <summary>
        /// Met à jour un site
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public async Task<bool> UpdateSite(TSite site)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Sites/UpdateSite"), site).Result;
                    response.EnsureSuccessStatusCode();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }
        /// <summary>
        /// Supprime un site
        /// </summary>
        /// <param name="id">Id du site à supprimer</param>
        /// <returns></returns>
        public async Task<bool> DeleteSite(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Sites/DeleteSite"), id).Result;
                    response.EnsureSuccessStatusCode();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }
    }
}
