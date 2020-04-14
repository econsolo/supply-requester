using AutoMapper;
using SupplyRequester.Domain.Entities;
using SupplyRequester.Model.DataTransferObjects;

namespace SupplyRequester.Business.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
