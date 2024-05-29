using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
    public class ProductoAplication : IProductoAplication
    {
        public readonly IUnitOfWork _UnitOfWork;
        public readonly IMapper _mapper;
        public readonly ProductoValidatos _validatos;

        public ProductoAplication(IUnitOfWork unitOfWork, IMapper mapper, ProductoValidatos validations)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validatos = validations;

        }
        public async Task<BaseResponse<BaseEntityResponse<ProductosResponseDto>>> ListProductos(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ProductosResponseDto>>();
            var producto = await _UnitOfWork.ProductoRepository.ListProducto(filters);

            if (producto is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<BaseEntityResponse<ProductosResponseDto>>(producto);
                response.Message = ReplyMessaje.MESSAGE_QUERY;
            }
            else {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
        public async Task<BaseResponse<IEnumerable<ProductoSelectResponseDto>>> ListSelectProductos()
        {
            var response = new BaseResponse<IEnumerable<ProductoSelectResponseDto>>();
            var producto = await _UnitOfWork.ProductoRepository.GetAllProducto();
            if (producto is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<IEnumerable<ProductoSelectResponseDto>>(producto);
                response.Message = ReplyMessaje.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<ProductosResponseDto>> ProductoById(int id)
        {
            var response = new BaseResponse<ProductosResponseDto>();
            var produto = await _UnitOfWork.ProductoRepository.GetProductoById(id);
            if (produto is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<ProductosResponseDto>(produto);
                response.Message = ReplyMessaje.MESSAGE_QUERY;
            }else
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> EditProducto(int id, ProductoRequestDto requestDto)
        {

            var response = new BaseResponse<bool>();

            var productoEdit = await ProductoById(id);

            if (productoEdit.Data is null)
            {

                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;

            }

            var producto = _mapper.Map<Producto>(requestDto);
            producto.id = id;
            response.Data = await _UnitOfWork.ProductoRepository.EditProducto(producto);

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
        public async Task<BaseResponse<bool>> ReisterProducto(ProductoRequestDto requestDto)
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
            var producto = _mapper.Map<Producto>(requestDto);
            response.Data = await _UnitOfWork.ProductoRepository.RegisterProducto(producto);

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
        public async Task<BaseResponse<bool>> DeleteProducto(int id)
        {
            var response = new BaseResponse<bool>();
            var producto = await ProductoById(id);

            if (producto.Data is null)
            {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_QUERY_EMPTY;
            }
            response.Data = await _UnitOfWork.ProductoRepository.DeleteProducto(id);
            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = ReplyMessaje.MESSAGE_QUERY_DELETE;
            }
            else {
                response.IsSucces = false;
                response.Message = ReplyMessaje.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
