using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore
{
    public class CustomerGroupService : ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;

        #region constructor

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        #endregion
        public ServiceResult AddCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteCustomerGroup(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroupById(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroups()
        {
            var customerGroups = _customerGroupRepository.GetCustomerGroups();
            return customerGroups;
        }
    }
}
