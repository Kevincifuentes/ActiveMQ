using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mensajes
{
    public class Mensaje
    {
        public Mensaje()
        {
            
        }
        public Mensaje(string descripcion, string cuerpo)
        {
            this.descripcion = descripcion;
            this.cuerpo = cuerpo;
            this.lista = new List<string>();
            lista.Add("pacopaper");
            lista.Add("juancho");
            lista.Add("mujerita");
            this.Mensaje2 = new Mensaje2();
            this.Mensaje2.Entero = 1900;
            this.hoy = DateTime.Today;
            this.listaPares = new List<KeyValuePair<int, Mensaje2>>();

        }

        public string descripcion { get; set; }

        public string cuerpo { get; set; }

        public Mensaje2 Mensaje2 { get; set; }

        public List<string> lista { get; set; }

        public List<KeyValuePair<int, Mensaje2>> listaPares { get; set; }

        public DateTime hoy { get; set; }

        //public override string ToString()
        //{
        //    DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
        //    MemoryStream ms = new MemoryStream();

        //    ser.WriteObject(ms, this);
        //    string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //    ms.Close();

        //    return jsonString;
        //}
    }
}
