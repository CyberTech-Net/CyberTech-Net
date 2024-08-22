using CyberTech.MessagesContracts.MongoRecord;
using CyberTech.Storage.Core.Abstractions.Repositories;
using MassTransit;

namespace CyberTech.Storage.Api.Consumers
{
    public class DelRecConsume : IConsumer<MongoRecDeleted>
    {
        private readonly IFileService _fileService;
        private readonly ILogger<DelRecConsume> _logger;

        public DelRecConsume(ILogger<DelRecConsume> logger, IFileService fileService)
        {
            _fileService = fileService;
            _logger = logger;
        }

        public Task Consume(ConsumeContext<MongoRecDeleted> context)
        {
            var message = context.Message;
            if (message != null)
            {
                _logger.LogInformation("{data} Received MongoRecDeleted with Id={id}", DateTime.UtcNow, message.Id);
                _fileService.DeleteFile(message.Id);
            }
            return Task.CompletedTask;
        }
    }
}
