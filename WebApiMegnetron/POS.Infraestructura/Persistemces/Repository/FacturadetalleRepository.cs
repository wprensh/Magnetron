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
    public class FacturadetalleRepository : GenericRepository<Facturadetalle>, IFacturaDetalleRepository
    {
        private readonly AplicationDbContext _dbContext;
        public FacturadetalleRepository(AplicationDbContext context)
        {
            _dbContext = context;
        }
        public Task<BaseEntityResponse<Facturadetalle>> ListFacturadetalle(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Facturadetalle>> GetAllFacturadetalle()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Facturadetalle>> GetFacturadetalleById(int id)
        {
            var response = await _dbContext.Producto
                            .AsNoTracking()
                            .Join(_dbContext.Facturadetalle, p=>p.ProductoId, fd=>fd.ProductoId,(p,df)
                                => new { Producto = p, Facturadetalle = df })
                            .Where(x=>x.Facturadetalle.id==id)
                            .Select(x =>new Facturadetalle
                            { 
                                ProductoId = x.Producto.ProductoId,
                                Producto = new Producto
                                { 
                                    
                                    ProductoId=x.Producto.ProductoId,
                                    pord_desc = x.Producto.pord_desc,
                                    prod_precio = x.Producto.prod_precio,
                                    prod_costo = x.Producto.prod_costo,
                                    prod_um = x.Producto.prod_um

                                },
                                id = x.Facturadetalle.id,
                                fdet_fenc_id = x.Facturadetalle.fdet_fenc_id,
                                fdet_linea = x.Facturadetalle.fdet_linea,
                                fdet_cantidad = x.Facturadetalle.fdet_cantidad,
                                fdet_prod_precio = x.Facturadetalle.fdet_prod_precio,
                                fdet_prod_utilidad = x.Facturadetalle.fdet_prod_utilidad

                            }).ToListAsync();
            return response;
        }
        public Task<bool> DeleteFacturadetalle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditFacturadetalle(Facturadetalle detallefactura)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RegisterFacturadetalle(Facturadetalle detallefactura)
        {
            throw new NotImplementedException();
        }
    }
}
