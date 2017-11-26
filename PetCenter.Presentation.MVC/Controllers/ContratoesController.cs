using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PetCenter.Common.Core.Entities;
using PetCenter.Infrastucture.Domain.Main;
using PetCenter.Presentation.MVC.Models;

namespace PetCenter.Presentation.MVC.Controllers
{
    [Authorize]
    public class ContratoesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contratoes
        public ActionResult Index()
        {
            BL_Contrato BLConcepto = new BL_Contrato();
            var contratoes = BLConcepto.ListarContratos();
            return View(contratoes.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Contrato BLContrato = new BL_Contrato();
            Contrato contrato = BLContrato.GetContrato((Int32)id);
            if(contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            Contrato contrato = new Contrato();
            BL_Empleado BLEmpleado = new BL_Empleado();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "XNombreCompleto");
            return View(contrato);
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,EmpleadoId,EsAfp,SueldoBase,UbigeoId,JornadaTrabajo,RenumeracionLetra,FechaInicio,FechaTermino,Estado")] Contrato contrato)
        {
            if(ModelState.IsValid)
            {
                BL_Contrato BLContrato = new BL_Contrato();
                 var path = Path.Combine(Server.MapPath("~/Temp"), "Contrato_ID_" + contrato.EmpleadoId.ToString());
                contrato.RutaArchivo = path;
                var contratos = BLContrato.GuardarContrato(contrato);
                TempData["contratomsg"] = string.Format("El contrato {0} se ha creado correctamente", contrato.ContratoId);
                return RedirectToAction("Index");
            }

            BL_Empleado BLEmpleado = new BL_Empleado();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "XNombreCompleto");
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Contrato BLContrato = new BL_Contrato();
            Contrato contrato = BLContrato.GetContrato((Int32)id);
            if(contrato == null)
            {
                return HttpNotFound();
            }
            BL_Empleado BLEmpleado = new BL_Empleado();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "XNombreCompleto");
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,EmpleadoId,EsAfp,SueldoBase,UbigeoId,JornadaTrabajo,RenumeracionLetra,FechaInicio,FechaTermino,Estado")] Contrato contrato)
        {
            if(ModelState.IsValid)
            {
                BL_Contrato BLContrato = new BL_Contrato();
                var Contratos = BLContrato.GuardarContrato(contrato);
                return RedirectToAction("Index");
            }
            BL_Empleado BLEmpleado = new BL_Empleado();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "XNombreCompleto");
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Contrato BLContrato = new BL_Contrato();
            Contrato contrato = BLContrato.GetContrato((Int32)id);
            if(contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL_Contrato BLContrato = new BL_Contrato();
            Contrato contrato = BLContrato.GetContrato((Int32)id);
            var contratos = BLContrato.EliminarContrato(contrato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> UploadHomeReport(string id)
        {
            try
            {
                foreach(string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if(fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = "Contrato_ID_" + id;
                        var path = Path.Combine(Server.MapPath("~/Temp"), fileName);
                        using(var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch(Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error al subir archivo :(");
            }

            return Json("Archivo Cargado");
        }

        [HttpGet]
         public ActionResult Download(string id)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Temp"), "Contrato_ID_" + id);
            
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            BL_Empleado BLEmpleado = new BL_Empleado();
            List<Empleado> Empleado = new List<Empleado>();
            Empleado.Add(BLEmpleado.GetEmpleadoId(Convert.ToInt32(id)));
            var Empleo = Empleado.First();
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, "Contrato__" + Empleo.XNombreCompleto);

        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                //this.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
