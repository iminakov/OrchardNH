namespace NHStoreDomain.Domain
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        
        public virtual int VersionRecord { get; set; }

    }
}