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
    public class EmpleadoesController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();



        public ActionResult EmActivoNombre()
        {
            
            return View();
        }

        
        public ActionResult EmpleadosActivos(string Nombre)
        {
            if (Nombre == null)
            {
                var Activos = from a in db.Empleados
                              where a.Estatus == "Activo"
                              select a;
                return View(Activos);
            }
            else
            {
                var Activos = from a in db.Empleados
                              where a.Estatus == "Activo" && a.Nombre == Nombre
                              select a;
                return View(Activos);
            }

            
            //return View();
        }

        public ActionResult EmpleadoInactivos()
        {
            var Inactivos = from a in db.Empleados
                          where a.Estatus == "Inactivo"
                          select a;
            return View(Inactivos);
        }

        public ActionResult EntradaEmpleado()
        {
           
            return View();
        }

        public ActionResult EntradaEmpleadoV(DateTime FechaIngreso)
        {
            var Entrada = from a in db.Empleados
                          where a.FechaIngreso == FechaIngreso
                          select a;
            return View(Entrada);
        }

        //Filtar por departamento

        public ActionResult DepartamentoForm()
        {


            return View();
        }
        
        public ActionResult DepartamentoFiltro(int departamento)
        {
            //var depart = from a in db.Empleados
            //             where a.Departamento = departamento
            //             select a;

            return View();
        }

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargo1).Include(e => e.Departamento1);
            return View(empleados.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1");
            ViewBag.Departamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre");
            //ViewBag.Estado = new SelectList (db.Empleados, )
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Codigo,Nombre,Apellido,Telefono,Departamento,Cargo,FechaIngreso,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", empleado.Departamento);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", empleado.Departamento);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Codigo,Nombre,Apellido,Telefono,Departamento,Cargo,FechaIngreso,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "IdCargos", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", empleado.Departamento);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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
