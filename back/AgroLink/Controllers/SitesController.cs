using AgroLink.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgroLink.Controllers
{
    [Route("[Controller]")]
    public class SitesController : Controller
    {
        private readonly AgrolinkContext _dbContext;
        public SitesController(AgrolinkContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSites")]
        public List<TSite> GetAllSites()
        {
            return _dbContext.TSites.ToList();
        }
        /// <summary>
        /// Ajoute un site
        /// </summary>
        /// <param name="site"></param>
        [HttpPost("AddSite")]
        public void AddSite([FromBody] TSite site)
        {
            _dbContext.TSites.Add(site);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Met à jour un site
        /// </summary>
        /// <param name="site"></param>
        [HttpPost("UpdateSite")]
        public void UpdateSite([FromBody] TSite site)
        {
            TSite siteToUpdate = _dbContext.TSites.Find(site.Id);
            if (siteToUpdate != null) {
                siteToUpdate.Nom = site.Nom;
                siteToUpdate.RefType = site.RefType;
                _dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Supprime un site
        /// </summary>
        /// <param name="id">Id du site à supprimer</param>
        [HttpPost("DeleteSite")]
        public void DeleteSite([FromBody] int id)
        {
            TSite site = _dbContext.TSites.Find(id);
            _dbContext.TSites.Remove(site);
            _dbContext.SaveChanges();
        }
    }
}
