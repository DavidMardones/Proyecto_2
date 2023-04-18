using Proyecto_2.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Iniciando servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                //Ok, puede conectar
                Console.WriteLine("Servidor iniciado");

                //Solicitando cliente infinitamente
                while (true)
                {
                    Console.WriteLine("Esperando Cliente...");
                    Socket socketCliente = servidor.ObtenerCliente();

                    //Construir el mecanismo para escribir y leer cliente
                    ClienteCom cliente = new ClienteCom(socketCliente);
                    //Aqio esta el protocolo de comunicacion
                    cliente.Escribir("Hola mundo cliente, dime tu nombre: ");
                    string respuesta = cliente.Leer();
                    Console.WriteLine("El cliente envio: {0}", respuesta);
                    cliente.Escribir("Chao");
                    cliente.Desconectar();

                }
            }
            else
            {
                Console.WriteLine("ERROR, EL PUERTO ESTA {0} ESTA EN USO", puerto);
            }
        }
    }
}
