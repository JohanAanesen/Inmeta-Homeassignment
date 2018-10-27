using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmeta.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public DateTime DoDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string Service { get; set; }
        public string Info { get; set; }

        //Foreign key for Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
