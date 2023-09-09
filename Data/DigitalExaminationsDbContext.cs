using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Data
{
    public class DigitalExaminationsDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DigitalExaminationsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
