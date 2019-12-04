using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final2.Models;

namespace Final2.Controllers
{
    public class SalidaEmpleadosesController : Controller
    {
        private dbSystem db = new dbSystem();

        // GET: SalidaEmpleadoses
        public ActionResult Index()
        {
            var salidaEmpleadoses = db.SalidaEmpleado.Include(s => s.Empleado);
            return View(salidaEmpleadoses.ToList());
        }

        public ActionResult FechaSalidaForm()
        {
            
            return View();
        }

        public ActionResult FechaSalida(DateTime FechaSalida)
        {

            var Fecha_salida = from a in db.SalidaEmpleado
                               where a.FechaSalida == FechaSalida
                               select a;
            return View(Fecha_salida);
        }





        // GET: SalidaEmpleadoses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleados = db.SalidaEmpleado.Find(id);
            if (salidaEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleados);
        }

        // GET: SalidaEmpleadoses/Create
        public ActionResult Create()
        {
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.TipoSalida = new SelectList(db.SalidaEmpleado, "IdSalidaEmpleados", "TipoSalida");

            return View();
        }

        // POST: SalidaEmpleadoses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSalidaEmpleados,Empleados,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleados)
        {

            var query = (from a in db.Empleados
                         where a.IdEmpleado == salidaEmpleados.Empleado
                         select a).First();

            query.Estatus = "Inactivo";
            db.SaveChanges();

            if (ModelState.IsValid)
            {

                //var query = (from a in db.Empleados
                //             where a.IdEmpleado == salidaEmpleados.Empleados
                //             select a).First();

                

                db.SalidaEmpleado.Add(salidaEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", salidaEmpleados.Empleado);
            ViewBag.TipoSalida = new SelectList(db.SalidaEmpleado, "IdSalidaEmpleados", "checkTipoSalida");
            return View(salidaEmpleados);
        }

        // GET: SalidaEmpleadoses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleados = db.SalidaEmpleado.Find(id);
            if (salidaEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", salidaEmpleados.Empleado);
            return View(salidaEmpleados);
        }

        // POST: SalidaEmpleadoses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSalidaEmpleados,Empleados,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", salidaEmpleados.Empleado);
            return View(salidaEmpleados);
        }

        // GET: SalidaEmpleadoses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleados = db.SalidaEmpleado.Find(id);
            if (salidaEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleados);
        }

        // POST: SalidaEmpleadoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmpleado salidaEmpleados = db.SalidaEmpleado.Find(id);
            db.SalidaEmpleado.Remove(salidaEmpleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
