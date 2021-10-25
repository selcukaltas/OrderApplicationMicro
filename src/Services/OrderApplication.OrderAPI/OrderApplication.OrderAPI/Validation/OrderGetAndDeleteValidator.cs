using FluentValidation;
using OrderAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplication.OrderAPI.Validation
{
    public class OrderGetAndDeleteValidator : AbstractValidator<OrderGetAndDeleteDto>
    {
        public OrderGetAndDeleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
