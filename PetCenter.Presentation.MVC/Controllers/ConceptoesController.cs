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
    public class ConceptoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Conceptoes
        public ActionResult Index()
        {
            BL_Concepto BLConcepto = new BL_Concepto();
            var conceptos = BLConcepto.ListarConceptos();
            return View(conceptos.ToList());
        }

        // GET: Conceptoes/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Concepto BLConcepto = new BL_Concepto();
            Concepto concepto = BLConcepto.GetConcepto((Int32)id);
            concepto = BLConcepto.EliminarConcepto(concepto);
            if(concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        // GET: Conceptoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conceptoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConceptoId,Nombre,Tipo,TipoConcepto,calculo1,calculo2,calculo3,calculo4,calculo5,calculo6,Operador1,Operador2,Operador3,Operador4,Operador5,Escala1,Escala2,Escala3,Escala4,Escala5,Escala6,Porcentaje1,Porcentaje2,Porcentaje3,Porcentaje4,Porcentaje5,Porcentaje6,Importe1,Importe2,Importe3,Importe4,Importe5,Importe6")] Concepto concepto)
        {
            if(ModelState.IsValid)
            {
                BL_Concepto BLConcepto = new BL_Concepto();
                var conceptos = BLConcepto.GuardarConcepto(concepto);
                return RedirectToAction("Index");
            }

            return View(concepto);
        }

        // GET: Conceptoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Concepto BLConcepto = new BL_Concepto();
            Concepto concepto = BLConcepto.GetConcepto((Int32)id);
            if(concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        // POST: Conceptoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConceptoId,Nombre,Tipo,TipoConcepto,calculo1,calculo2,calculo3,calculo4,calculo5,calculo6,Operador1,Operador2,Operador3,Operador4,Operador5,Escala1,Escala2,Escala3,Escala4,Escala5,Escala6,Porcentaje1,Porcentaje2,Porcentaje3,Porcentaje4,Porcentaje5,Porcentaje6,Importe1,Importe2,Importe3,Importe4,Importe5,Importe6")] Concepto concepto)
        {
            if(ModelState.IsValid)
            {
                BL_Concepto BLConcepto = new BL_Concepto();
                var conceptos = BLConcepto.GuardarConcepto(concepto);
           }
            return View(concepto);
        }

        // GET: Conceptoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Concepto BLConcepto = new BL_Concepto();
            Concepto concepto = BLConcepto.GetConcepto((Int32)id);
            if(concepto == null)
            {
                return HttpNotFound();
            }
            return View(concepto);
        }

        // POST: Conceptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL_Concepto BLConcepto = new BL_Concepto();
            Concepto concepto = BLConcepto.EliminarConcepto(id);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
