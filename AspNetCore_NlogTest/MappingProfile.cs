using AutoMapper;
using Contracts5Dot0;
using Domain.Entities;

namespace AspNetCore_NlogTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<OwnerForCreationDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
