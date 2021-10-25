using AutoMapper;
using OrderAPI.ApplicationCore.Domain.OrderAggregate;
using OrderAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderOutputDto>();
        }
    }
}
