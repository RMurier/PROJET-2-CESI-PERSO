using AgroLink.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgroLink.Controllers
{
    [Route("[Controller]")]
    public class ServicesController : Controller
    {
        private readonly AgrolinkContext _dbContext;
        public ServicesController(AgrolinkContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllServices")]
        public List<TService> GetAllServices()
        {
            return _dbContext.TServices.ToList();
        }
        /// <summary>
        /// Ajoute un salarié en base de données
        /// </summary>
        /// <param name="salarie"></param>
        [HttpPost("AddService")]
        public void AddService([FromBody] TService service)
        {
            _dbContext.TServices.Add(service);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Met à jour un salarié 
        /// </summary>
        /// <param name="salarie"></param>
        [HttpPost("UpdateService")]
        public void UpdateService([FromBody] TService service)
        {
            TService toUpdate = _dbContext.TServices.Find(service.Id);
            if (toUpdate != null)
            {
                toUpdate.Id = service.Id;
                toUpdate.Nom = service.Nom;
                _dbContext.SaveChanges();
            }
        }
    }
}
