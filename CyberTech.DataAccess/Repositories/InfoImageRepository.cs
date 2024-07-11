using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class InfoImageRepository : Repository<InfoImageEntity, Guid>, IInfoImageRepository
    {
        public InfoImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}