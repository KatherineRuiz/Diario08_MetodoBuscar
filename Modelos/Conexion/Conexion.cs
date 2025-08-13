using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Conexion
{
    public class Conexion
    {
        private static string servidor = "DESKTOP-V2L6QH5\\SQLEXPRESS";
        private static string baseDeDatos = "Negocio";

        public static SqlConnection Conectar()
        {
            //creamos una cadena de conexion, un string que tiene todos los parametros para poder acceder a sql server
            string cadena =
                $"Data Source = {servidor},54321;Initial Catalog = {baseDeDatos};Integrated Security = true;";
            //Initial Catalog indica la base de datos que vamos a leer

            //Creamos un objeto de tipo SqlConnection
            SqlConnection con = new SqlConnection(cadena);

            //Abrimos la conexion entre SQL Server y nuestra aplicacion
            con.Open();
            return con;
        }
    }
}
