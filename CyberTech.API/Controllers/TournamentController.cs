using AutoMapper;
using CyberTech.API.ModelViews.Tournament;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Core.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Турниры
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TournamentController(ITournamentService tournamentService, IMapper mapper, IValidator<CreatingTournamentModel> createValidator, IValidator<UpdatingTournamentModel> updateValidator) : ControllerBase
    {
        private readonly ITournamentService _service = tournamentService;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreatingTournamentModel> _createValidator = createValidator;
        private readonly IValidator<UpdatingTournamentModel> _updateValidator = updateValidator;

        /// <summary>
        /// Получение списка турниров c пагинацией из таблицы "Турниры"
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage, CancellationToken cancellationToken = default)
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = _mapper.Map<List<TournamentModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Турниры"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType<TournamentModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tournamentDto = await _service.GetByIdAsync(id, cancellationToken);
            if (tournamentDto == null)
                return NotFound();
            return Ok(_mapper.Map<TournamentDto, TournamentModel>(tournamentDto));
        }

        /// <summary>
        /// Вставка записи в таблице "Турниры"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreatingTournamentModel creatingTournamentModel)
        {
            var validate = _createValidator.Validate(creatingTournamentModel);
            if (!validate.IsValid)
                return BadRequest(validate.Errors);
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingTournamentDto>(creatingTournamentModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Турниры"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, [FromBody] UpdatingTournamentModel updatingTournamentModel, CancellationToken cancellationToken = default)
        {
            var validate = _updateValidator.Validate(updatingTournamentModel);
            if (!validate.IsValid)
                return BadRequest(validate.Errors);
            await _service.UpdateAsync(id, _mapper.Map<UpdatingTournamentModel, UpdatingTournamentDto>(updatingTournamentModel), cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Турниры"
        /// </summary>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _service.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
