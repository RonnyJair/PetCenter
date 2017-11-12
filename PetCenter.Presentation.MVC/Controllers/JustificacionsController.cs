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
    public class JustificacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Justificacions
        public ActionResult Index()
        {
            var justificacions = db.Justificacions.Include(j => j.Falta);
            return View(justificacions.ToList());
        }

        // GET: Justificacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacion justificacion = db.Justificacions.Find(id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        // GET: Justificacions/Create
        public ActionResult Create()
        {
            ViewBag.FaltaId = new SelectList(db.Faltas, "FaltaId", "FaltaId");
            return View();
        }

        // POST: Justificacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JustificacionId,FaltaId,Descripcion,Documento,Estado,UsuarioAprueba,FechaAprobacion,UsuarioNiega,FechaNegacion")] Justificacion justificacion)
        {
            if (ModelState.IsValid)
            {
                db.Justificacions.Add(justificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FaltaId = new SelectList(db.Faltas, "FaltaId", "FaltaId", justificacion.FaltaId);
            return View(justificacion);
        }

        // GET: Justificacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacion justificacion = db.Justificacions.Find(id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaltaId = new SelectList(db.Faltas, "FaltaId", "FaltaId", justificacion.FaltaId);
            return View(justificacion);
        }

        // POST: Justificacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JustificacionId,FaltaId,Descripcion,Documento,Estado,UsuarioAprueba,FechaAprobacion,UsuarioNiega,FechaNegacion")] Justificacion justificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(justificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FaltaId = new SelectList(db.Faltas, "FaltaId", "FaltaId", justificacion.FaltaId);
            return View(justificacion);
        }

        // GET: Justificacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacion justificacion = db.Justificacions.Find(id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        // POST: Justificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Justificacion justificacion = db.Justificacions.Find(id);
            db.Justificacions.Remove(justificacion);
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
