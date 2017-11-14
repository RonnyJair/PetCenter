using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace PetCenter.Infrastucture.Domain.Main
{
    class BL_Asistencia
    {
        public object GetAsistenciasDesdeServicio(String Fecha)
        {
            string serviceUrl = "http://localhost:15721/RestServiceImplementacion.svc/GetArchivo/" + Fecha;
            using(WebClient client = new WebClient() { })
            {
                try
                {

                    string htmlCode = client.DownloadString(serviceUrl);
                   // JObject jObject = JObject.Parse(htmlCode);

                    return htmlCode;
                }
                catch(WebException exception)
                {
                    string responseText = string.Empty;

                    var responseStream = exception.Response?.GetResponseStream();

                    if(responseStream != null)
                    {
                        using(var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }

                    return responseText;
                }
            }
        }

    }
}
