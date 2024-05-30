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
    public interface IFacturaRepository
    {
        Task<BaseEntityResponse<Facturaencabezado>> ListFacturaencabezado(BaseFiltersRequest filters);
        Task<IEnumerable<Facturaencabezado>> GetAllFacturaencabezado();
        Task<Facturaencabezado> GetFacturaencabezadoById(int id);
        Task<bool> RegisterFacturaencabezado(Facturaencabezado factura);
        Task<bool> EditFacturaencabezado(Facturaencabezado factura);
        Task<bool> DeleteFacturaencabezado(int id);
    }
}
