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
    public class PersonController : ControllerBase
    {
        private readonly IPersonaApplication _personaAplication;
        public PersonController(IPersonaApplication personaApplication)
        {
            _personaAplication = personaApplication;
        }

        [HttpPost]
        public async Task<ActionResult> ListPersona([FromBody] BaseFiltersRequest filter)
        {
            var respose = await _personaAplication.ListPersona(filter);
            return Ok(respose);
        }

        [HttpGet("select")]
        public async Task<ActionResult> ListSelectPersona()
        {
            var response = await _personaAplication.ListSelectPersona();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> PersonaById(int id)
        {
            var response = await _personaAplication.PersonaById(id);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterPersona([FromBody] PersonaRequestDto requestDto)
        {
            var response = await _personaAplication.RegisterPersona(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<ActionResult> RegisterProducto(int id, [FromBody] PersonaRequestDto requestDto)
        {
            var response = await _personaAplication.EditPersona(id, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{id:int}")]
        public async Task<ActionResult> RemovePersona(int id)
        {
            var response = await _personaAplication.DeletePersona(id);
            return Ok(response);
        }
    }
}
