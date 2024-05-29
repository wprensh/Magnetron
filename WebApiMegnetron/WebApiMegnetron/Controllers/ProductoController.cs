using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Aplication.Dtos.Requests;
using POS.Aplication.Interfaces;
using POS.Infraestructura.Commons.Bases.Request;

namespace WebApiMegnetron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoAplication _productoAplication;

        public ProductoController(IProductoAplication productoAplication)
        {
            _productoAplication = productoAplication;   
        }

        [HttpPost]
        public async Task<ActionResult> ListProductos([FromBody] BaseFiltersRequest filter) { 
            var respose = await _productoAplication.ListProductos(filter);
            return Ok(respose);
        }

        [HttpGet("select")]
        public async Task<ActionResult> ListSelectProducto() { 
            var response = await _productoAplication.ListSelectProductos();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> ProductoById(int id)
        {
            var response = await _productoAplication.ProductoById(id);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterProducto([FromBody] ProductoRequestDto requestDto)
        { 
            var response = await _productoAplication.ReisterProducto(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<ActionResult> RegisterProducto(int id,[FromBody] ProductoRequestDto requestDto)
        {
            var response = await _productoAplication.EditProducto(id, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{id:int}")]
        public async Task<ActionResult> RemoveProducto(int id)
        {
            var response = await _productoAplication.DeleteProducto(id);
            return Ok(response);
        }

    }
}
