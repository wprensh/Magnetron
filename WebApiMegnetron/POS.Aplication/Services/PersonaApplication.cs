using AutoMapper;
using POS.Aplication.Commons.Base;
using POS.Aplication.Dtos.Requests;
using POS.Aplication.Dtos.Responses;
using POS.Aplication.Interfaces;
using POS.Aplication.Validators.Producto;
using POS.Domain.Entities;
using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Commons.Bases.Response;
using POS.Infraestructura.Persistemces.Interface;
using POS.Utility.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Services
{
    public class PersonaApplication : IPersonaApplication
    {
        public readonly IUnitOfWork _UnitOfWork;
        public readonly IMapper _mapper;
        public readonly PersonaValidatos _validatos;
        public PersonaApplication(IUnitOfWork unitOfWork, IMapper mapper, PersonaValidatos validationRules)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validatos = validationRules;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<BaseResponse<BaseEntityResponse<PersonaResponseDto>>> ListPersona(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<PersonaResponseDto>>();
            var pernonas = await _UnitOfWork.PersonaRepository.ListPersona(filters);

            if (pernonas is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<BaseEntityResponse<PersonaResponseDto>>(pernonas);
                response.Message = ReplyMessaje.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<IEnumerable<PersonaSelectResponseDto>>> ListSelectPersona()
        {
            var response = new BaseResponse<IEnumerable<PersonaSelectResponseDto>>();
            var personas = await _UnitOfWork.ProductoRepository.GetAllProducto();
            if (personas is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<IEnumerable<PersonaSelectResponseDto>>(personas);
                response.Message = ReplyMessaje.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<BaseResponse<PersonaResponseDto>> PersonaById(int id)
        {
            var response = new BaseResponse<PersonaResponseDto>();
            var persona = await _UnitOfWork.PersonaRepository.GetPersonaById(id);
            if (persona is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<PersonaResponseDto>(persona);
                response.Message = ReplyMessaje.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<BaseResponse<bool>> RegisterPersona(PersonaRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validatos.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_VALIDATE;
                response.Erros = validationResult.Errors;
                return response;
            }
            var producto = _mapper.Map<Persona>(requestDto);
            response.Data = await _UnitOfWork.PersonaRepository.RegisterPersona(producto);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = ReplyMessaje.MESSAGE_QUERY_SAVE;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_FAILED;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> EditPersona(int id, PersonaRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var personaEdit = await PersonaById(id);

            if (personaEdit.Data is null)
            {

                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;

            }

            var persona = _mapper.Map<Persona>(requestDto);
            persona.id = id;
            response.Data = await _UnitOfWork.PersonaRepository.EditPersona(persona);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EDIT;

            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_FAILED;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DeletePersona(int id)
        {
            var response = new BaseResponse<bool>();
            var producto = await PersonaById(id);

            if (producto.Data is null)
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }
            response.Data = await _UnitOfWork.PersonaRepository.DeletePersona(id);
            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = ReplyMessaje.MESSAGE_QUERY_DELETE;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_FAILED;
            }

            return response;
        }

        
    }
}
