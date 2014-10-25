using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHStoreDomain.Domain;
using NHibernate.Cfg;
using Orchard.Data;
using Orchard.Logging;
using Orchard.Utility;

namespace NHStoreUI
{
    public class PersistenceConfiguration : ISessionConfigurationEvents
    {
        public PersistenceConfiguration()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Created(FluentConfiguration cfg, AutoPersistenceModel defaultModel)
        {
            cfg.Mappings(x => x.FluentMappings.AddFromAssemblyOf<Customer>());
        }

        public void Prepared(FluentConfiguration cfg)
        {

        }

        public void Building(Configuration cfg)
        {

        }

        public void Finished(Configuration cfg)
        {

        }

        public void ComputingHash(Hash hash)
        {
            hash.AddString("NHStore.Domain.Mapping");
        }
    }
}