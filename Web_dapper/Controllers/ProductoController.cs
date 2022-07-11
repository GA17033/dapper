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
                var response = new
                {
                    Status = 200,
                    Message = " Lista De Producto",
                    Data = result
                };
                return Ok(response);
                
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var sql = "SELECT * FROM producto where ProductoId=@id";
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var result = connection.Query<Producto>(sql, new {Id= id}).FirstOrDefault();
                if(result == null)
                {
                    return NotFound("Producto No encontrado");
                }
                var response = new
                {
                    Status = 200,
                    Message = "Producto",
                    Data = result
                };
                return Ok(response);

                
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromForm] Producto producto)
        {
            var sql = "INSERT INTO producto (Name, Price, State) VALUES (@Name, @Price, @State)";
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var result = connection.Execute(sql, producto);
                //return Ok(result);

                var response = new
                {
                    Status = 200,
                    Message = "Producto Creado",
                    Data = producto
                };
                return Ok(response);
            }
        }

               


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var sql = "DELETE FROM producto WHERE ProductoId=@id";
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var result = connection.Execute(sql, new { Id = id });
                var response = new
                {
                    Status = 200,
                    Message = "Producto Eliminado",
                    Data = result
                };
                return Ok(response);
            }
        }

    }
}
