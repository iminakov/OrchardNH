using System;
using System.Collections.Generic;
using System.Linq;
using NHStoreDomain.Domain;
using Orchard.Data;
using Orchard.Logging;

namespace NHStoreUI.Services
{
    public class NHStoreService : INHStoreService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ISessionLocator _sessionLocator;

        public NHStoreService(IRepository<Customer> customerRepository,
                              ISessionLocator sessionLocator)
        {
            _customerRepository = customerRepository;
            _sessionLocator = sessionLocator;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.Table.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.Table.ToList();
        }

        public IEnumerable<Order> GetOrders()
        {
            var session = _sessionLocator.For(typeof (Order));

            return session.QueryOver<Order>().Fetch(x => x.Customer).Eager.Fetch(x => x.OrderDetails).Eager.List<Order>().Distinct();
        }
    }
}