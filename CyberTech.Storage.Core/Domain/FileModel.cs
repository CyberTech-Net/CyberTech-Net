using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CyberTech.Storage.Core.Domain
{
    public class FileModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] Data { get; set; }
    }
}
