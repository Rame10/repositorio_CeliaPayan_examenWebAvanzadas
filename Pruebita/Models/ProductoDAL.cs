using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pruebita.Models
{
    public class ProductoDAL
    {
        string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT id, p.Nombre, p.idCategoria, c.Nombre as NombreCategoria, Descripcion, Precio FROM Productos as p\r\ninner join Categorias as c on p.idCategoria = c.idCategoria";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Producto
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Nombre = dr["Nombre"].ToString(),
                        Categoria = new Categoria
                        {
                            IdCategoria = Convert.ToInt32(dr["idCategoria"]),
                            Nombre = dr["NombreCategoria"].ToString()
                        },
                        Descripcion = dr["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"])
                    });
                }
            }
            return lista;
        }
        public void InsertarProducto(Producto p)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Productos (Nombre, idCategoria, Descripcion, Precio) VALUES (@nombre, @idcat, @descripcion, @precio)";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@idcat", p.IdCategoria);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarProducto(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Productos WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}