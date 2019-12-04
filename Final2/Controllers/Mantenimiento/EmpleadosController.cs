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
    public class EmpleadosController : Controller
    {
        private dbSystem db = new dbSystem();



        public ActionResult EmActivoNombre()
        {
            
            return View();
        }

        
        public ActionResult EmpleadosActivos()
        {
            
                var Activos = from a in db.Empleados
                              where a.Estatus == "A"
                              select a;
                return View(Activos);
  
            
            //return View();
        }

        public ActionResult EmpleadoInactivos()
        {
            var Inactivos = from a in db.Empleados
                          where a.Estatus == "Inactivo"
                          select a;
            return View(Inactivos);
        }

        public ActionResult EntradaEmpleados()
        {
           
            return View();
        }

        public ActionResult EntradaEmpleadosV(DateTime FechaIngreso)
        {
            var Entrada = from a in db.Empleados
                          where a.FechaIngreso == FechaIngreso
                          select a;
            return View(Entrada);
        }

        //Filtar por Departamentos

        public ActionResult DepartamentosForm()
        {


            return View();
        }
        
        public ActionResult DepartamentosFiltro(int Departamentos)
        {
            //var depart = from a in db.Empleados
            //             where a.Departamentos = Departamentos
            //             select a;

            return View();
        }

        // GET: Empleadoses
        public ActionResult Index()
        {
            var Empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos);
            return View(Empleados.ToList());
        }

        // GET: Empleadoses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados Empleados = db.Empleados.Find(id);
            if (Empleados == null)
            {
                return HttpNotFound();
            }
            return View(Empleados);
        }

        // GET: Empleadoses/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1");
            ViewBag.Departamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre");
            //ViewBag.Estado = new SelectList (db.Empleados, )
            return View();
        }

        // POST: Empleadoses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleados Empleados)
        {
            //if (ModelState.IsValid)
            //{
            Empleados.Estatus = "A";
                db.Empleados.Add(Empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1", Empleados.Cargo);
            ViewBag.Departamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", Empleados.Departamentos);
            return View(Empleados);
        }

        // GET: Empleadoses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados Empleados = db.Empleados.Find(id);
            if (Empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1", Empleados.Cargo);
            ViewBag.Departamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", Empleados.Departamentos);
            return View(Empleados);
        }

        // POST: Empleadoses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Codigo,Nombre,Apellido,Telefono,Departamentos,Cargo,FechaIngreso,Salario,Estatus")] Empleados Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1", Empleados.Cargo);
            ViewBag.Departamentos = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", Empleados.Departamentos);
            return View(Empleados);
        }

        // GET: Empleadoses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados Empleados = db.Empleados.Find(id);
            if (Empleados == null)
            {
                return HttpNotFound();
            }
            return View(Empleados);
        }

        // POST: Empleadoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados Empleados = db.Empleados.Find(id);
            db.Empleados.Remove(Empleados);
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
