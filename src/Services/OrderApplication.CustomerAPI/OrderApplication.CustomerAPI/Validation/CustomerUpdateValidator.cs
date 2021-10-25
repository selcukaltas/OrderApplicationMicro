using CustomerAPI.ApplicationCore.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.CustomerAPI.Validation
{
    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.CustomerAdress.City).NotEmpty();
            RuleFor(x => x.CustomerAdress.Country).NotEmpty();
            RuleFor(x => x.CustomerAdress.CityCode).NotEmpty();
        }
    }
}
