using CyberTech.Storage.Core.Abstractions.Repositories;

namespace CyberTech.Storage.Api.Dto
{
    public class DataStorageSettings : IDataStorageSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string ChatCollectionName { get; set; }
    }
}
