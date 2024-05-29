using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Commons.Bases.Response;
using POS.Infraestructura.Persistemces.Context;
using POS.Infraestructura.Persistemces.Interface;


namespace POS.Infraestructura.Persistemces.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly AplicationDbContext _dbContext;
        public ProductoRepository(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseEntityResponse<Producto>> ListProducto(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Producto>();
            var productos = (from p in _dbContext.Producto
                             select p).AsNoTracking().AsQueryable();
            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter)) {
                switch (filters.NumFilter)
                {
                    case 1:
                        productos = productos.Where(p => p.pord_desc.Contains(filters.TextFilter));
                        break;
                }
            }
            if (filters.sort is null) filters.sort = "id";
            response.TotalRecords = await productos.CountAsync();
            response.Items = await Ordering(filters, productos,!(bool)filters.Download!).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Producto>> GetAllProducto()
        {
            var producto = await _dbContext.Producto.AsNoTracking().ToListAsync();
            return producto;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            var producto = await _dbContext.Producto.AsNoTracking().FirstOrDefaultAsync(x => x.id.Equals(id));
            return producto!;
        }

        public async Task<bool> RegisterProducto(Producto producto)
        {
           await _dbContext.Producto.AddAsync(producto);
            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> EditProducto(Producto producto)
        {
             _dbContext.Update(producto);
            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async  Task<bool> DeleteProducto(int id)
        {
            
            var producto = await _dbContext.Producto.AsNoTracking().SingleOrDefaultAsync(x=>x.id.Equals(id));

            producto!.prop_precio = 0;
            producto!.prod_costo = 0;


            _dbContext.Update(producto);

            var recordsAffected = await _dbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

        

        
    }
}
