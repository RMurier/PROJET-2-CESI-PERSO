using AgroLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroLink.Interfaces
{
    internal interface IServices
    {
        public Task<List<TService>> GetServices();
    }
}
