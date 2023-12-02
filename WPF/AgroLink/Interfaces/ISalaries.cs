using AgroLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroLink.Interfaces
{
    internal interface ISalaries
    {
        public Task<List<TSalarie>> GetSalaries();
        public Task<bool> AddSalarie(TSalarie salarie);
        public Task<bool> UpdateSalarie(TSalarie salarie);
    }
}
