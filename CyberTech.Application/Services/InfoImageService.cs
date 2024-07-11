using AutoMapper;
using CyberTech.Core.Dto.InfoImage;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class InfoImageService : IInfoImageService
    {
        private readonly IMapper _mapper;
        private readonly IInfoImageRepository _infoImageRepository;

        public InfoImageService(IMapper mapper, IInfoImageRepository infoImageRepository)
        {
            _mapper = mapper;
            _infoImageRepository = infoImageRepository;
        }

        public async Task<InfoImageDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var info = await _infoImageRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<InfoImageEntity, InfoImageDto>(info);
        }

        public async Task<Guid> CreateAsync(CreatingInfoImageDto creatingInfoImageDto)
        {
            var info = _mapper.Map<CreatingInfoImageDto, InfoImageEntity>(creatingInfoImageDto);
            var creatingInfoImage = await _infoImageRepository.AddAsync(info);
            await _infoImageRepository.SaveChangesAsync();
            return creatingInfoImage.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingInfoImageDto updatingInfoImageDto)
        {
            var infoImage = await _infoImageRepository.GetAsync(id, CancellationToken.None);
            if (infoImage == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            infoImage.ImageId = updatingInfoImageDto.ImageId;
            infoImage.InfoId = updatingInfoImageDto.InfoId;            
            _infoImageRepository.Update(infoImage);
            await _infoImageRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var infoImage = await _infoImageRepository.GetAsync(id, CancellationToken.None);
            if (infoImage == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _infoImageRepository.Delete(infoImage);
            await _infoImageRepository.SaveChangesAsync();
        }

        public async Task<ICollection<InfoImageDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<InfoImageEntity> entities = await _infoImageRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<InfoImageEntity>, ICollection<InfoImageDto>>(entities);
        }
    }
}
