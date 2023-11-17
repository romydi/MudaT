namespace MudarT.Models
{
    public class ModelVehiculo
    {
        public int id_vehiculo { get; set; }
        public int reservados { get; set; }
        public double precio { get; set; }
        public string? tipo { get; set; }
        public int cantidad { get; set; }
        public double largo { get; set; }
        public double ancho { get; set; }
        public double alto { get; set; }
    }
}
