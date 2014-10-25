using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHStoreDomain.Domain;
using NHStoreDomain.Enums;

namespace NHStoreDomain.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.VersionRecord).Not.Nullable();
            Map(x => x.OrderNumber).Not.Nullable();
            Map(x => x.CreationDate).Not.Nullable();
            Map(x => x.Status).Not.Nullable().CustomType(typeof(OrderStatus));

            HasMany(x => x.OrderDetails).Inverse().Cascade.AllDeleteOrphan();

            References(x => x.Customer).Not.Nullable();
        }
    }
}
