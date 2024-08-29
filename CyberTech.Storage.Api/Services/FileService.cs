using CyberTech.Storage.Core.Abstractions.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace CyberTech.Storage.Api.Services
{
    public class FileService : IFileService
    {
        private readonly IMongoDatabase _database;

        public FileService(IDataStorageSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _database = database;
        }

        public async Task<Stream> GetFileAsync(string id)
        {
            IGridFSBucket gridFS = new GridFSBucket(_database);
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", new ObjectId(id));
            var file = await gridFS.Find(filter).FirstOrDefaultAsync();
            if (file == null)
            {
                throw new FileNotFoundException($"File with id {id} not found");
            }
            return await gridFS.OpenDownloadStreamAsync(file.Id);
        }


        public async Task<ObjectId> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file was provided");
            }

            using (var stream = file.OpenReadStream())
            {
                IGridFSBucket gridFS = new GridFSBucket(_database);
                return await gridFS.UploadFromStreamAsync(file.FileName, stream);
            }
        }

        public async Task DeleteFile(string id)
        {
            IGridFSBucket gridFS = new GridFSBucket(_database);
            await gridFS.DeleteAsync(new ObjectId(id));
        }


        public async Task<GridFSFileInfo> GetFileInfoAsync(string id)
        {
            IGridFSBucket gridFS = new GridFSBucket(_database);
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", new ObjectId(id));
            var fileModel = await gridFS.Find(filter).FirstOrDefaultAsync();
            if (fileModel == null)
            {
                throw new FileNotFoundException($"File with id {id} not found");
            }

            return fileModel;
        }

        public async Task<ICollection<GridFSFileInfo>> GetAllFiles()
        {
            IGridFSBucket gridFS = new GridFSBucket(_database);
            var files = await gridFS.FindAsync("{}");
            return await files.ToListAsync();
        }

    }
}
