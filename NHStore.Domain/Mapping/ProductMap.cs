using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHStoreDomain.Domain;

namespace NHStoreDomain.Mapping
{
    public class ProductMap :ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.VersionRecord).Not.Nullable();
            Map(x => x.Name).Not.Nullable().Length(200);
            Map(x => x.Description).Not.Nullable().Length(400);
        }
    }
}
