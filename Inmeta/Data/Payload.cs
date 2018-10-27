using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmeta.Data
{
    public class Payload
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public string Service { get; set; }
        public DateTime DoDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string Info { get; set; }


        //Payload constructor which can take both customer and order object to initilize
        public Payload(Customer customer, Order order)
        {
            this.CustomerId = customer.Id;
            this.OrderId = order.OrderId;
            this.Name = customer.Name;
            this.Phone = customer.Phone;
            this.Email = customer.Email;
            this.AddressFrom = order.AddressFrom;
            this.AddressTo = order.AddressTo;
            this.Service = order.Service;
            this.DoDate = order.DoDate;
            this.OrderDate = order.OrderDate;
            this.Info = order.Info;
            
        }

        //Returns customer from payload object
        public Customer GetCustomer()
        {
            Customer customer = new Customer
            {
                Id = this.CustomerId,
                Name = this.Name,
                Phone = this.Phone,
                Email = this.Email
            };

            return customer;
        }

        //Returns order from payload object
        public Order GetOrder()
        {
            Order order = new Order
            {
                OrderId = this.OrderId,
                AddressFrom = this.AddressFrom,
                AddressTo = this.AddressTo,
                Service = this.Service,
                DoDate = this.DoDate,
                OrderDate = this.OrderDate,
                Info = this.Info,
                CustomerId = this.CustomerId
            };

            return order;
        }
    }
}
