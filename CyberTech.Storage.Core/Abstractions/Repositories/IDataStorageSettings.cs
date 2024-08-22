namespace CyberTech.Storage.Core.Abstractions.Repositories
{
    public interface IDataStorageSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string ChatCollectionName { get; set; }
    }
}
