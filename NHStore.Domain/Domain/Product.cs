namespace NHStoreDomain.Domain
{
    public class Product : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}