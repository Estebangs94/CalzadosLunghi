using AutoMapper;
using CalzadosLunghi.API.DTO;
using CalzadosLunghi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalzadosLunghi.API.Profiles
{
    public class TipoMaterialProfile : Profile
    {
        public TipoMaterialProfile()
        {
            CreateMap<TipoMaterialForCreationDto, TipoMaterial>();
            CreateMap<TipoMaterial, TipoMaterialDTO>();
        }
    }
}
