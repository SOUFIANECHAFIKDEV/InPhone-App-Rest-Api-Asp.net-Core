using AutoMapper;
using inphone_API.Dtos;
using inphone_API.Model;

namespace inphone_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerForDisplayDto>();
            CreateMap<Button, ButtonsForDisplayDto>();
        }
    }
}