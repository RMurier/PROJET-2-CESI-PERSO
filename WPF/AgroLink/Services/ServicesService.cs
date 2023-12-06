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
    public class ServicesService : IServices
    {
        private readonly IConfiguration _config;

        public ServicesService()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string appsettingsPath = Path.Combine(projectDirectory, "../appsettings.json");

            var builder = new ConfigurationBuilder()
             .AddJsonFile(appsettingsPath, optional: false, reloadOnChange: true);

            _config = builder.Build();
        }
        /// <summary>
        /// Récupère la liste des services
        /// </summary>
        /// <returns></returns>
        public async Task<List<TService>> GetServices()
        {
            // Effectuez votre requête HTTP ici pour obtenir les données de l'API
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{_config["ApiEndpoint"]}/Services/GetAllServices").Result;
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
        /// Ajoute un service en BDD
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task<bool> AddService(TService service)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Services/AddService"), service).Result;
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
        /// Met à jour un service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task<bool> UpdateService(TService service)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Services/UpdateService"), service).Result;
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
        /// Supprime un service
        /// </summary>
        /// <param name="id">Id du service à supprimer</param>
        /// <returns></returns>
        public async Task<bool> DeleteService(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Services/DeleteService"), id).Result;
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
