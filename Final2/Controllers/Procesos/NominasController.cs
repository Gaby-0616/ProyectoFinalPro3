﻿using System;
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
    public class NominasController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();




        public ActionResult TotalNomina()
        {

            ViewBag.Total = db.Empleados.Sum(m => m.Salario);
            //var Total = from a in db.Empleados
            //            where a.
                
            return View();

        }


        // GET: Nominas
        public ActionResult Index()
        {
            return View(db.Nominas.ToList());
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            ViewBag.Total = db.Empleados.Sum(m => m.Salario);
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNomina,Año,Mes,MontoTotal")] Nomina nomina)
        {
            var Total = db.Empleados.Sum(m => m.Salario);
            var query = (from a in db.Nominas
                         select a).First();

            query.MontoTotal = 1999; //convertir a double
            if (ModelState.IsValid)
            {
                
                db.Nominas.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNomina,Año,Mes,MontoTotal")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.Nominas.Find(id);
            db.Nominas.Remove(nomina);
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
