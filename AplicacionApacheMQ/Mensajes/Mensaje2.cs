using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajes
{
    public class Mensaje2
    {
        public Mensaje2()
        {
            
        }

        public Mensaje2(int entero, double doble, bool booleano)
        {
            Entero = entero;
            Doble = doble;
            this.booleano = booleano;
            this.fecha = DateTime.Now;
           this.tarifa = new Tarifa("tipo", "descripcion", /*DateTime.Now,*/ "Desconocida");
            this.entrada = new Entrada();
        }

        public int Entero { get; set; }
        public double Doble { get; set; }
        public bool booleano { get; set; }
        public DateTime fecha { get; set; }
        public Tarifa tarifa { get; set; }
        public Entrada entrada { get; set; }
    }
}
