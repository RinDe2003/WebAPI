using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.DTO.EFC;
using WebAPI_1721030646.Models.EFC;

namespace WebAPI_1721030646.AutoMapperProfile
{
    public class AutoMapperEFC : Profile
    {
        public AutoMapperEFC()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Supplier, SupplierDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
