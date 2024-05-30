using AutoMapper;
using FluentValidation;
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
    public class FacturaApplication : IFacturaApplication
    {
        public readonly IUnitOfWork _UnitOfWork;
        public readonly IMapper _mapper;
        public readonly FacturaValidatos _validatos;
        public FacturaApplication(IUnitOfWork unitOfWork, IMapper mapper, FacturaValidatos validations)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validatos = validations;

        }

        public async Task<BaseResponse<BaseEntityResponse<FacturaResponseDto>>> ListFacturas(BaseFiltersRequest filter)
        {
            var response = new BaseResponse<BaseEntityResponse<FacturaResponseDto>>();
            try
            {
                var facturas = await _UnitOfWork.facturaRepository.ListFacturaencabezado(filter);
                if (facturas is not null)
                {
                    response.IsSucces = true;
                    response.Data = _mapper.Map<BaseEntityResponse<FacturaResponseDto>>(facturas);
                    response.Message = ReplyMessaje.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSucces = false;
                    response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
                }


            }
            catch (Exception)
            {

                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_FAILED;
            }
            return response;
        }
        public async Task<BaseResponse<FacturaResponseDto>> FacturaById(int id)
        {

            var response = new BaseResponse<FacturaResponseDto>();
            var factura = await _UnitOfWork.facturaRepository.GetFacturaencabezadoById(id);
            if (factura is null)
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_FAILED;
                return response;
            }

            response.IsSucces = true;
            var facturaDetalle = await _UnitOfWork.facturadetalleRepository.GetFacturadetalleById(factura.fenc_id);
            factura.Facturadetalles = facturaDetalle.ToList();
            response.Data = _mapper.Map<FacturaResponseDto>(factura);
            response.Message = ReplyMessaje.MESSAGE_QUERY;

            return response;
        }

        public Task<BaseResponse<bool>> DeleteFactura(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditFactura(int id, FacturaRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<FacturaSelectResponseDto>>> ListFacturas()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<bool>> ReisterFactura(FacturaRequestDto requestDto)
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
            var producto = _mapper.Map<Facturaencabezado>(requestDto);
            response.Data = await _UnitOfWork.facturaRepository.RegisterFacturaencabezado(producto);

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
    }
}
