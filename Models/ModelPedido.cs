namespace MudarT.Models
{
    public class ModelPedido
    {
        public int? id_pedido { get; set; }
        public string? fecha_pedido { get; set; }
        public string? fecha_mudanza { get; set; }
        public string? tipo_vehiculo { get; set; }
        public string? extras { get; set; }
        public string? direccion_partida { get; set; }
        public string? direccion_destino { get; set; }
        public float total { get; set; }
        public string? estado { get; set; }
        public int dni { get; set; }
    }
}
