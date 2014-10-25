using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using NHStoreDomain.Domain;

namespace NHStoreDomain.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.VersionRecord).Not.Nullable();
            Map(x => x.FirstName).Not.Nullable().Length(200);
            Map(x => x.LastName).Not.Nullable().Length(200);
            Map(x => x.BirthDay).Not.Nullable();
            Map(x => x.Address).Nullable().Length(400);
        }
    }
}
