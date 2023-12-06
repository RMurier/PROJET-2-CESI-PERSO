using AgroLink.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgroLink.Controllers
{
    [Route("[Controller]")]
    public class RolesController : Controller
    {
        private readonly AgrolinkContext _dbContext;
        public RolesController(AgrolinkContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRoles")]
        public List<TRole> GetAllRoles()
        {
            return _dbContext.TRoles.ToList();
        }
    }
}
