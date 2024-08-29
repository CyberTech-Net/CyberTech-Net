using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.DataAccess.Repositories
{
    public class InfoRepository : Repository<InfoEntity, Guid>, IInfoRepository
    {
        public InfoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
