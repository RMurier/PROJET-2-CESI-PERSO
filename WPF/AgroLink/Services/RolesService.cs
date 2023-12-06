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
    public class RolesService : IRoles
    {
        private readonly IConfiguration _config;

        public RolesService()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string appsettingsPath = Path.Combine(projectDirectory, "../appsettings.json");

            var builder = new ConfigurationBuilder()
             .AddJsonFile(appsettingsPath, optional: false, reloadOnChange: true);

            _config = builder.Build();
        }

        /// <summary>
        /// Récupère la liste des roles
        /// </summary>
        /// <returns></returns>
        public async Task<List<TRole>> GetRoles()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{_config["ApiEndpoint"]}/Roles/GetAllRoles").Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TRole>>(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la requête API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TRole>();
                }
            }
        }
    }
}
