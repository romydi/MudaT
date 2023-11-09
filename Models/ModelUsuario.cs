namespace MudarT.Models
{
    public class ModelUsuario
    {
        public int id_registro { get; set; }
        public string? email { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? contraseña { get; set; }
        public string? direccion { get; set; }
        public int dni { get; set; }
    }
}