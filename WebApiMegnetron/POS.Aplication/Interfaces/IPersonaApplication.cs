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
    public interface IPersonaApplication
    {
        Task<BaseResponse<BaseEntityResponse<PersonaResponseDto>>> ListPersona(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<PersonaSelectResponseDto>>> ListSelectPersona();
        Task<BaseResponse<PersonaResponseDto>> PersonaById(int id);
        Task<BaseResponse<bool>> RegisterPersona(PersonaRequestDto requestDto);
        Task<BaseResponse<bool>> EditPersona(int id, PersonaRequestDto requestDto);
        Task<BaseResponse<bool>> DeletePersona(int id);
    }
}
