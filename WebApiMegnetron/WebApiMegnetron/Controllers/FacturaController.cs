using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Aplication.Interfaces;
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
    }
}
