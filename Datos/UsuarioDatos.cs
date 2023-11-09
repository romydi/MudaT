using MudarT.Models;
using System.Data.SqlClient;
using System.Data;

namespace MudarT.Datos
{
    public class UsuarioDatos
    {
        public List<ModelUsuario> Listar()
        {
            var oLista = new List<ModelUsuario>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("usuario_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oLista.Add(new ModelUsuario()
                        {
                            id_registro = Convert.ToInt32(dr["ID_REGISTRO"]),
                            email = dr["EMAIL"].ToString(),
                            nombre = dr["NOMBRE"].ToString(),
                            apellido = dr["APELLIDO"].ToString(),
                            contraseña = dr["CONTRASEÑA"].ToString(),
                            direccion = dr["DIRECCION"].ToString(),
                            dni = Convert.ToInt32(dr["DNI"])
                        });
                    }
                }
            }
            return oLista;
        }

        public ModelUsuario Obtener(int id)
        {
            var oUsuario = new ModelUsuario();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("usuario_obtener", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oUsuario.id_registro = Convert.ToInt32(dr["ID_REGISTRO"]);
                        oUsuario.email = dr["EMAIL"].ToString();
                        oUsuario.nombre = dr["NOMBRE"].ToString();
                        oUsuario.apellido = dr["APELLIDO"].ToString();
                        oUsuario.contraseña = dr["CONTRASEÑA"].ToString();
                        oUsuario.direccion = dr["DIRECCION"].ToString();
                        oUsuario.dni = Convert.ToInt32(dr["DNI"]);
                    }
                }
            }
            return oUsuario;
        }

        public bool Guardar(ModelUsuario oCliente)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("usuario_guardar", conexion);
                    cmd.Parameters.AddWithValue("email", oCliente.email);
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", oCliente.apellido);
                    cmd.Parameters.AddWithValue("contraseña", oCliente.contraseña);
                    cmd.Parameters.AddWithValue("direccion", oCliente.direccion);
                    cmd.Parameters.AddWithValue("dni", oCliente.dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Editar(ModelUsuario oCliente)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("usuario_editar", conexion);
                    cmd.Parameters.AddWithValue("id", oCliente.id_registro);
                    cmd.Parameters.AddWithValue("email", oCliente.email);
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", oCliente.apellido);
                    cmd.Parameters.AddWithValue("contraseña", oCliente.contraseña);
                    cmd.Parameters.AddWithValue("direccion", oCliente.direccion);
                    cmd.Parameters.AddWithValue("dni", oCliente.dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("usuario_eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public int Login(string email, string contraseña)
        {
            int respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("usuario_login", conexion);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("contraseña", contraseña);

                    cmd.CommandType = CommandType.StoredProcedure;
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                
            }
            catch(Exception e)
            {
                respuesta = 0;
            }

            return respuesta;
        }
    }
}
