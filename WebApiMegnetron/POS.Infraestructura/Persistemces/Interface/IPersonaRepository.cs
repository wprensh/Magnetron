using POS.Domain.Entities;
using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Persistemces.Interface
{
    public interface IPersonaRepository
    {
        Task<BaseEntityResponse<Persona>> ListPersona(BaseFiltersRequest filters);
        Task<IEnumerable<Persona>> GetAllPersona();
        Task<Persona> GetPersonaById(int id);
        Task<bool> RegisterPersona(Persona persona);
        Task<bool> EditPersona(Persona persona);
        Task<bool> DeletePersona(int id);
    }
}
