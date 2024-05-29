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
    public interface IProductoAplication
    {
        Task<BaseResponse<BaseEntityResponse<ProductosResponseDto>>> ListProductos(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<ProductoSelectResponseDto>>> ListSelectProductos();
        Task<BaseResponse<ProductosResponseDto>> ProductoById(int id);
        Task<BaseResponse<bool>> ReisterProducto(ProductoRequestDto requestDto);
        Task<BaseResponse<bool>> EditProducto(int id, ProductoRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteProducto(int id);


    }
}
