using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_dapper.Models;
using Web_dapper.Repository;

namespace Web_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            var productos = await _productoRepository.GetAll();
            return Ok(productos);
        }
    }
}
