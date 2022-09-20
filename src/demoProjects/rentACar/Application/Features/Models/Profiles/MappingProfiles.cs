using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles:Profile
    {

        //hangi yerlerin mapleniceğini belirtiyoruz..
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>().ForMember(c=>c.BrandName,opt=>opt.MapFrom(c=>c.Brand.Name)).ReverseMap(); // database'deki foreign key mantığının aynısı ,
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

        }
    }
}


// CreateMap<Model, ModelListDto>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap(); // database'deki foreign key mantığının aynısı ,
//örneğin brand database'inde name var, model da da brandname var bunların aynı olduğunu söylemek için foreign key kullanırız. aynı mantık da üstteki kod