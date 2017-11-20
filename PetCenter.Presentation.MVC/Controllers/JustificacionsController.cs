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
using IronPdf;

namespace PetCenter.Presentation.MVC.Controllers
{
    [Authorize]
    public class JustificacionsController :BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
        // GET: Justificacions
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Descripcion" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            BL_Justificacion BLJustificacion = new BL_Justificacion();
            var justificacion = searchString == null ? BLJustificacion.ListarJustificacion() : BLJustificacion.ListarJustificacionFiltro(searchString);

            switch (sortOrder)
            {
                case "Descripcion":
                    justificacion = justificacion.OrderByDescending(s => s.Descripcion).ToList();
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(justificacion.ToPagedList(pageNumber, pageSize));
        }

        // GET: Conceptoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Justificacion BLJustificacion = new BL_Justificacion();
            Justificacion justificacion = BLJustificacion.GetJustificacion((Int32)id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        public ActionResult Justificar()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Get Subir Archivo
        public ActionResult SubirArchivo()
        {
            return View();
        }
        //Post SubirArchivo
        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase file)
        {
            SubirArchivosModelo modelo = new SubirArchivosModelo();
            if(file != null)
            {
                String ruta = Server.MapPath("~/Temp/");
                ruta += file.FileName;
                modelo.SubirArchivo(ruta, file);
                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
            }
            return View();
        }
    }
}