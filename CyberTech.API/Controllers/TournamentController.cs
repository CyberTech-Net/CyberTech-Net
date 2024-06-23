using AutoMapper;
using CyberTech.API.ModelViews.Tournament;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Таблица "Турниры"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _service;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IMapper mapper)
        {
            _service = tournamentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка турниров c пагинацией из таблицы "Турниры"
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<TournamentModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получение всего списка турниров из таблицы "Турниры"
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница стран. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<TournamentModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Турниры"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournamentDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<TournamentDto, TournamentModel>(tournamentDto));
        }

        /// <summary>
        /// Вставка записи в таблице "Турниры"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingTournamentModel creatingTournamentModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingTournamentDto>(creatingTournamentModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Турниры"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingTournamentModel updatingTournamentModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTournamentModel, UpdatingTournamentDto>(updatingTournamentModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Турниры"
        /// </summary>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
