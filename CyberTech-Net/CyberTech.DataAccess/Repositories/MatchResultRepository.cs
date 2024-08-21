using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess.Repositories
{
    public class MatchResultRepository : Repository<MatchResultEntity, Guid>, IMatchResultRepository
    {
        public MatchResultRepository(ApplicationDbContext context) : base(context)
        {            
        }
    }
}
