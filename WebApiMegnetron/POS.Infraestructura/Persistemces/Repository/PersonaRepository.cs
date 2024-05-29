using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Commons.Bases.Response;
using POS.Infraestructura.Persistemces.Context;
using POS.Infraestructura.Persistemces.Interface;


namespace POS.Infraestructura.Persistemces.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {

        private readonly AplicationDbContext _dbContext;

        public PersonaRepository(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseEntityResponse<Persona>> ListPersona(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Persona>();
            var personas = (from p in _dbContext.Persona
                            select p).AsNoTracking().AsQueryable();
            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        personas = personas.Where(p => p.per_nombre.Contains(filters.TextFilter));
                        break;
                }
            }
            if (filters.sort is null) filters.sort = "id";
            response.TotalRecords = await personas.CountAsync();
            response.Items = await Ordering(filters, personas, !(bool)filters.Download!).ToListAsync();
            return response;
        }
        public async Task<IEnumerable<Persona>> GetAllPersona()
        {
            var personas = await _dbContext.Persona.AsNoTracking().ToListAsync();
            return personas;
        }

        public async Task<Persona> GetPersonaById(int id)
        {
            var persona = await _dbContext.Persona.AsNoTracking().FirstOrDefaultAsync(x => x.id.Equals(id));
            return persona!;
        }

        public async Task<bool> RegisterPersona(Persona persona)
        {
            await _dbContext.Persona.AddAsync(persona);
            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> EditPersona(Persona persona)
        {
            _dbContext.Update(persona);
            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeletePersona(int id)
        {
            var persona = await _dbContext.Persona.AsNoTracking().SingleOrDefaultAsync(x => x.id.Equals(id));

            persona!.per_nombre =string.Empty;
            persona!.per_apellidos = string.Empty;


            _dbContext.Update(persona);

            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

        
    }
}
