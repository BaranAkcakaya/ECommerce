using AutoMapper;
using ECommerce.Application.CQRS.User.Commands.CreateUser;
using ECommerce.Application.CQRS.User.Commands.LoginUser;
using ECommerce.Application.Requests.User;

namespace ECommerce.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<LoginUserRequest, LoginUserCommand>()
                .ForMember(dest => dest.FailedCount, act => act.MapFrom(p => 1));
        }
    }
}
