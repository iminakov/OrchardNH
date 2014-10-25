using System;
using System.Collections.Generic;
using NHStoreDomain.Domain;
using Orchard;

namespace NHStoreUI.Services
{
    public interface INHStoreService : IDependency
    {

        Customer GetCustomer(int id);

        IEnumerable<Customer> GetCustomers();

        IEnumerable<Order> GetOrders();

    }
}