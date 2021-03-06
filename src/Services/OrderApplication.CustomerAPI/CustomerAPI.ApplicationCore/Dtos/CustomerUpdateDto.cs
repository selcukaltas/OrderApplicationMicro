using CustomerAPI.ApplicationCore.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Dtos
{
    public class CustomerUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address CustomerAdress { get; set; }
    }
}
