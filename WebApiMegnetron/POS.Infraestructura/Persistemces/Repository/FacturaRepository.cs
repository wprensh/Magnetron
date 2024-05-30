using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Commons.Bases.Response;
using POS.Infraestructura.Persistemces.Context;
using POS.Infraestructura.Persistemces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Persistemces.Repository
{
    public class FacturaRepository : GenericRepository<Facturaencabezado>, IFacturaRepository
    {
        private readonly AplicationDbContext _dbContext;
        public FacturaRepository(AplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<BaseEntityResponse<Facturaencabezado>> ListFacturaencabezado(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Facturaencabezado>();
            var facturas = (from p in _dbContext.Facturaencabezado
                             select p).AsNoTracking()
                             .AsQueryable();
            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        facturas = facturas.Where(p => p.Persona.per_identificacion.Contains(filters.TextFilter));
                        break;
                }
            }
            if (filters.sort is null) filters.sort = "fenc_id";
            response.TotalRecords = await facturas.CountAsync();
            response.Items = await Ordering(filters, facturas, !(bool)filters.Download!).ToListAsync();
            return response;
        }
        public async Task<IEnumerable<Facturaencabezado>> GetAllFacturaencabezado()
        {
            var producto = await _dbContext.Facturaencabezado.AsNoTracking().ToListAsync();
            return producto!;
        }
        public async Task<Facturaencabezado> GetFacturaencabezadoById(int id)
        {
            var producto = await _dbContext.Facturaencabezado.AsNoTracking().FirstOrDefaultAsync(x => x.fenc_id.Equals(id));
            return producto!;
        }
        public async Task<bool> RegisterFacturaencabezado(Facturaencabezado facturadetalle)
        {
            await _dbContext.Facturaencabezado.AddAsync(facturadetalle);
            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> EditFacturaencabezado(Facturaencabezado facturadetalle)
        {
            _dbContext.Update(facturadetalle);
            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> DeleteFacturaencabezado(int id)
        {
            var factura = await _dbContext.Facturaencabezado.AsNoTracking().SingleOrDefaultAsync(x => x.fenc_id.Equals(id));

            factura!.fenc_fecha = DateTime.Now;


            _dbContext.Update(factura);

            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

    }
}
