﻿using System.Data.SqlClient;

namespace MudarT.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion() {         
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string CadenaSQL(){  return cadenaSQL; }
    }
}
