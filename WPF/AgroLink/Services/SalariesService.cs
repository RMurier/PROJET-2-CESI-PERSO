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
    public class SalariesService : ISalaries
    {
        private readonly IConfiguration _config;

        public SalariesService()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string appsettingsPath = Path.Combine(projectDirectory, "../appsettings.json");

            var builder = new ConfigurationBuilder()
             .AddJsonFile(appsettingsPath, optional: false, reloadOnChange: true);

            _config = builder.Build();
        }

        /// <summary>
        /// Récupère la liste des salariés
        /// </summary>
        /// <returns></returns>
        public async Task<List<TSalarie>> GetSalaries()
        {
            // Effectuez votre requête HTTP ici pour obtenir les données de l'API
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{_config["ApiEndpoint"]}/Salaries/GetAllSalaries").Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TSalarie>>(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TSalarie>();
                }
            }
        }
        /// <summary>
        /// Ajoute un salarié en BDD
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public async Task<bool> AddSalarie(TSalarie salarie)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Salaries/AddSalarie"), salarie).Result;
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
        /// Met à jour un salarié
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public async Task<bool> UpdateSalarie(TSalarie salarie)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Salaries/UpdateSalarie"), salarie).Result;
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
        /// Supprime un salarié
        /// </summary>
        /// <param name="id">Id du service à supprimer</param>
        /// <returns></returns>
        public async Task<bool> DeleteSalarie(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Salaries/DeleteSalarie"), id).Result;
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
        /// Récupère les salariés en fonction des filtres
        /// </summary>
        /// <param name="name">Nom / prénom du salarié</param>
        /// <param name="refService">Référence du service</param>
        /// <param name="refSite">Référence du site</param>
        /// <returns></returns>
        public async Task<List<TSalarie>> GetSalariesByFilters(string? name, int? refService, int? refSite)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(new Uri($"{_config["ApiEndpoint"]}/Salaries/GetSalarieByFilters"), new { name = name, refService = refService, refSite = refSite}).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TSalarie>>(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TSalarie>();
                }
            }
        }
    }
}
