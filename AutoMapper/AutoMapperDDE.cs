using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.DTO.DDE;
using WebAPI_1721030646.Models.DDE;

namespace WebAPI_1721030646.AutoMapper
{
    public class AutoMapperDDE : Profile
    {
        public AutoMapperDDE()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<Country, CountryDTO>().ReverseMap();

            CreateMap<District, DistrictDTO>().ReverseMap();

            CreateMap<Province, ProvinceDTO>().ReverseMap();

            CreateMap<Ward, ProvinceDTO>().ReverseMap();
        }
    }
}
