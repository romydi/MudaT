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

		public ModelVehiculo Obtener(int id)
		{
			var oVehiculo = new ModelVehiculo();
			var cn = new Conexion();

			using (var conexion = new SqlConnection(cn.CadenaSQL()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("vehiculo_obtener", conexion);
				cmd.Parameters.AddWithValue("id", id);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var dr = cmd.ExecuteReader())
				{
                    while (dr.Read())
                    {
                        oVehiculo.id_vehiculo = Convert.ToInt32(dr["ID_VEHICULO"]);
                        oVehiculo.reservados = Convert.ToInt32(dr["RESERVADOS"]);
                        oVehiculo.precio = Convert.ToDouble(dr["PRECIO"]);
                        oVehiculo.tipo = dr["TIPO"].ToString();
                        oVehiculo.cantidad = Convert.ToInt32(dr["CANTIDAD"]);
						oVehiculo.largo = Convert.ToDouble(dr["LARGO"]);
						oVehiculo.ancho = Convert.ToDouble(dr["ANCHO"]);
						oVehiculo.alto = Convert.ToDouble(dr["ALTO"]);
					}
				}
			}
			return oVehiculo;
		}

		public bool Editar(ModelVehiculo oVehiculo)
		{
			bool respuesta;
			try
			{
				var cn = new Conexion();
				using (var conexion = new SqlConnection(cn.CadenaSQL()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("vehiculo_editar", conexion);
					cmd.Parameters.AddWithValue("id", oVehiculo.id_vehiculo);
					cmd.Parameters.AddWithValue("reservados", oVehiculo.reservados);
					cmd.Parameters.AddWithValue("precio", oVehiculo.precio);
					cmd.Parameters.AddWithValue("tipo", oVehiculo.tipo);
					cmd.Parameters.AddWithValue("cantidad", oVehiculo.cantidad);
					cmd.Parameters.AddWithValue("largo", oVehiculo.largo);
					cmd.Parameters.AddWithValue("ancho", oVehiculo.ancho);
					cmd.Parameters.AddWithValue("alto", oVehiculo.alto);
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
