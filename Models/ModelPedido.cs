namespace MudarT.Models
{
    public class ModelPedido
    {
        public int id_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
        public DateTime fecha_mudanza { get; set; }
        public string? tipo_vehiculo { get; set; }
        public string? extras { get; set; }
        public DateTime direccion_partida { get; set; }
        public DateTime direccion_destino { get; set; }
        public float total { get; set; }
        public string? estado { get; set; }
    }
}
