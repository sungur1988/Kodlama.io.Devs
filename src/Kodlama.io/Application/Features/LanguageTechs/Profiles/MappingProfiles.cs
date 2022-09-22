using Application.Features.LanguageTechs.Commands.CreateLanguageTech;
using Application.Features.LanguageTechs.Commands.DeleteLanguageTech;
using Application.Features.LanguageTechs.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechs.Dtos;
using Application.Features.LanguageTechs.Models;
using AutoMapper;
using Core.Persistence.Paging;
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

            CreateMap<LanguageTech, DeleteLanguageTechCommand>().ReverseMap();
            CreateMap<LanguageTech, DeletedLanguageTechDto>().ReverseMap();

            CreateMap<LanguageTech,GetLanguageTechByIdDto>().ReverseMap();

            CreateMap<LanguageTech, LanguageTechListDto>()
                .ForMember(x => x.LanguageName, opt => opt.MapFrom(y => y.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap<IPaginate<LanguageTech>, LanguageTechListModel>().ReverseMap();
        }
    }
}
