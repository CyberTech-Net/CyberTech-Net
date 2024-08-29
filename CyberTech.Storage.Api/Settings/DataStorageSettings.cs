using CyberTech.Storage.Core.Abstractions.Repositories;

namespace CyberTech.Storage.Api.Settings
{
    public class DataStorageSettings : IDataStorageSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string ChatCollectionName { get; set; }
    }
}
