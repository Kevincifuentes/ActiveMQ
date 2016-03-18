using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajes
{
    public class Entrada
    {
        public Entrada()
        {
            this.nombre = "Prueba";
            this.puntoEntrada = new Coordenadas(2.6666, 26774634234);
        }

        public Coordenadas puntoEntrada { get; set; }
        public string nombre { get; set; }
    }
}
