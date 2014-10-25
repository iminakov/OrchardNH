using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHStoreDomain.Domain;

namespace NHStoreDomain.Mapping
{
    public class OrderDetailMap : ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.VersionRecord).Not.Nullable();
            Map(x => x.OrderLine).Not.Nullable();
            Map(x => x.Quantity).Not.Nullable();
            Map(x => x.Rate).Not.Nullable();

            References(x => x.Order).Not.Nullable();
            References(x => x.Product).Not.Nullable();
        }
    }
}
