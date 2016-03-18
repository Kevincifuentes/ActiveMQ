using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Mensajes;

namespace AplicacionApacheMQ
{
    class Emisor
    {
        private IConnection _connection;
        private ISession _session;
        private const String QUEUE_DESTINATION = "pruebaKevincifu";
        private IMessageProducer _producer;

        public void inicializar() {
        // configure the broker
        try {
            // Create a ConnectionFactory
            IConnectionFactory connectionFactory = new ConnectionFactory(
                    "tcp://localhost:61616");

            // Create a Connection
            _connection = connectionFactory.CreateConnection();
            _connection.Start();

            // Create a Session
            _session = _connection.CreateSession();

            // Create the destination (Topic or Queue)
            IDestination destination = _session.GetTopic(QUEUE_DESTINATION);

            // Create a MessageProducer from the Session to the Topic or Queue
            _producer = _session.CreateProducer(destination);
                

        } catch (Exception e) {
            // TODO Auto-generated catch block
            Console.WriteLine(e.Message);
        }

    }

        public void limpiar()
        {
            _session.Close();
            _connection.Close();
        }

        public void enviarMensaje(string text)
        {
            ITextMessage objecto = _producer.CreateTextMessage(text);
            _producer.Send(objecto);
        }

        public void enviarObjeto(Mensaje m)
        {
            Console.WriteLine(_producer.CreateXmlMessage(m).Text);
            Console.ReadKey();
            try
            {
                _producer.Send(m);
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("No se ha podido inicializar el productor. Compruebe que ApacheMQ esté encendido.");
                Console.ReadKey();
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Emisor");
            Emisor p = new Emisor();
            p.inicializar();
            //p.enviarMensaje("Mensaje de prueba 1");
            Console.ReadKey();
            Mensaje m = new Mensaje("Mensaje de prueba 2", "Buenas compañero!");
            m.listaPares.Add(new Mensajes.KeyValuePair<int, Mensaje2>(0, new Mensaje2(1, 2.5, false)));
            m.listaPares.Add(new Mensajes.KeyValuePair<int, Mensaje2>(1, new Mensaje2(2, 3.5, true)));
            m.listaPares.Add(new Mensajes.KeyValuePair<int, Mensaje2>(2, new Mensaje2(3, 4.5, false)));
            /*m.listaPares.Add(new Mensajes.KeyValuePair<int, Parking>(0, new Parking()));
            m.listaPares.Add(new Mensajes.KeyValuePair<int, Parking>(0, new Parking()));
            m.listaPares.Add(new Mensajes.KeyValuePair<int, Parking>(0, new Parking()));*/
            p.enviarObjeto(m);
            p.limpiar();
        }

    }
}
