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
    public class PersonaMappingProfile : Profile
    {
        public PersonaMappingProfile()
        {
            CreateMap<Persona, PersonaResponseDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Persona>, BaseEntityResponse<PersonaResponseDto>>()
                .ReverseMap();

            CreateMap<PersonaRequestDto, Persona>();

            CreateMap<Persona, PersonaSelectResponseDto>()
            .ReverseMap();

        }
    }
}
