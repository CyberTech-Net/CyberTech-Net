using AutoMapper;
using CyberTech.API.Mapping;
using CyberTech.API.ModelViews.News;
using CyberTech.Core.IServices;
using CyberTech.MessagesContracts.MongoRecord;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Новости
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class InfoController(IInfoService newsService, IPublishEndpoint publishEndpoint,
        ILogger<InfoController> logger) : Controller
    {
        private readonly IInfoService _service = newsService;       
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly ILogger<InfoController> _logger = logger;

        /// <summary>
        /// Получение новостей c пагинацией
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = await _service.GetPagedAsync(page, itemsPerPage);
            if (response == null)
                return NotFound();

            return Ok(InfoMapper.ConvertToModelApi(response));
        }

        /// <summary>
        /// Получение всего списка новостей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _service.GetAllAsync(cancellationToken);
            if (response == null)
                return NotFound();

            return Ok(InfoMapper.ConvertToModelApi(response).OrderByDescending(x=>x.Date));
        }

        /// <summary>
        /// Получение новости по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var infoDto = await _service.GetByIdAsync(id, cancellationToken);
            if (infoDto == null)
                return NotFound();
            return Ok(InfoMapper.ConvertToModelApi(infoDto));
        }

        /// <summary>
        /// Добавить новость
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatingInfoModel creatingInfoModel)
        {
            return Ok(await _service.CreateAsync(InfoMapper.ConvertToDto(creatingInfoModel)));
        }

        /// <summary>
        /// Изменить новость
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, [FromBody] UpdatingInfoModel updatingInfoModel)
        {
            await _service.UpdateAsync(id, InfoMapper.ConverToDto(updatingInfoModel));
            return Ok();
        }

        /// <summary>
        /// Удалить новость
        /// </summary>        
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            // берем Id картинки по Id записи
            var ImageId = _service.GetNewImageIdAsync(id).Result;
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

