using OrderAPI.ApplicationCore.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Dtos
{
    public class OrderOutputDto
    {
        public Guid Id { get;  set; }
        public Guid CustomerId { get;  set; }
        public int Quantity { get;  set; }
        public double Price { get;  set; }
        public string Status { get;  set; }
        public Address OrderAddress { get;  set; }

        public Product Product { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
