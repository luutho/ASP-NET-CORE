using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class CustomerRepository2 : ICustomerRepository
    {

        public int DeleteCustomerByCode(string customerCode)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByCode(string customerCode)
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
