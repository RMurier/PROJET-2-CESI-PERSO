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
    internal interface IRoles
    {
        /// <summary>
        /// Récupère la liste des roles
        /// </summary>
        /// <returns></returns>
        public Task<List<TRole>> GetRoles();
    }
}
