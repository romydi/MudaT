using MudarT.Models;
using System.Data.SqlClient;
using System.Data;

namespace MudarT.Datos
{
    public class ExtrasDatos
    {
        public List<ModelExtras> Listar()
        {
            var oLista = new List<ModelExtras>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("extras_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ModelExtras()
                        {
                            id_extras = Convert.ToInt32(dr["ID_EXTRAS"]),
                            e_cantidad = Convert.ToInt32(dr["E_CANTIDAD"]),
                            e_precio = Convert.ToDouble(dr["E_PRECIO"]),
                            e_descripcion = dr["E_DESCRIPCION"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ModelExtras Obtener(int id)
        {
            var oExtras = new ModelExtras();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("extras_obtener", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oExtras.id_extras = Convert.ToInt32(dr["ID_EXTRAS"]);
                        oExtras.e_cantidad = Convert.ToInt32(dr["E_CANTIDAD"]);
                        oExtras.e_precio = Convert.ToDouble(dr["E_PRECIO"]);
                        oExtras.e_descripcion = dr["E_DESCRIPCION"].ToString();
                    }
                }
            }
            return oExtras;
        }

        public bool Editar(ModelExtras oExtras)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("extras_editar", conexion);
                    cmd.Parameters.AddWithValue("id", oExtras.id_extras);
                    cmd.Parameters.AddWithValue("e_cantidad", oExtras.e_cantidad);
                    cmd.Parameters.AddWithValue("e_precio", oExtras.e_precio);
                    cmd.Parameters.AddWithValue("e_descripcion", oExtras.e_descripcion);
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

    }
}
