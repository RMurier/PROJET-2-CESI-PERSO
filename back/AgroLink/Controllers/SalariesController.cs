using AgroLink.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgroLink.Controllers
{
    [Route("[Controller]")]
    public class SalariesController : Controller
    {
        private readonly AgrolinkContext _dbContext;
        public SalariesController(AgrolinkContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Récupère la liste des sites
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSalaries")]
        public List<TSalarie> GetAllSalaries()
        {
            return _dbContext.TSalaries.ToList();
        }
        /// <summary>
        /// Ajoute un salarié en base de données
        /// </summary>
        /// <param name="salarie"></param>
        [HttpPost("AddSalarie")]
        public void AddSalarie([FromBody] TSalarie salarie) {
            _dbContext.TSalaries.Add(salarie);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Met à jour un salarié 
        /// </summary>
        /// <param name="salarie"></param>
        [HttpPost("UpdateSalarie")]
        public void UpdateSalarie([FromBody] TSalarie salarie)
        {
            TSalarie toUpdate = _dbContext.TSalaries.Find(salarie.Id);
            if (toUpdate != null)
            {
                toUpdate.Id = salarie.Id;
                toUpdate.Nom = salarie.Nom;
                toUpdate.Prenom = salarie.Prenom;
                toUpdate.TelephoneFixe = salarie.TelephoneFixe;
                toUpdate.TelephoneMobile = salarie.TelephoneMobile;
                toUpdate.Email = salarie.Email;
                toUpdate.RefService = salarie.RefService;
                toUpdate.RefSite = salarie.RefSite;
                toUpdate.RefRole = salarie.RefRole;
                _dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Supprime un salarié
        /// </summary>
        /// <param name="id">Id du salarié à supprimer</param>
        [HttpPost("DeleteSalarie")]
        public void DeleteService([FromBody] int id)
        {
            TSalarie salarie = _dbContext.TSalaries.Find(id);
            _dbContext.TSalaries.Remove(salarie);
            _dbContext.SaveChanges();
        }
    }
}
