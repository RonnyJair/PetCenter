using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetCenter.Common.Core.Entities;
using PetCenter.Presentation.MVC.Models;

namespace PetCenter.Presentation.MVC.Controllers
{
    public class FaltasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Faltas
        public ActionResult Index()
        {
            var faltas = db.Faltas.Include(f => f.Empleado).Include(f => f.Justificacion);
            return View(faltas.ToList());
        }

        // GET: Faltas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falta falta = db.Faltas.Find(id);
            if (falta == null)
            {
                return HttpNotFound();
            }
            return View(falta);
        }

        // GET: Faltas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado");
            ViewBag.JustificacionId = new SelectList(db.Justificacions, "JustificacionId", "Descripcion");
            return View();
        }

        // POST: Faltas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaltaId,EmpleadoId,JustificacionId,Fecha,FechaInicio,FechaTermino,CantidadDias")] Falta falta)
        {
            if (ModelState.IsValid)
            {
                db.Faltas.Add(falta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado", falta.EmpleadoId);
            ViewBag.JustificacionId = new SelectList(db.Justificacions, "JustificacionId", "Descripcion", falta.JustificacionId);
            return View(falta);
        }

        // GET: Faltas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falta falta = db.Faltas.Find(id);
            if (falta == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado", falta.EmpleadoId);
            ViewBag.JustificacionId = new SelectList(db.Justificacions, "JustificacionId", "Descripcion", falta.JustificacionId);
            return View(falta);
        }

        // POST: Faltas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaltaId,EmpleadoId,JustificacionId,Fecha,FechaInicio,FechaTermino,CantidadDias")] Falta falta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(falta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "CodigoEmpleado", falta.EmpleadoId);
            ViewBag.JustificacionId = new SelectList(db.Justificacions, "JustificacionId", "Descripcion", falta.JustificacionId);
            return View(falta);
        }

        // GET: Faltas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falta falta = db.Faltas.Find(id);
            if (falta == null)
            {
                return HttpNotFound();
            }
            return View(falta);
        }

        // POST: Faltas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Falta falta = db.Faltas.Find(id);
            db.Faltas.Remove(falta);
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
