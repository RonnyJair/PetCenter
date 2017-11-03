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
using PetCenter.Infrastucture.Domain.Main;

namespace PetCenter.Presentation.MVC.Controllers
{
    public class PlanillasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Planillas
        public ActionResult Index()
        {
            var planillas = db.Planillas;
            return View(planillas.ToList());
        }

        // GET: Planillas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planilla planilla = db.Planillas.Find(id);
            if (planilla == null)
            {
                return HttpNotFound();
            }
            return View(planilla);
        }

        // GET: Planillas/Create
        public ActionResult Create()
        {
            ViewBag.SueldoMinimoId = new SelectList(db.SueldoMinimoes, "SueldoMinimoId", "Nombre");
            ViewBag.UitId = new SelectList(db.Uits, "UitId", "Nombre");
            return View();
        }

        // POST: Planillas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanillaId,EmpleadoId_Aprueba,UitId,SueldoMinimoId,Aprobado,Pagado")] Planilla planilla)
        {
            if (ModelState.IsValid)
            {
                db.Planillas.Add(planilla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SueldoMinimoId = new SelectList(db.SueldoMinimoes, "SueldoMinimoId", "Nombre", planilla.SueldoMinimoId);
            ViewBag.UitId = new SelectList(db.Uits, "UitId", "Nombre", planilla.UitId);
            return View(planilla);
        }

        // GET: Planillas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planilla planilla = db.Planillas.Find(id);
            if (planilla == null)
            {
                return HttpNotFound();
            }
            ViewBag.SueldoMinimoId = new SelectList(db.SueldoMinimoes, "SueldoMinimoId", "Nombre", planilla.SueldoMinimoId);
            ViewBag.UitId = new SelectList(db.Uits, "UitId", "Nombre", planilla.UitId);
            return View(planilla);
        }

        // POST: Planillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanillaId,EmpleadoId_Aprueba,UitId,SueldoMinimoId,Aprobado,Pagado")] Planilla planilla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planilla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SueldoMinimoId = new SelectList(db.SueldoMinimoes, "SueldoMinimoId", "Nombre", planilla.SueldoMinimoId);
            ViewBag.UitId = new SelectList(db.Uits, "UitId", "Nombre", planilla.UitId);
            return View(planilla);
        }

        // GET: Planillas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planilla planilla = db.Planillas.Find(id);
            if (planilla == null)
            {
                return HttpNotFound();
            }
            return View(planilla);
        }

        // POST: Planillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planilla planilla = db.Planillas.Find(id);
            db.Planillas.Remove(planilla);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /***********/
        [HttpPost]
        public ActionResult Eliminar(String ano, String mes)
        {
            DateTime Fecha = new DateTime();
            TempData["ano"] = ano;
            TempData["mes"] = mes;
            try
            {
                Fecha = DateTime.ParseExact(ano + "-" + mes + "-01 00:00:00,000", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                Fecha = Fecha.AddMonths(1).AddDays(-1);
                BL_Planilla BLPlanilla = new BL_Planilla();
                Planilla Planilla = BLPlanilla.getPlanilla(Fecha);
                if (Planilla == null)
                {
                    TempData["errorExiste"] = true;
                }
                else
                {
                    if (Planilla.Aprobado)
                    {
                        TempData["errorAprobado"] = true;
                    }
                    else
                    {
                        BLPlanilla.delPlanilla(Planilla);
                        TempData["borrado"] = true;
                    }
                }
                return RedirectToAction("ProcesarPlanilla");

            }
            catch (Exception es)
            {
                return RedirectToAction("ProcesarPlanilla");
            }
        }

        /***********/
        [HttpPost]
        public ActionResult Consultar(String ano1, String mes1)
        {
            DateTime Fecha = new DateTime();
            TempData["ano"] = ano1;
            TempData["mes"] = mes1;
            try
            {
                Fecha = DateTime.ParseExact(ano1 + "-" + mes1 + "-01 00:00:00,000", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                Fecha = Fecha.AddMonths(1).AddDays(-1);
                BL_Planilla BLPlanilla = new BL_Planilla();
                Planilla Planilla = BLPlanilla.getPlanilla(Fecha);
                if (Planilla == null)
                {
                    return RedirectToAction("ProcesarPlanilla");
                }
                else
                {
                    return RedirectToAction("PlanillaProcesada", new { Fecha = Fecha, Idplanilla = Planilla.PlanillaId });
                }

            }
            catch (Exception es)
            {
                return RedirectToAction("ProcesarPlanilla");
            }
        }

        /***********/

        public ActionResult ProcesarPlanilla()
        {
            BL_Empleado BLEmpleado = new BL_Empleado();
            var empleadoes = BLEmpleado.ListarEmpleadosActivos();
            ViewBag.ano = "";
            ViewBag.mes = "";
            if (TempData["ano"] != null)
            {
                ViewBag.ano = TempData["ano"];
            }
            if (TempData["mes"] != null)
            {
                ViewBag.mes = TempData["mes"];
            }
            if (TempData["errorPro"] != null)
            {
                ViewBag.errorPro = TempData["errorPro"];
            }
            if (TempData["errorExiste"] != null)
            {
                ViewBag.errorExiste = TempData["errorExiste"];
            }
            if (TempData["errorAprobado"] != null)
            {
                ViewBag.errorAprobado = TempData["errorAprobado"];
            }
            if (TempData["borrado"] != null)
            {
                ViewBag.borrado = TempData["borrado"];
            }


            TempData.Clear();
            return View(empleadoes);
        }

        // POST: Planillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcesarPlanilla(String ano, String mes)
        {
            DateTime Fecha = new DateTime();
            try
            {
                Fecha = DateTime.ParseExact(ano + "-" + mes + "-01 00:00:00,000", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                Fecha = Fecha.AddMonths(1).AddDays(-1);
                BL_Planilla BLPlanilla = new BL_Planilla();
                Planilla Planilla = BLPlanilla.getPlanilla(Fecha);
                TempData["ano"] = ano;
                TempData["mes"] = mes;
                if (Planilla == null)
                {
                    Planilla = BLPlanilla.ProcesarPlanilla(Fecha);
                    TempData["procesado"] = true;
                    return RedirectToAction("PlanillaProcesada", new { Fecha = Fecha, Idplanilla = Planilla.PlanillaId });
                }
                else
                {
                    TempData["errorPro"] = true;
                    return RedirectToAction("ProcesarPlanilla");
                }

            }
            catch (Exception es)
            {
                return RedirectToAction("ErrorProcesarPlanilla", new { Fecha = Fecha });
            }
        }

        public ActionResult PlanillaProcesada(DateTime? Fecha, Int32 Idplanilla)
        {
            BL_Planilla BLPlanilla = new BL_Planilla();

            Planilla planilla = BLPlanilla.UltimaPlanilla((DateTime)Fecha, Idplanilla);
            if (TempData["procesado"] != null)
            {
                ViewBag.procesado = TempData["procesado"];
            }
            ViewBag.ano = Fecha.Value.Year;
            ViewBag.mes = "0" + Fecha.Value.Month;
            ViewBag.mes = ViewBag.mes.Substring(ViewBag.mes.Length - 2, 2);

            BL_Empleado BLEmpleado = new BL_Empleado();
            var empleadoes = BLEmpleado.ListarEmpleadosActivosRecalculados(planilla);
            TempData.Clear();
            return View(empleadoes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanillaProcesada()
        {
            return RedirectToAction("PlanillaProcesada");
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
