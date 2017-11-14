using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebRest.Models;

namespace WebRest.Controllers
{
    public class ArchivoController : ApiController
    {
        private readonly IArchivoRepositorio _IArchivoRepositorio;

        public ArchivoController(IArchivoRepositorio mIArchivoRepositorio)
        {
            _IArchivoRepositorio = mIArchivoRepositorio;
        }

        public Archivo Get(String id)
        {
            var item = _IArchivoRepositorio.GetArchivoById(id);

            if(item == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Archivo no encontrado")
                });
            }

            return item;
        }
    }
}