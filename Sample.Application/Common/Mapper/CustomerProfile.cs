using AutoMapper;
using Sample.Application.Dtos;

namespace Sample.Application.Common.Mapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Domain.Entities.Customer>().ReverseMap();
    }
}