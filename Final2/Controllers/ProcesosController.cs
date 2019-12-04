using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final2.Controllers
{
    public class ProcesosController : Controller
    {
        // GET: Procesos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nominas()
        {
            return View("Nominas/Create");
        }
        public ActionResult Licencias()
        {
            return View("Licencias/Create");
        }
        public ActionResult Permisos()
        {
            return View("Permisos/Create");
        }
        public ActionResult SalidaEmpleados()
        {
            return View("SalidaEmpleados/Create");
        }
        public ActionResult Vacaciones()
        {
            return View("Vacaciones/Create");
        }
    }
}