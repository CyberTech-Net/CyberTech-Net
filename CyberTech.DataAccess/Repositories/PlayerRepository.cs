using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.DataAccess.Repositories
{
    public class PlayerRepository : Repository<PlayerEntity, Guid>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
