using AutoMapper;
using CyberTech.Core.Dto.Info;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class InfoService : IInfoService
    {
        private readonly IMapper _mapper;
        private readonly IInfoRepository _infoRepository;

        public InfoService(IMapper mapper, IInfoRepository infoRepository)
        {
            _mapper = mapper;
            _infoRepository = infoRepository;
        }

        public async Task<InfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var info = await _infoRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<InfoEntity, InfoDto>(info);
        }

        public async Task<Guid> CreateAsync(CreatingInfoDto creatingInfoDto)
        {
            var info = _mapper.Map<CreatingInfoDto, InfoEntity>(creatingInfoDto);
            var creatingInfo = await _infoRepository.AddAsync(info);
            await _infoRepository.SaveChangesAsync();
            return creatingInfo.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingInfoDto updatingInfoDto)
        {
            var info = await _infoRepository.GetAsync(id, CancellationToken.None);
            if (info == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            info.TextInfo = updatingInfoDto.TextInfo;
            info.TitleInfo = updatingInfoDto.TitleInfo;
            info.DataInfo = updatingInfoDto.DataInfo;
            _infoRepository.Update(info);
            await _infoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var info = await _infoRepository.GetAsync(id, CancellationToken.None);
            if (info == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _infoRepository.Delete(info);
            await _infoRepository.SaveChangesAsync();
        }

        public async Task<ICollection<InfoDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<InfoEntity> entities = await _infoRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<InfoEntity>, ICollection<InfoDto>>(entities);
        }

        public async Task<ICollection<InfoDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<InfoEntity> entities = await _infoRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<InfoEntity>, ICollection<InfoDto>>(entities);
        }
    }
}
