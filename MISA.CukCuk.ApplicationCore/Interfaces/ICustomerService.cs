using MISA.CukCuk.ApplicationCore.Entities;
using MISA.Entity.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Customer> GetCustomerByCode(string customerCode);
        IEnumerable<Customer> GetCustomerById(Guid customerId);
        ServiceResult AddCustomer(Customer customer);
        ServiceResult UpdateCustomer(Customer customer);
        ServiceResult DeleteCustomer(string customerCode);
    }
}
