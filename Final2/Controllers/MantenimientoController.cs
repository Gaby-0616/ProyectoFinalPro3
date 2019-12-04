using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final2.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empleados()
        {
            return View("Empleadoes/Index");
        }

        public ActionResult Departamentos()
        {
            return View("Departamentoes/Index");
        }

        public ActionResult Cargos()
        {
            return View("Cargos/Index");
        }
    }
}