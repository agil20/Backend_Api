using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Dtos.ProductDtos;
using ApiAplication.Models;
using AutoMapper;
using System.Collections.Generic;

namespace ApiAplication.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryReturnDto>();
            CreateMap<Product, ProductReturnTo>()
                .ForMember(i=>i.ImageUrl,map=>map.MapFrom(s=> "http://localhost:6393/img/"+s.ImageUrl));


            CreateMap<List<CategoryReturnDto>,CetogoryListDto>()
                .ForMember(l=>l.TotalCount,map=>map.MapFrom(s=>s.Count))
                .ForMember(l=>l.Items,map=>map.MapFrom(s=>s));
            CreateMap<List<ProductReturnTo>, ProductListDto>()
             .ForMember(l => l.TotalCount, map => map.MapFrom(s => s.Count))
             .ForMember(l => l.Items, map => map.MapFrom(s => s));
        }
    }
}
