using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_dapper.Context;
using Web_dapper.Models;


namespace Web_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
      
        private readonly DapperContext _dapperContext;

        public ProductoController(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        [HttpGet("GetAll")]
       public IActionResult GetAll()
        {
            var sql = "SELECT * FROM producto";
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var result = connection.Query<Producto>(sql);
                return Ok(result);
            }
        }
        
    }
}
