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
using PagedList;

namespace PetCenter.Presentation.MVC.Controllers
{
    [Authorize]
    public class ConceptoesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Conceptoes
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
             ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if(searchString != null)            
                page = 1;
            else
                searchString = currentFilter;
            
            ViewBag.CurrentFilter = searchString;

            BL_Concepto BLConcepto = new BL_Concepto();
           
            try
            {
                var conceptos = searchString == null ? BLConcepto.ListarConceptos() : BLConcepto.ListarConceptosFiltro(searchString);

                switch(sortOrder)
                {
                    case "Nombre":
                        conceptos = conceptos.OrderByDescending(s => s.Nombre).ToList();
                        break;
                }

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(conceptos.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                return null;
            }
           
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

                Success(string.Format("El Concepto {0} a sido creado perfectamente", conceptos.Nombre), true);

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
            Concepto concepto = BLConcepto.GetConcepto((Int32)id);
            concepto = BLConcepto.EliminarConcepto(concepto);

            return RedirectToAction("Index");
        }

        // GET: Conceptoes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Aprobar(int? id)
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
        [Authorize(Roles = "Admin")]
        public ActionResult Aprobar([Bind(Include = "ConceptoId,Nombre,Tipo,TipoConcepto,calculo1,calculo2,calculo3,calculo4,calculo5,calculo6,Operador1,Operador2,Operador3,Operador4,Operador5,Escala1,Escala2,Escala3,Escala4,Escala5,Escala6,Porcentaje1,Porcentaje2,Porcentaje3,Porcentaje4,Porcentaje5,Porcentaje6,Importe1,Importe2,Importe3,Importe4,Importe5,Importe6")] Concepto concepto)
        {
            if(ModelState.IsValid)
            {
                BL_Concepto BLConcepto = new BL_Concepto();
                concepto = BLConcepto.GetConcepto((Int32)concepto.ConceptoId);
                concepto.Aprobado = true;
                var conceptos = BLConcepto.GuardarConcepto(concepto);
            }
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
