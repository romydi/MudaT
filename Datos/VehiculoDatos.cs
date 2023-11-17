using MudarT.Models;
using System.Data.SqlClient;
using System.Data;

namespace MudarT.Datos
{
    public class VehiculoDatos
    {
        public List<ModelVehiculo> Listar()
        {
            var oLista = new List<ModelVehiculo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("vehiculo_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ModelVehiculo()
                        {
                            id_vehiculo = Convert.ToInt32(dr["ID_VEHICULO"]),
                            reservados = Convert.ToInt32(dr["RESERVADOS"]),
                            precio = Convert.ToDouble(dr["PRECIO"]),
                            tipo = dr["TIPO"].ToString(),
                            cantidad = Convert.ToInt32(dr["CANTIDAD"]),
                            largo = Convert.ToDouble(dr["LARGO"]),
                            ancho = Convert.ToDouble(dr["ANCHO"]),
                            alto = Convert.ToDouble(dr["ALTO"])
                        });
                    }
                }
            }
            return oLista;
        }
    }
}
