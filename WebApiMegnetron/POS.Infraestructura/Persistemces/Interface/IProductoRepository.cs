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
    public interface IProductoRepository
    {
        Task<BaseEntityResponse<Producto>> ListProducto(BaseFiltersRequest filters);
        Task<IEnumerable<Producto>> GetAllProducto();
        Task<Producto> GetProductoById(int id);
        Task<bool> RegisterProducto(Producto producto);
        Task<bool> EditProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}
