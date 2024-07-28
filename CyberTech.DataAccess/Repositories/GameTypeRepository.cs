using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.DataAccess.Repositories
{
    public class GameTypeRepository : Repository<Game, Guid>, IGameTypeRepository
    {
        public GameTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
