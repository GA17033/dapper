using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_dapper.Context;
using Web_dapper.Models;

namespace Web_dapper.Repository
{
    public class ProductoRepository :IProductoRepository
    {
        private readonly DapperContext _dbContext;

        public ProductoRepository(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            var sql = "SELECT * FROM producto";
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Producto>(sql);
                return result.ToList();
            }
        }
    }
}
