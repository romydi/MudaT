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

    }
}
