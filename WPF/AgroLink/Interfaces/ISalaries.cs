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
    internal interface ISalaries
    {
        /// <summary>
        /// Récupère la liste des salariés
        /// </summary>
        /// <returns></returns>
        public Task<List<TSalarie>> GetSalaries();
        /// <summary>
        /// Ajoute un salarié en BDD
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public Task<bool> AddSalarie(TSalarie salarie);
        /// <summary>
        /// Met à jour un salarié
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public Task<bool> UpdateSalarie(TSalarie salarie);
        /// <summary>
        /// Supprime un salarié
        /// </summary>
        /// <param name="id">Id du service à supprimer</param>
        /// <returns></returns>
        public Task<bool> DeleteSalarie(int id);
    }
}
