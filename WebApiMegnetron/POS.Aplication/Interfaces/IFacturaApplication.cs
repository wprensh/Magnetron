using POS.Aplication.Commons.Base;
using POS.Aplication.Dtos.Requests;
using POS.Aplication.Dtos.Responses;
using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Interfaces
{
    public interface IFacturaApplication
    {
        
        Task<BaseResponse<BaseEntityResponse<FacturaResponseDto>>> ListFacturas(BaseFiltersRequest filter);
        Task<BaseResponse<IEnumerable<FacturaSelectResponseDto>>> ListFacturas();
        Task<BaseResponse<FacturaResponseDto>> FacturaById(int id);
        Task<BaseResponse<bool>> ReisterFactura(FacturaRequestDto requestDto);
        Task<BaseResponse<bool>> EditFactura(int id, FacturaRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteFactura(int id);
    }
}
