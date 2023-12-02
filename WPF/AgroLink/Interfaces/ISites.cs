
using AgroLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroLink.Interfaces
{
    internal interface ISites
    {
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        public Task<List<TSite>> GetSites();
        /// <summary>
        /// Ajoute un site en BDD
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public Task<bool> AddSite(TSite site);
        /// <summary>
        /// Met à jour un site
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public Task<bool> UpdateSite(TSite site);
        /// <summary>
        /// Supprime un site
        /// </summary>
        /// <param name="id">Id du site à supprimer</param>
        /// <returns></returns>
        public Task<bool> DeleteSite(int id);
        }
}
