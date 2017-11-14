using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PetCenter.Common.Core.Entities;
using PetCenter.Common.Utilities;
using PetCenter.Infrastucture.Data;
using PetCenter.Infrastucture.Domain.Main.ServiceRest;

namespace PetCenter.Infrastucture.Domain.Main
{
    public class BL_Asistencia
    {
        public BL_Asistencia()
        {

        }

        public List<Asistencia> ListarAsistencias()
        {
            DA_Asistencia DAAsistencia = new DA_Asistencia();
            try
            {
                return DAAsistencia.ListarAsistencias();
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public object ProcesarAsistencia(String mes, String anio)
        {
            string serviceUrl = "http://localhost:15721/RestServiceImplementacion.svc/ProcesarAsistencia/" + mes + "/"+ anio;
            using(WebClient client = new WebClient() { })
            {
                try
                {

                    string htmlCode = client.DownloadString(serviceUrl);
                    JavaScriptSerializer objJavascript = new JavaScriptSerializer();
                    object testModels = (object)objJavascript.DeserializeObject(htmlCode);
                    Dictionary<String, object> objetos = (Dictionary<String, object>)testModels;
                    //var items = new System.Collections.Generic.Mscorlib_DictionaryDebugView<string, object>(objetos).Items[0].Value;


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
