using AutoMapper;
using CyberTech.API.ModelViews.Country;
using CyberTech.Core.Dto.Country;
using CyberTech.Core.IServices;
using CyberTech.MessagesContracts.MongoRecord;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Страны
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]

    public class CountryController(ICountryService countryService, IMapper mapper, 
        IPublishEndpoint publishEndpoint, ILogger<CountryController> logger) : ControllerBase
    {
        private readonly ICountryService _service = countryService;
        private readonly IMapper _mapper = mapper;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly ILogger<CountryController> _logger = logger;

        /// <summary>
        /// Получение списка стран c пагинацией 
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Объем страницы. </param>
        /// <returns> Страница стран. </returns>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<CountryModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получение всего списка стран 
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<CountryModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение страные по ее ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var countryDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<CountryDto, CountryModel>(countryDto));
        }

        /// <summary>
        /// Добавление страны
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingCountryModel creatingCountryModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingCountryDto>(creatingCountryModel)));
        }

        /// <summary>
        /// Изменение данных о стране
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingCountryModel updatingCountryModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingCountryModel, UpdatingCountryDto>(updatingCountryModel));
            return Ok();
        }

        /// <summary>
        /// Удаление страны
        /// </summary>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // берем Id картинки по Id записи
            var ImageId = _service.GetCountryImageIdAsync(id).Result;
            if (ImageId.ToString().Length > 0)
            {
                await _publishEndpoint.Publish(new MongoRecDeleted
                {
                    Id = ImageId
                });
                _logger.LogInformation("{data} Publish MongoRecDeleted with Id={id}", DateTime.UtcNow, ImageId);
            }
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
