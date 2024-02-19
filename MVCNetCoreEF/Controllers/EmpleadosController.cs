using Microsoft.AspNetCore.Mvc;
using MVCNetCoreEF.Models;
using MVCNetCoreEF.Repositories;

namespace MVCNetCoreEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repoEmp;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repoEmp = repo;
        }
        public IActionResult IncrementoSalarial()
        {
            List<string> oficios = this.repoEmp.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View();
        }

        [HttpPost]
        public IActionResult IncrementoSalarial(int incremento, string oficio)
        {
            List<string> oficios = this.repoEmp.GetOficios();
            ViewData["OFICIOS"] = oficios;
            ModelEmpleados model = this.repoEmp.IncrementarSalarioOficios(incremento, oficio);
            return View(model);
        }
    }
}
