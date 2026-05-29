using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pruebita.Models
{
    public class UsuarioDAL
    {
        string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;    
        

        //LOGIN
        public Usuario ValidarUsuario(string usuario, string contraseña)
        {
            Usuario user = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "select * from Usuarios where Usuario=@usuario AND Contraseña=@pass AND Estado=1";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", contraseña);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    user = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        UsuarioNombre = dr["Usuario"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Contraseña = dr["Contraseña"].ToString(),
                        TipoUsuario = Convert.ToInt32(dr["TipoUsuario"]),
                    };
                }
            }
            return user;
        }

        //REGISTRO
        public bool RegistrarUsuario(Usuario user)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = @"insert into Usuarios(Usuario, Correo, Contraseña, TipoUsuario, Estado) values (@usuario, @correo, @pass, @tipo, 1)";
                
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@usuario", user.UsuarioNombre);
                cmd.Parameters.AddWithValue("@correo", user.Correo);
                cmd.Parameters.AddWithValue("@pass", user.Contraseña);
                cmd.Parameters.AddWithValue("@tipo", user.TipoUsuario);

                con.Open();
                int filas = cmd.ExecuteNonQuery();

                return filas > 0;
            }
        }
    }
}