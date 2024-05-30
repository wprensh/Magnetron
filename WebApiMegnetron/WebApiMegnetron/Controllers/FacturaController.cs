using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Aplication.Dtos.Requests;
using POS.Aplication.Interfaces;
using POS.Aplication.Services;
using POS.Infraestructura.Commons.Bases.Request;

namespace WebApiMegnetron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaApplication _facturaApplication;
        public FacturaController(IFacturaApplication facturaApplication)
        {

            _facturaApplication = facturaApplication;
        }

        [HttpPost]
        public async Task<ActionResult> ListFacturas([FromBody] BaseFiltersRequest filter)
        {
            var respose = await _facturaApplication.ListFacturas(filter);
            return Ok(respose);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> ProductoById(int id)
        {
            var response = await _facturaApplication.FacturaById(id);
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterProducto([FromBody] FacturaRequestDto requestDto)
        {
            var response = await _facturaApplication.ReisterFactura(requestDto);
            return Ok(response);
        }
    }
}
