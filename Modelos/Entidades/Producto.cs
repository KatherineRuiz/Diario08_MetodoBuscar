using Modelos.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Modelos.Entidades
{
    public class Producto
    {
        private int id;
        private string nombre;
        private int cantidad;
        private int id_Categoria;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_Categoria { get => id_Categoria; set => id_Categoria = value; }

        public static DataTable cargarProducto()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string cadena = "select idProducto As Num, nombreProducto As Producto, cantidad as Cantidad, nombreCategoria as Categoria from Producto P" +
                    "\r\nINNER JOIN \r\nCategoria C on C.idCategoria = P.id_Categoria ;";
                SqlDataAdapter add = new SqlDataAdapter(cadena, conexion);
                DataTable tablaVirtual = new DataTable();
                add.Fill(tablaVirtual);
                return tablaVirtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos" + ex);
                return null;
            }
        }

        public bool insertarProductos()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaQuery = "Insert into Producto (nombreProducto, cantidad, id_Categoria)  values (@nombre, @cantidad, @categoria);";
                SqlCommand insertar = new SqlCommand(consultaQuery, conexion);
                //Vamos a insertar o sustituir los @nombres con los datos que se obtienen en los txt

                insertar.Parameters.AddWithValue("@nombre", nombre);
                insertar.Parameters.AddWithValue("@cantidad", cantidad);
                insertar.Parameters.AddWithValue("@categoria", id_Categoria);
                insertar.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica si la consulta Query esta correcta" + ex);
                return false;
            }

        }

        //Metodo de eliminar registro
        public bool eliminarProductos(int id)
        {
            SqlConnection conexion = Conexion.Conexion.Conectar();
            string consultaDelete = "Delete from Producto where idProducto =@id";
            SqlCommand delete = new SqlCommand(consultaDelete, conexion);

            delete.Parameters.AddWithValue("@id", id);
            if (delete.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool actualizarProductos()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaUpdate = "Update Producto set nombreProducto = @nombre, cantidad = @cantidad, id_Categoria = @categoria where idProducto = @id";
                SqlCommand actualizar = new SqlCommand(consultaUpdate, conexion);
                actualizar.Parameters.AddWithValue("@nombre", nombre);
                actualizar.Parameters.AddWithValue("@cantidad", cantidad);
                actualizar.Parameters.AddWithValue("@categoria", id_Categoria);
                actualizar.Parameters.AddWithValue("@id", id);
                actualizar.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados", "Actualizar");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos" + ex);
                return false;
            }
        }

        //Metodo para Buscar
        public static DataTable Buscar(string termino)
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaQuery = "select idProducto As Num, nombreProducto As Producto, cantidad as Cantidad, nombreCategoria as Categoria from Producto P" +
                    "\r\nINNER JOIN \r\nCategoria C on C.idCategoria = P.id_Categoria WHERE P.nombreProducto LIKE '%{termino}%';";
                SqlDataAdapter ad = new SqlDataAdapter(consultaQuery, conexion);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto" + ex);
                return null;
            }
        }



    }
}














































