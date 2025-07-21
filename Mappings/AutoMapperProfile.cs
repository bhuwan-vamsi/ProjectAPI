using AutoMapper;
using APIPractice.Model.Domain;
using APIPractice.Model.DTO;

namespace APIPractice.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            //CreateMap<List<Product>, List<ProductDto>>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
