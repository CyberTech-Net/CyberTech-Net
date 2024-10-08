﻿using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.IRepositories
{
    public interface IInfoRepository : IRepository<InfoEntity, Guid>
    {
        Task<List<InfoEntity>> GetPagedAsync(int page, int itemsPerPage);
    }
}
