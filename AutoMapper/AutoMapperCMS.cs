using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.DTO.CMS;
using WebAPI_1721030646.Models.CMS;

namespace WebAPI_1721030646.AutoMapper
{
    public class AutoMapperCMS : Profile
    {
        public AutoMapperCMS()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();

            CreateMap<AccountType, AccountTypeDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<Banner, BannerDTO>().ReverseMap();

            CreateMap<Comment, CommentDTO>().ReverseMap();

            CreateMap<Contact, ContactDTO>().ReverseMap();

            CreateMap<Content, ContentDTO>().ReverseMap();

            CreateMap<ContentType, ContentTypeDTO>().ReverseMap();

            CreateMap<Country, CountryDTO>().ReverseMap();

            CreateMap<District, DistrictDTO>().ReverseMap();

            CreateMap<Image, ImageDTO>().ReverseMap();

            CreateMap<Portal, PortalDTO>().ReverseMap();

            CreateMap<Province, ProvinceDTO>().ReverseMap();

            CreateMap<RefreshToken, RefreshTokenDTO>().ReverseMap();

            CreateMap<Ward, WardDTO>().ReverseMap();
        }
    }
}
