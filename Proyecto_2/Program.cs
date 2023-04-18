using Proyecto_2.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
            }
            else
            {
                Console.WriteLine("ERROR, EL PUERTO ESTA {0} ESTA EN USO", puerto);
            }
        }
    }
}
