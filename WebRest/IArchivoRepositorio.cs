using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRest.Models;

namespace WebRest
{
    public interface IArchivoRepositorio
    {
        Archivo GetArchivoById(String id);
    }
}