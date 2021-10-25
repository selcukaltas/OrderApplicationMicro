using AutoMapper;
using CustomerAPI.ApplicationCore.Domain.CustomerAggregate;
using CustomerAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<Customer, CustomerOutputDto>();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
