using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PetCenter.Infrastucture.Data;
using PetCenter.Common.Core.Entities;
using System.IO;
using System.Text.RegularExpressions;

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
                    Fecha = String.Format("{2}_{1}_{0}", date.Year, date.Month, date.Day),
                    Nombre = "Ronny Jair Ruiz Andia"
                });
            }
            return items;
        }

        public bool ProcesarAsistencia(string Mes, string Anio)
        {
            string line;

            using(StreamReader sr = new StreamReader(String.Format(@"D:\DataJson\{0}{1}.txt", Mes, Anio)))
            {
                // Read the stream to a string, and write the string to the console.
                 line = sr.ReadToEnd();
            }
            
            string[] items = line.Split('@');
            List<Asistencia> asistencias = new List<Asistencia>();
            foreach(string item in items)
            {
                string[] detalle = item.Split(',');
                asistencias.Add(new Asistencia()
                {
                    DNI = detalle[0].Trim(),
                    FechaSalida = Convert.ToDateTime(detalle[1]),
                    Fecha = Convert.ToDateTime(detalle[1]),
                    FechaIngreso = Convert.ToDateTime(detalle[1])
                });
            }
            
            DA_Asistencia DAAsistencia = new DA_Asistencia();
            foreach(var item in asistencias)
            {

                DAAsistencia.GuardarAsistencia(item);
            }

            return false;
        }

       
    }
}
