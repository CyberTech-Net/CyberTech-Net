using AutoMapper;
using CyberTech.API.ModelViews.Player;
using CyberTech.Core.Dto.Player;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Таблица "Игроки"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _service = playerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка игроков c пагинацией из таблицы "Игроки"
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<PlayerModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получение всего списка игроков из таблицы "Игроки"
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<PlayerModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Игроки"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var playerDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<PlayerDto, PlayerModel>(playerDto));
        }

        /// <summary>
        /// Вставка записи в таблице "Игроки"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingPlayerModel creatingPlayerModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map< CreatingPlayerDto>(creatingPlayerModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Игроки"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingPlayerModel updatingPlayerModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingPlayerModel, UpdatingPlayerDto>(updatingPlayerModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Игроки"
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