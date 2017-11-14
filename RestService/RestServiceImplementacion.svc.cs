using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "RestServiceImplementacion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione RestServiceImplementacion.svc o RestServiceImplementacion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class RestServiceImplementacion : IRestServiceImplementacion
    {
        public List<BE_AsistenciaArchivo> GetArchivo(string id)
        {
            List<BE_AsistenciaArchivo> items = new List<BE_AsistenciaArchivo>();
            for(int i = 0; i < 15; i++)
            {
                DateTime date = DateTime.Now.AddDays(i);
                items.Add(new BE_AsistenciaArchivo()
                {
                    Dni = "46560233",
                    Fecha = String.Format("{2}_{1}_{0}", date.Year, date.Month,date.Day),
                    Nombre = "Ronny Jair Ruiz Andia"
                });
            }
            return items;
        }
    }
}
