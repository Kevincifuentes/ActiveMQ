using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Mensajes;

namespace AplicaciónLecturaApacheMQ
{
    class Receptor
    {
        
        private IConnection _connection;
        private ISession _session;
        private const String QUEUE_DESTINATION = "pruebaKevincifu";
        private IMessageConsumer _consumer;


        public void inicializar()
        {
            // configure the broker
            try
            {
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
                _consumer = _session.CreateConsumer(destination);
                //producer.setDeliveryMode(DeliveryMode.NON_PERSISTENT);
                _consumer.Listener += _consumer_Listener;

            }
            catch (Exception e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e.Message);
            }

        }

        private void _consumer_Listener(IMessage message)
        {
           // ITextMessage temp = message as ITextMessage;
            var tumensaje = message.ToObject<Mensaje>();
            if (tumensaje != null)
            {
              /*  Console.WriteLine(tumensaje.descripcion);
                Console.WriteLine(tumensaje.cuerpo);
                Console.WriteLine(tumensaje.Mensaje2.Entero);
                Console.WriteLine(tumensaje.hoy);*/
                foreach (Mensajes.KeyValuePair<int, Mensaje2> te in tumensaje.listaPares)
                {
                    Console.WriteLine(te.Value.Entero+ " "+ te.Value.Doble+" "+te.Value.booleano+ " "+te.Value.fecha+" "+ te.Value.tarifa.descripcion);
                }
              /*  foreach (string s in tumensaje.lista)
                {
                    Console.WriteLine(s);
                }*/
            }
        }

        public void esperarMensaje()
        {
            while (true)
            {
                IMessage m = _consumer.Receive();
                if (m is ITextMessage)
                {
                    ITextMessage text = m as ITextMessage;
                    Console.WriteLine(text.Text);
                }
                else
                {
                    IObjectMessage temp = m as IObjectMessage;
                    if (temp != null)
                    {

                        Console.WriteLine("Estoy aqui");
                        try
                        {
                            Mensaje m2 = temp.Body as Mensaje;
                            if (m2 != null)
                            {
                                Console.WriteLine("No es null");
                                Console.WriteLine(m2.descripcion);
                                Console.WriteLine(m2.cuerpo);
                            }
                        }
                        catch (SerializationException e)
                        {
                            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                            throw;
                        }
                    }
                }
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Receptor 1");
            Receptor r = new Receptor();
            r.inicializar();
            while (true)
            {
                
            }
        }

    }
}
