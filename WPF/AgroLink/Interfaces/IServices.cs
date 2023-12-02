using AgroLink.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AgroLink.Interfaces
{
    internal interface IServices
    {
        /// <summary>
        /// Récupère la liste des services
        /// </summary>
        /// <returns></returns>
        public Task<List<TService>> GetServices();
        /// <summary>
        /// Ajoute un service en BDD
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public Task<bool> AddService(TService service);
        /// <summary>
        /// Met à jour un service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public Task<bool> UpdateService(TService service);
        /// <summary>
        /// Supprime un service
        /// </summary>
        /// <param name="id">Id du service à supprimer</param>
        /// <returns></returns>
        public Task<bool> DeleteService(int id);
    }
}
