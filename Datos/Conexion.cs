using System.Data.SqlClient;

namespace MudarT.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion() {         
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:cadenaSQL").Value;
        }

        public string CadenaSQL { get {  return cadenaSQL; } }
    }
}
