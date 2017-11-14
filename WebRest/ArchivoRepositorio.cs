using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRest.Models;

namespace WebRest
{
    public class ArchivoRepositorio : IArchivoRepositorio
    {
        public Archivo GetArchivoById(string id)
        {
            return new Archivo();
        }
    }
}