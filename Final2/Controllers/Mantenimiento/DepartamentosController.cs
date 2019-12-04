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
    public class DepartamentosController : Controller
    {
        private dbSystem db = new dbSystem();

        // GET: Departamentoses
        public ActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }


        public ActionResult ListaDepartamentos()
        {

            var Lista = from a in db.Departamentos
                        select a;

            return View(Lista);
        }



        // GET: Departamentoses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos Departamentos = db.Departamentos.Find(id);
            if (Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(Departamentos);
        }

        // GET: Departamentoses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentoses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamentos Departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Departamentos.Add(Departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Departamentos);
        }

        // GET: Departamentoses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos Departamentos = db.Departamentos.Find(id);
            if (Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(Departamentos);
        }

        // POST: Departamentoses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDepartamento,CodigoDep,Nombre,Encargado")] Departamentos Departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Departamentos);
        }

        // GET: Departamentoses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos Departamentos = db.Departamentos.Find(id);
            if (Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(Departamentos);
        }

        // POST: Departamentoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamentos Departamentos = db.Departamentos.Find(id);
            db.Departamentos.Remove(Departamentos);
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
