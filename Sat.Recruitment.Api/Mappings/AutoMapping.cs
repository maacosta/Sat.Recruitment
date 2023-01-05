namespace Sat.Recruitment.Api.Mappings
{
    using AutoMapper;
    using Sat.Recruitment.Api.Dtos;
    using Sat.Recruitment.Api.Models;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDto, User>();
        }
    }
}
