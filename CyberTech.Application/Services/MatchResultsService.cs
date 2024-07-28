using AutoMapper;
using CyberTech.Core.Dto.MatchResult;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Core.Mapping;

namespace CyberTech.Application.Services
{
    public class MatchResultsService(IMatchResultRepository matchResultsRepository) : IMatchResultsService
    {
        private readonly IMatchResultRepository _matchResultsRepository = matchResultsRepository;

        public async Task<ResultDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _matchResultsRepository.GetAsync(id, CancellationToken.None);
            if (result == null)
                return default;

            return MatchResultMapper.ConvertToDto(result);
        }

        public async Task<Guid> CreateAsync(CreatingResultDto creatingResultDto)
        {
            var creatingResult = await _matchResultsRepository.AddAsync(MatchResultMapper.ConvertToBaseModel(creatingResultDto));
            try
            {
                await _matchResultsRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return creatingResult.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingResultDto resultDto)
        {
            var result = await _matchResultsRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");

            result.Update(resultDto.Score, resultDto.IsWin);
            _matchResultsRepository.Update(result);
            await _matchResultsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _matchResultsRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _matchResultsRepository.Delete(result);
            await _matchResultsRepository.SaveChangesAsync();
        }

        public async Task<List<ResultDto>?> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _matchResultsRepository.GetAllAsync(cancellationToken);
            if (entities == null)
                return default;

            return MatchResultMapper.ConvertToDto(entities);
        }
    }
}
