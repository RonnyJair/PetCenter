using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRestServiceImplementacion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRestServiceImplementacion
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped,
             UriTemplate = "GetArchivo/{id}")]
        List<BE_AsistenciaArchivo> GetArchivo(string id);
    }
}
