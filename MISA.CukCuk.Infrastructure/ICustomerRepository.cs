using MISA.Entity.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Guid customerId);
        IEnumerable<Customer> GetCustomersByCode(string customerCode);
        int AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(Guid customerId);
    }
}
