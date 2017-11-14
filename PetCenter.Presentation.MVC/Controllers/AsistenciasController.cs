using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetCenter.Common.Core.Entities;
using PetCenter.Infrastucture.Domain.Main;
using PetCenter.Presentation.MVC.Models;

namespace PetCenter.Presentation.MVC.Controllers
{
    public class AsistenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asistencias
        public ActionResult Index()
        {
            BL_Asistencia BLAsistencia = new BL_Asistencia();


            return View(BLAsistencia.ListarAsistencias().ToList());
        }

        public ActionResult ProcesarAsistencias()
        {
            BL_Asistencia BLAsistencia = new BL_Asistencia();
            var a = BLAsistencia.ProcesarAsistencia("11", "2017");


            return RedirectToAction("Index");
        }

        // GET: Asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado");
            return View();
        }

        // POST: Asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsistenciaId,EmpleadoId,Fecha,FechaIngreso,FechaSalida")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencias.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado", asistencia.EmpleadoId);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado", asistencia.EmpleadoId);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsistenciaId,EmpleadoId,Fecha,FechaIngreso,FechaSalida")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado", asistencia.EmpleadoId);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            db.Asistencias.Remove(asistencia);
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
