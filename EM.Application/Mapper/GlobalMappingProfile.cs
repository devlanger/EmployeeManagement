using AutoMapper;
using EM.Application.Models;
using EM.Core.Models;

namespace EM.Application.Mapper;

public class GlobalMappingProfile : Profile
{
    public GlobalMappingProfile()
    {
        CreateMap<ApplicationUser, ApplicationUserUpdateViewModel>().ReverseMap();
        CreateMap<ApplicationUser, ApplicationUserResponseModel>().ReverseMap();
    }
}