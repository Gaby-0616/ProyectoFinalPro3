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
    public class PermisosesController : Controller
    {
        private dbSystem db = new dbSystem();

        // GET: Permisoses
        public ActionResult Index()
        {
            var Permisos = db.Permisos.Include(p => p.Empleados);
            return View(Permisos.ToList());
        }
        //****************ME EPLOTA***************
        public ActionResult Permisos()
        {
            var hola = (from a in db.Permisos
                        select a).Include(l => l.Empleados);

            return View(hola);

        }


            // GET: Permisoses/Details/5
            public ActionResult Details(int? id){
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos Permisos = db.Permisos.Find(id);
            if (Permisos == null)
            {
                return HttpNotFound();
            }
            return View(Permisos);
        }

        // GET: Permisoses/Create
        public ActionResult Create()
        {
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            return View();
        }

        // POST: Permisoses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPermiso,Empleados,Desde,Hasta,Comentarios")] Permisos Permisos)
        {
            if (ModelState.IsValid)
            {
                db.Permisos.Add(Permisos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", Permisos.Empleados);
            return View(Permisos);
        }

        // GET: Permisoses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos Permisos = db.Permisos.Find(id);
            if (Permisos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", Permisos.Empleados);
            return View(Permisos);
        }

        // POST: Permisoses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPermiso,Empleados,Desde,Hasta,Comentarios")] Permisos Permisos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Permisos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleados = new SelectList(db.Empleados, "IdEmpleado", "Nombre", Permisos.Empleados);
            return View(Permisos);
        }

        // GET: Permisoses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos Permisos = db.Permisos.Find(id);
            if (Permisos == null)
            {
                return HttpNotFound();
            }
            return View(Permisos);
        }

        // POST: Permisoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permisos Permisos = db.Permisos.Find(id);
            db.Permisos.Remove(Permisos);
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
