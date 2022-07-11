using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using Web_dapper.Models;

namespace Web_dapper.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("despensa");
        }
        //conexion a mysql
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        

        public Producto producto { get; set; }


    }
}
