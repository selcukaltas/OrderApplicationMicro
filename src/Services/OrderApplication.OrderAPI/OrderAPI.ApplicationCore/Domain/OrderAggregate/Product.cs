using OrderApplication.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Domain.OrderAggregate
{
    public class Product : IEntity
    {
        public Guid Id { get; private set; }
        public string ImageUrl { get; private set; }
        public string Name { get; private set; }

        private Product() { }

        public Product(string imageUrl,string name)
        {
            ImageUrl = imageUrl;
            Name = name;
        }
    }
}
