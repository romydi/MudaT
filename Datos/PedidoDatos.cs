using MudarT.Models;
using System.Data.SqlClient;
using System.Data;

namespace MudarT.Datos
{
    public class PedidoDatos
    {

        public bool Guardar(ModelPedido oPedido)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("pedido_guardar", conexion);
                    cmd.Parameters.AddWithValue("fecha_pedido", DateTime.Parse(oPedido.fecha_pedido));
                    cmd.Parameters.AddWithValue("fecha_mudanza", DateTime.Parse(oPedido.fecha_mudanza));
                    cmd.Parameters.AddWithValue("tipo_vehiculo", oPedido.tipo_vehiculo);
                    cmd.Parameters.AddWithValue("extras", oPedido.extras);
                    cmd.Parameters.AddWithValue("direccion_partida", oPedido.direccion_partida);
                    cmd.Parameters.AddWithValue("direccion_destino", oPedido.direccion_destino);
                    cmd.Parameters.AddWithValue("total", oPedido.total);
                    cmd.Parameters.AddWithValue("estado", oPedido.estado);
                    cmd.Parameters.AddWithValue("dni", oPedido.dni);
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
