namespace NHStoreDomain.Domain
{
    public class OrderDetail : BaseEntity
    {
        public virtual int OrderLine { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual decimal Rate { get; set; }

        public virtual int Quantity { get; set; }
    }
}