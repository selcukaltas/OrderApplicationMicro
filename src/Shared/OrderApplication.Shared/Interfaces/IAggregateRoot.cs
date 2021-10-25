using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Shared.Interfaces
{
    public interface IAggregateRoot
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}
