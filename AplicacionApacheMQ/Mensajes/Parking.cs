using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mensajes
{
    public class Parking
    {
        public Parking()
        {
            this.id = 13;
            this.nombre = "Prueba!!!";
            this.latlong = new Coordenadas(2.5, 3.5);
            this.entradas = new List<Entrada>();
            Entrada temp = new Entrada();
            temp.nombre = "Entrada1";
            temp.puntoEntrada = latlong;
            entradas.Add(temp);
            entradas.Add(temp);

            this.tarifas = new List<Tarifa>();
            Tarifa temp2 = new Tarifa("tipo", "descripcion"/*, DateTime.Today*/, "desconocida");
            tarifas.Add(temp2);
            tarifas.Add(temp2);
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public double ocupacion { get; set; }
        public double porcentaje { get; set; }
        public Coordenadas latlong { get; set; }
        public List<Entrada> entradas { get; set; }
        public int capacidad { get; set; }
        public string tipo { get; set; }

        public List<Tarifa> tarifas { get; set; }

        public override string ToString()
        {
            string respuesta = "Parking " + id + " " + nombre + " : " + "Última modificación: " + fecha + " Estado: " + estado + " Ocupación: " + ocupacion + " Porcentaje: " + porcentaje + "\n";
            if (latlong != null)
            { respuesta = respuesta + "Coordenadas: " + latlong.longitud + " , " + latlong.latitud + " Capacidad: " + capacidad + " Tipo: " + tipo + "\n"; }

            respuesta = respuesta + "----Entradas----";
            if (entradas != null)
            {
                foreach (Entrada e in entradas)
                {
                    respuesta = respuesta + e.nombre + " Punto de entrada: " + e.puntoEntrada.longitud + " , " + e.puntoEntrada.latitud + "\n";
                }
            }

            if (tarifas != null)
            {
                foreach (Tarifa t in tarifas)
                {
                    respuesta = respuesta + t.tipo + " Descripción: " + t.descripcion + " Actualización: " + /*t.actualizacion +*/ " Zona: " + t.zona + "\n";
                }
            }
            return respuesta;
        }
    }
}
