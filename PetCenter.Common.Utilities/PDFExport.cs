using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Text;

namespace PetCenter.Common.Utilities
{

     public class PDFExport
    {

        public string SavePDF(DataSet datos, string ReportTitle, List<string> subtitles)
        {
            string Ruta= @"c:\logs\tmp\";
            //Create a dummy GridView

            if (subtitles == null)
                subtitles = new List<string>();

            dynamic pdffilepath = @Ruta + Guid.NewGuid().ToString ().Replace ("-","") + ".pdf";
            System.IO.FileStream archivo = new System.IO.FileStream(pdffilepath, FileMode.Create);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < datos.Tables.Count ; i++)
            {
                
                GridView GridView1 = new GridView();

                if ( subtitles.Count > 0 && subtitles .Count < datos.Tables.Count )
                GridView1.Caption = subtitles[i].ToUpper();

                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Blue;
                GridView1.HeaderStyle.Font.Bold = true;
                GridView1.AllowPaging = false;
                GridView1.DataSource = datos.Tables[i];
                GridView1.DataBind();
                GridView1.RenderControl(hw);
            }

            StringReader sr = new StringReader("<h1> " + ReportTitle + " </h1><br>" + sw.ToString());

            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, archivo);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();

            return pdffilepath;
        }
        //Método implementado por MCG para Mod GDirectiva
         public static void ExportToPdf(StringBuilder builder, string name)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/pdf";
            string strFileName = name + ".pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            sw.Write(builder.ToString());
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }
    }
}