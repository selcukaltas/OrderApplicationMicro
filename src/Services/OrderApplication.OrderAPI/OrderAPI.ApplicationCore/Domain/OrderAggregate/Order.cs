using OrderApplication.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Domain.OrderAggregate
{
    public class Order : IAggregateRoot,IEntity
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public string Status { get; private set; }
        public Address OrderAddress { get; private set; }

        public Product Product { get; private set; }
        public DateTime CreatedAt { get; private  set; }
        public DateTime UpdatedAt { get; private set; }

        private Order()
        {

        }
        public void UpdateStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentNullException(nameof(status));

            Status = status;
        }
        public Order(Guid customerId,Address orderAddress,Product product,int quantity, double price,string status )
        {
            if (string.IsNullOrWhiteSpace(customerId.ToString())) throw new ArgumentNullException(nameof(customerId));
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentNullException(nameof(status));

            if (Equals(orderAddress,null)) throw new ArgumentNullException(nameof(orderAddress));
            if (Equals(product, null)) throw new ArgumentNullException(nameof(product));
            if (Equals(quantity, null)) throw new ArgumentNullException(nameof(quantity));

            if (Equals(price, null)) throw new ArgumentNullException(nameof(price));

            CustomerId = customerId;

            OrderAddress = orderAddress;

            Product = product;
            Price = price;
            Quantity = quantity;
            Status = status;
        }
    }
}
