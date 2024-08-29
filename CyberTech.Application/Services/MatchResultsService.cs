using AutoMapper;
using CyberTech.Core.Dto.MatchResult;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Tournaments;
using System.Text.Json;

namespace CyberTech.Application.Services
{
    public class MatchResultsService : IMatchResultService
    {
        private readonly IMatchResultRepository _matchResultRepository;
        private readonly IMapper _mapper;

        public MatchResultsService(IMapper mapper, IMatchResultRepository matchResultRepository)
        {
            _mapper = mapper;
            _matchResultRepository = matchResultRepository;
        }

        public async Task<MatchResultDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _matchResultRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<MatchResultEntity, MatchResultDto>(result);            
        }

        public async Task<Guid> CreateAsync(CreatingMatchResultDto creatingResultDto)
        {
            var result = _mapper.Map<CreatingMatchResultDto, MatchResultEntity>(creatingResultDto);
            var creatingMatchResult = await _matchResultRepository.AddAsync(result);
            await _matchResultRepository.SaveChangesAsync();
            return creatingMatchResult.Id;
        }

        public async Task CreateResultAsync(CreatingMatchResultDto creatingResultDtoFirst, CreatingMatchResultDto creatingResultDtoSecond)
        {
            /*var item1 = _mapper.Map<CreatingMatchResultDto, MatchResultEntity>(creatingResultDtoList[0]);
            item1.Id = new Guid();
            var item2 = _mapper.Map<CreatingMatchResultDto, MatchResultEntity>(creatingResultDtoList[1]);
            item2.Id = new Guid();
            var creatingList = new List<MatchResultEntity>
            {
                item1,
                item2
            };*/
            
            await CreateAsync(creatingResultDtoFirst);
            await CreateAsync(creatingResultDtoSecond);
            Console.WriteLine(JsonSerializer.Serialize<MatchResultEntity>(_mapper.Map <CreatingMatchResultDto, MatchResultEntity> (creatingResultDtoFirst)));
            Console.WriteLine(JsonSerializer.Serialize<MatchResultEntity>(_mapper.Map<CreatingMatchResultDto, MatchResultEntity>(creatingResultDtoSecond)));

            /*
            var result = _mapper.Map<CreatingMatchResultDto, MatchResultEntity>(creatingResultDtoFirst);
            var creatingMatchResult = await _matchResultRepository.AddAsync(result);

            //Console.WriteLine(JsonSerializer.Serialize<MatchResultEntity>(creatingMatchResult));

            result = _mapper.Map<CreatingMatchResultDto, MatchResultEntity>(creatingResultDtoSecond);
            creatingMatchResult = await _matchResultRepository.AddAsync(result);

            //Console.WriteLine(JsonSerializer.Serialize<MatchResultEntity>(creatingMatchResult));

            await _matchResultRepository.SaveChangesAsync();
            /*
            ICollection<MatchResultEntity> result = _mapper.Map<ICollection<CreatingMatchResultDto>, ICollection<MatchResultEntity>>(creatingResultDtoList);
            Console.WriteLine(JsonSerializer.Serialize <MatchResultEntity>(result.ToList()[0]));
            Console.WriteLine(JsonSerializer.Serialize<MatchResultEntity>(result.ToList()[1]));
            await _matchResultRepository.AddRangeAsync(result);
            await _matchResultRepository.SaveChangesAsync();*/
        }

        public async Task UpdateAsync(Guid id, UpdatingMatchResultDto resultDto)
        {
            var result = await _matchResultRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            result.Score = resultDto.Score;
            result.IsWin = resultDto.IsWin;
            _matchResultRepository.Update(result);
            await _matchResultRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _matchResultRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _matchResultRepository.Delete(result);
            await _matchResultRepository.SaveChangesAsync();
        }

        public async Task<ICollection<MatchResultDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<MatchResultEntity> entities = await _matchResultRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<MatchResultEntity>, ICollection<MatchResultDto>>(entities);
        }
    }
}
