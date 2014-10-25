using System;
using System.Collections.Generic;

namespace NHStoreDomain.Domain
{
    public class Customer : BaseEntity
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }

        public virtual DateTime BirthDay { get; set; }
    }
}