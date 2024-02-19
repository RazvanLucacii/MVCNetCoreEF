using Microsoft.AspNetCore.Mvc;
using MVCNetCoreEF.Models;
using MVCNetCoreEF.Repositories;

namespace MVCNetCoreEF.Controllers
{
    public class HospitalController : Controller
    {
        RepositoryHospital repoHosp;

        public HospitalController(RepositoryHospital repo)
        {
            this.repoHosp = repo;
        }
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repoHosp.GetHospitales();
            return View(hospitales);
        }
    }
}
