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

        public IActionResult Details(int idHospital)
        {
            Hospital hospital = this.repoHosp.FindHospital(idHospital);
            return View(hospital);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repoHosp.InsertHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(int idHospital)
        {
            Hospital hospital = this.repoHosp.FindHospital(idHospital);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Modificar(Hospital hospital)
        {
            this.repoHosp.ModficarHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int idHospital)
        {
            this.repoHosp.DeleteHospital(idHospital);
            return RedirectToAction("Index");
        }
    }
}
