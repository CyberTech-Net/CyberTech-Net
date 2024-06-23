using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class GameTypeRepository : Repository<GameTypeEntity, Guid>, IGameTypeRepository
    {
        public GameTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
