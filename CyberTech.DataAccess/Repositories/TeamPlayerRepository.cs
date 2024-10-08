﻿using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.DataAccess.Repositories
{
    public class TeamPlayerRepository : Repository<TeamPlayerEntity, Guid>, ITeamPlayerRepository
    {
        public TeamPlayerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
