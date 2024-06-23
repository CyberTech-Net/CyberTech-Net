using AutoMapper;
using CyberTech.API.ModelViews.Country;
using CyberTech.Core.Dto.Country;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Справочник "Страны"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _service = countryService;
            _mapper = mapper;            
        }

        /// <summary>
        /// Получение списка стран c пагинацией из справочника "Страны"
        /// </summary>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<CountryModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получение всего списка стран из справочника "Страны"
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница стран. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<CountryModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из справочника "Страны"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var countryDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<CountryDto, CountryModel>(countryDto));            
        }

        /// <summary>
        /// Вставка записи в справочник "Страны"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingCountryModel creatingCountryModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingCountryDto>(creatingCountryModel)));
        }

        /// <summary>
        /// Изменение записи в справочнике "Страны"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingCountryModel updatingCountryModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingCountryModel, UpdatingCountryDto>(updatingCountryModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из справочника "Страны"
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
