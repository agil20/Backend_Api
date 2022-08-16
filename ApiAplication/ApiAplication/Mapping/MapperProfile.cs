using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Dtos.ProductDtos;
using ApiAplication.Models;
using AutoMapper;

namespace ApiAplication.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryReturnDto>();
            CreateMap<Product, ProductReturnTo>()
                .ForMember(i=>i.ImageUrl,map=>map.MapFrom(s=> "http://localhost:6393/img/"+s.ImageUrl));
        }
    }
}
