using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace CyberTech.Storage.Core.Abstractions.Repositories
{
    public interface IFileService
    {
        Task<Stream> GetFileAsync(string id);
        Task<ICollection<GridFSFileInfo>> GetAllFiles();
        Task<GridFSFileInfo> GetFileInfoAsync(string id);
        Task<ObjectId> UploadFileAsync(IFormFile file);
        Task DeleteFile(string id);
    }
}
