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
    public class JustificacionsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Justificacions
        public ActionResult Index()
        {
            BL_Justificacion BlJustificacion = new BL_Justificacion();
            return View(BlJustificacion.ListarJustificacion().ToList());
        }

        // GET: Justificacions/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Justificacion BlJustificacion = new BL_Justificacion();
            Justificacion justificacion = BlJustificacion.GetJustificacion((Int32)id);
            if(justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        // GET: Justificacions/Create
        public ActionResult Create()
        {
            BL_Empleado BLEmpleado = new BL_Empleado();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            return View();
        }

        // POST: Justificacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JustificacionId,EmpleadoId,Descripcion,Documento,Estado,UsuarioAprueba,FechaAprobacion,UsuarioNiega,FechaNegacion")] Justificacion justificacion)
        {
            if(ModelState.IsValid)
            {
                BL_Justificacion BlJustificacion = new BL_Justificacion();
                BL_Falta BLFalta = new BL_Falta();
                var Faltas = BLFalta.ListarFaltasPorMesAndEmpleado(DateTime.Now, (Int32)justificacion.EmpleadoId);
                var path = Path.Combine(Server.MapPath("~/Temp"), "Justificacion_ID_" + justificacion.EmpleadoId.ToString());
                justificacion.Documento = path;

                foreach(var falta in Faltas)
                {
                    justificacion.Faltas.Add(falta);
                }
                var item = BlJustificacion.GuardarJustificacion(justificacion);
                TempData["justificacionomsg"] = string.Format("La justificación se ha creado correctamente");
                return RedirectToAction("Index");
            }

            BL_Empleado BLEmpleado = new BL_Empleado();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            return View(justificacion);
        }

        // GET: Justificacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Justificacion BlJustificacion = new BL_Justificacion();
            Justificacion justificacion = BlJustificacion.GetJustificacion((Int32)id);
            BL_Empleado BLEmpleado = new BL_Empleado();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");

            if(justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        // POST: Justificacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JustificacionId,FaltaId,Descripcion,Documento,Estado,UsuarioAprueba,FechaAprobacion,UsuarioNiega,FechaNegacion")] Justificacion justificacion)
        {
            if(ModelState.IsValid)
            {
                BL_Justificacion BlJustificacion = new BL_Justificacion();
                var item = BlJustificacion.GuardarJustificacion(justificacion);
                TempData["justificacionomsg"] = string.Format("La justificación se ha modificado correctamente");
                return RedirectToAction("Index");
            }
            BL_Empleado BLEmpleado = new BL_Empleado();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            return View(justificacion);
        }

        [HttpPost]
        public PartialViewResult GetPartialGraph(int id /* drop down value */)
        {
            BL_Falta BLFalta = new BL_Falta();
            var model = BLFalta.ListarFaltasPorMesAndEmpleado(DateTime.Now, id);

            return PartialView("VPartialFalta", model);
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
                        // get a streamj
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = "Justificacion_ID_" + id;
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

            try
            {
                string fullPath = Path.Combine(Server.MapPath("~/Temp"), "Justificacion_ID_" + id);

                byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
                BL_Empleado BLEmpleado = new BL_Empleado();
                List<Empleado> Empleado = new List<Empleado>();
                Empleado.Add(BLEmpleado.GetEmpleadoId(Convert.ToInt32(id)));
                var Empleo = Empleado.First();

                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, "Justificacion_" + Empleo.XNombreCompleto + ".pdf");

            }
            catch (Exception ) {
                return View("Error");
            }
           

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Aprobar(Int32 id)
        {
            BL_Justificacion BlJustificacion = new BL_Justificacion();
            Justificacion justificacion = BlJustificacion.GetJustificacion((Int32)id);

            if(ModelState.IsValid)
            {
                justificacion.UsuarioAprueba = 1;
                justificacion.FechaAprobacion = DateTime.Now;
                var item = BlJustificacion.GuardarJustificacion(justificacion);
                return RedirectToAction("Index");
            }
            BL_Empleado BLEmpleado = new BL_Empleado();
            ViewBag.EmpleadoId = new SelectList(BLEmpleado.GetEmpleados(), "EmpleadoId", "XNombreCompleto");
            TempData["justificacionomsg"] = string.Format("La justificación se ha aprobado");
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
