using System;
using System.Collections.Generic;

namespace NHStoreUI.ViewModel
{
    public class NHStoreViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }

    public class OrderViewModel
    {
        public string ShipToCustomerFirstName { get; set; }

        public string ShipToCustomerLastName { get; set; }

        public string ShipToCustomerAddress { get; set; }

        public DateTime ShipToCustomerBirthDay { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderCreationDate { get; set; }

        public String OrderStatus { get; set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int OrderLine { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Rate { get; set; }

        public int Quantity { get; set; }
    }
}