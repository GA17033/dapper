using System.Collections.Generic;
using System.Threading.Tasks;
using Web_dapper.Models;

namespace Web_dapper.Repository
{
    public interface IProductoRepository
    {
        public Task<IEnumerable<Producto>> GetAll();
    }
}
