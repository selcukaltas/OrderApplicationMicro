using FluentValidation;
using OrderAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplication.OrderAPI.Validation
{
    public class OrderChangeStatusValidator : AbstractValidator<OrderChangeStatusDto>
    {
        public OrderChangeStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
