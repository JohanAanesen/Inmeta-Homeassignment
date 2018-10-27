using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmeta.Data
{
    public class Payload
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public string Service { get; set; }
        public DateTime DoDate { get; set; }
        public string Info { get; set; }

        public Payload()
        {

        }

        //Payload constructor which can take both customer and order object to initilize
        public Payload(Customer customer, Order order)
        {
            this.CustomerId = customer.Id;
            this.Name = customer.Name;
            this.Phone = customer.Phone;
            this.Email = customer.Email;
            this.AddressFrom = order.AddressFrom;
            this.AddressTo = order.AddressTo;
            this.Service = order.Service;
            this.DoDate = order.DoDate;
            this.Info = order.Info;
            
        }

        //Returns customer from payload object
        public Customer GetCustomer()
        {
            Customer customer = new Customer();
            customer.Id = this.CustomerId;
            customer.Name = this.Name;
            customer.Phone = this.Phone;
            customer.Email = this.Email;

            return customer;
        }

        //Returns order from payload object
        public Order GetOrder()
        {
            Order order = new Order();
            order.AddressFrom = this.AddressFrom;
            order.AddressTo = this.AddressTo;
            order.Service = this.Service;
            order.DoDate = this.DoDate;
            order.Info = this.Info;
            order.CustomerId = this.CustomerId;

            return order;
        }
    }
}
