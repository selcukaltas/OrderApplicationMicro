using OrderApplication.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Domain.CustomerAggregate
{
    public class Customer : IAggregateRoot,IEntity
    {
        public Guid  Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Address CustomerAdress { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Customer() { }  //required by Ef

        public Customer(string name,string email,Address customerAdress)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            if (Equals(customerAdress)) throw new ArgumentNullException(nameof(customerAdress));

            Name = name;
            Email = email;
            CustomerAdress = customerAdress;
        }
    }
}
