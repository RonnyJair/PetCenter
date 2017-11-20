using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IronPdf;

namespace PetCenter.Presentation.MVC.Models
{
    public class SubirArchivosModelo
    {
        HtmlToPdf Renderer = new HtmlToPdf();
        public String Confirmacion { get; set; }
        public Exception error { get; set; }
        public void SubirArchivo(String ruta, HttpPostedFileBase file)
        {
            try
            {
                
                file.SaveAs(ruta);
                this.Confirmacion = "Fichero guardado";
            }
            catch (Exception ex)
            {
                this.error=ex;
            }
        }
    }
}