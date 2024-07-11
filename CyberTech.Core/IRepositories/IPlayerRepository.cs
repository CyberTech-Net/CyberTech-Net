using CyberTech.Domain.Entities;

namespace CyberTech.Core.IRepositories
{
    public interface IPlayerRepository : IRepository<PlayerEntity, Guid>
    {
    }
}
