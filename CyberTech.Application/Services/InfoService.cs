﻿using AutoMapper;
using CyberTech.Core.Dto.News;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Core.Mapping;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Application.Services
{
    public class InfoService(IInfoRepository infoRepository) : IInfoService
    {
        private readonly IInfoRepository _infoRepository = infoRepository;

        public async Task<NewsDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var info = await _infoRepository.GetAsync(id, CancellationToken.None);
            if (info == null)
                return default;

            return NewsMapper.ConvertToDto(info);
        }

        public async Task<Guid> CreateAsync(CreatingNewsDto creatingInfoDto)
        {
            var creatingInfo = await _infoRepository.AddAsync(NewsMapper.ConvertToBaseModel(creatingInfoDto));
            await _infoRepository.SaveChangesAsync();
            return creatingInfo.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingNewsDto updatingInfoDto)
        {
            var info = await _infoRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");

            info.Update(title: updatingInfoDto.Title,
                text: updatingInfoDto.Text,
                date: updatingInfoDto.Date,
                imageId: updatingInfoDto.ImageId);
            _infoRepository.Update(info);
            await _infoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var info = await _infoRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _infoRepository.Delete(info);
            await _infoRepository.SaveChangesAsync();
        }

        public async Task<List<NewsDto>> GetPagedAsync(int page, int pageSize)
        {
            var entities = await _infoRepository.GetPagedAsync(page, pageSize);
            if (entities == null)
                return default;
            return NewsMapper.ConvertToDto(entities);
        }

        public async Task<List<NewsDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _infoRepository.GetAllAsync(cancellationToken);
            if (entities == null)
                return default;
            return NewsMapper.ConvertToDto(entities);
        }
    }
}
