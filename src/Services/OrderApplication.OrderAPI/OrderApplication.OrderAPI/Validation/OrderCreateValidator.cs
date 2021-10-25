using FluentValidation;
using OrderAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.OrderAPI.Validation
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateValidator()
        {

            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Product.ImageUrl).NotEmpty();
            RuleFor(x => x.Product.Name).NotEmpty();
            RuleFor(x => x.OrderAddress.AddressLine).NotEmpty();
            RuleFor(x => x.OrderAddress.City).NotEmpty();
            RuleFor(x => x.OrderAddress.CityCode).NotEmpty();
            RuleFor(x => x.OrderAddress.Country).NotEmpty();
        }
    }
}
