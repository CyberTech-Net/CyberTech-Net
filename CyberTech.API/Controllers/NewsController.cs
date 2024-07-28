using CyberTech.API.Mapping;
using CyberTech.API.ModelViews.News;
using CyberTech.Core.IServices;
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
    public class NewsController(IInfoService newsService) : Controller
    {
        private readonly IInfoService _service = newsService;

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

            return Ok(NewsMapper.ConvertToModelApi(response));
        }

        /// <summary>
        /// Получение всего списка новостей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _service.GetAllAsync(cancellationToken);
            if (response == null)
                return NotFound();

            return Ok(NewsMapper.ConvertToModelApi(response));
        }

        /// <summary>
        /// Получение новости по ID
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var infoDto = await _service.GetByIdAsync(id, cancellationToken);
            if (infoDto == null)
                return NotFound();
            return Ok(NewsMapper.ConvertToModelApi(infoDto));
        }

        /// <summary>
        /// Добавить новость
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingNewsModel creatingInfoModel)
        {
            return Ok(await _service.CreateAsync(NewsMapper.ConvertToDto(creatingInfoModel)));
        }

        /// <summary>
        /// Изменить новость
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingNewsModel updatingInfoModel)
        {
            await _service.UpdateAsync(id, NewsMapper.ConverToDto(updatingInfoModel));
            return Ok();
        }

        /// <summary>
        /// Удалить новость
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

