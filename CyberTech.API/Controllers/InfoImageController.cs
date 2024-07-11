using AutoMapper;
using CyberTech.API.ModelViews.InfoImage;
using CyberTech.Core.Dto.InfoImage;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    /// <summary>
    /// Таблица "Картинки для новостей".
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InfoImageController : Controller
    {
        private readonly IInfoImageService _service;
        private readonly IMapper _mapper;

        public InfoImageController(IInfoImageService infoImageService, IMapper mapper)
        {
            _service = infoImageService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всего списка новостей из таблицы "Картинки для новостей"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<InfoImageModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Картинки для новостей"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var infoDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<InfoImageDto, InfoImageModel>(infoDto));
        }

        /// <summary>
        /// Вставка записи в таблицу "Картинки для новостей"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingInfoImageModel creatingInfoImageModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingInfoImageDto>(creatingInfoImageModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Картинки для новостей"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingInfoImageModel updatingInfoImageModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingInfoImageModel, UpdatingInfoImageDto>(updatingInfoImageModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Картинки для новостей"
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
