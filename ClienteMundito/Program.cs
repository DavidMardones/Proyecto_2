using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ClienteMundito.Comunicacion;

namespace ClienteMundito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string servidor = ConfigurationManager.AppSettings["servidor"];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conectando a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado...");
                //Recibir lo que envia el servidor
                string mensaje = clienteSocket.Leer();
                Console.WriteLine("M: {0}", mensaje);
                string nombre = Console.ReadLine().Trim();
                clienteSocket.Escribir(nombre);
                mensaje = clienteSocket.Leer();
                Console.WriteLine("M: {0}", mensaje);
                clienteSocket.Desconectar();
            }
            else
            {
                Console.WriteLine("Error de comunicacion");
            }
            Console.ReadKey();
        }
    }
}
