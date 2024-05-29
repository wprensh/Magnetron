using AutoMapper;
using POS.Aplication.Dtos.Requests;
using POS.Aplication.Dtos.Responses;
using POS.Domain.Entities;
using POS.Infraestructura.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Mappers
{
    public class ProductoMappingProfile:Profile
    {
        public ProductoMappingProfile()
        {
            CreateMap<Producto, ProductosResponseDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Producto>, BaseEntityResponse<ProductosResponseDto>>()
                .ReverseMap();

            CreateMap<ProductoRequestDto, Producto>();

            CreateMap<Producto, ProductoSelectResponseDto>()
            .ReverseMap();

        }
    }
}
