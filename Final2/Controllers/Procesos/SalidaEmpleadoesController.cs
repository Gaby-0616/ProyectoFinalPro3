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
    public class SalidaEmpleadoesController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: SalidaEmpleadoes
        public ActionResult Index()
        {
            var salidaEmpleadoes = db.SalidaEmpleadoes.Include(s => s.Empleado1);
            return View(salidaEmpleadoes.ToList());
        }

        public ActionResult FechaSalidaForm()
        {
            
            return View();
        }

        public ActionResult FechaSalida(DateTime FechaSalida)
        {

            var Fecha_salida = from a in db.SalidaEmpleadoes
                               where a.FechaSalida == FechaSalida
                               select a;
            return View(Fecha_salida);
        }





        // GET: SalidaEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleadoes.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.Empleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.TipoSalida = new SelectList(db.SalidaEmpleadoes, "IdSalidaEmpleado", "TipoSalida");

            return View();
        }

        // POST: SalidaEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSalidaEmpleado,Empleado,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleado)
        {

            var query = (from a in db.Empleados
                         where a.IdEmpleado == salidaEmpleado.Empleado
                         select a).First();

            query.Estatus = "Inactivo";
            db.SaveChanges();

            if (ModelState.IsValid)
            {

                //var query = (from a in db.Empleados
                //             where a.IdEmpleado == salidaEmpleado.Empleado
                //             select a).First();

                

                db.SalidaEmpleadoes.Add(salidaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", salidaEmpleado.Empleado);
            ViewBag.TipoSalida = new SelectList(db.SalidaEmpleadoes, "IdSalidaEmpleado", "checkTipoSalida");
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleadoes.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", salidaEmpleado.Empleado);
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSalidaEmpleado,Empleado,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", salidaEmpleado.Empleado);
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleadoes.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleadoes.Find(id);
            db.SalidaEmpleadoes.Remove(salidaEmpleado);
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
