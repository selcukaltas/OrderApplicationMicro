using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Dtos
{
    public class OrderChangeStatusDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
