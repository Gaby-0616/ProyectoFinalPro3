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
    public class LicenciasController : Controller
    {
        private dbSystem db = new dbSystem();

        // GET: Licencias
        public ActionResult Index()
        {
            var Licencias = db.Licencias.Include(l => l.Empleados);
            return View(Licencias.ToList());
        }

        // GET: Licencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias Licencias = db.Licencias.Find(id);
            if (Licencias == null)
            {
                return HttpNotFound();
            }
            return View(Licencias);
        }

        // GET: Licencias/Create
        public ActionResult Create()
        {
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            return View();
        }

        // POST: Licencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLicencias,Empleados,Desde,Hasta,motivo,Comentarios")] Licencias Licencias)
        {
            if (ModelState.IsValid)
            {
                db.Licencias.Add(Licencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", Licencias.Empleados);
            return View(Licencias);
        }

        // GET: Licencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias Licencias = db.Licencias.Find(id);
            if (Licencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", Licencias.Empleados);
            return View(Licencias);
        }

        // POST: Licencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLicencias,Empleados,Desde,Hasta,motivo,Comentarios")] Licencias Licencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Licencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", Licencias.Empleados);
            return View(Licencias);
        }

        // GET: Licencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencias Licencias = db.Licencias.Find(id);
            if (Licencias == null)
            {
                return HttpNotFound();
            }
            return View(Licencias);
        }

        // POST: Licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licencias Licencias = db.Licencias.Find(id);
            db.Licencias.Remove(Licencias);
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
