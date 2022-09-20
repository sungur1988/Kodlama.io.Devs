using Application.Features.LanguageTechs.Commands.CreateLanguageTech;
using Application.Features.LanguageTechs.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechs.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTech,CreateLanguageTechCommand>().ReverseMap();
            CreateMap<LanguageTech, CreatedLanguageTechDto>().ReverseMap();
            CreateMap<LanguageTech, UpdateLanguageTechCommand>().ReverseMap();
            CreateMap<LanguageTech, UpdatedLanguageTechDto>()
                .ForMember(x => x.LanguageTechName, opt => opt.MapFrom(y => y.Name))
                .ReverseMap();
        }
    }
}
