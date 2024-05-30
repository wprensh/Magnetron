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
    public interface IFacturaDetalleRepository
    {
        Task<BaseEntityResponse<Facturadetalle>> ListFacturadetalle(BaseFiltersRequest filters);
        Task<IEnumerable<Facturadetalle>> GetAllFacturadetalle();
        Task<IEnumerable<Facturadetalle>> GetFacturadetalleById(int id);
        Task<bool> RegisterFacturadetalle(Facturadetalle facturadetalle);
        Task<bool> EditFacturadetalle(Facturadetalle facturadetalle);
        Task<bool> DeleteFacturadetalle(int id);
    }
}
