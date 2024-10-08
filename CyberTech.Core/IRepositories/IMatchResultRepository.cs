﻿using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.IRepositories
{
    public interface IMatchResultRepository : IRepository<MatchResultEntity, Guid>
    {
    }
}