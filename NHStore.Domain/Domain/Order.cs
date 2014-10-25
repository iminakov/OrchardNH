using System;
using System.Collections.Generic;
using NHStoreDomain.Enums;

namespace NHStoreDomain.Domain
{
    public class Order : BaseEntity
    {
        public virtual Customer Customer { get; set; }

        public virtual string OrderNumber { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual OrderStatus Status { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}