﻿using AutoMapper;
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
    public class FacturaMappingProfile : Profile
    {
        public FacturaMappingProfile()
        {
            CreateMap<Facturaencabezado, FacturaResponseDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Facturaencabezado>, BaseEntityResponse<FacturaResponseDto>>()
                .ReverseMap();

            CreateMap<FacturaRequestDto, Facturaencabezado>();

            CreateMap<Facturaencabezado, FacturaSelectResponseDto>()
            .ReverseMap();

            CreateMap<Facturadetalle, FacturadetalleResponseDto>()
                .ForMember(x=>x.ProductoId,x=>x.MapFrom(y=>y.Producto.ProductoId))
                .ForMember(x=>x.fdet_prod_precio,x=>x.MapFrom(y=>y.Producto.prod_precio))
           .ReverseMap();

        }
    }
}
