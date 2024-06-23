using AutoMapper;
using CyberTech.API.ModelViews.Info;
using CyberTech.Core.Dto.Info;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Api.Controllers
{
    /// <summary>
    /// Таблица "Новости"
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InfoController : Controller
    {
        private readonly IInfoService _service;
        private readonly IMapper _mapper;

        public InfoController(IInfoService infoService, IMapper mapper)
        {
            _service = infoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение новостей c пагинацией из таблицы "Новости"
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetPagedAsync(int page, int itemsPerPage)
        {
            var response = _mapper.Map<List<InfoModel>>(await _service.GetPagedAsync(page, itemsPerPage));
            return Ok(response);
        }

        /// <summary>
        /// Получение всего списка новостей из таблицы "Новости"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _mapper.Map<List<InfoModel>>(await _service.GetAllAsync(cancellationToken));
            return Ok(response);
        }

        /// <summary>
        /// Получение записи по ее ID из таблицы "Новости"
        /// </summary>        
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var infoDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<InfoDto, InfoModel>(infoDto));
        }

        /// <summary>
        /// Вставка записи в таблицу "Новости"
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingInfoModel creatingInfoModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingInfoDto>(creatingInfoModel)));
        }

        /// <summary>
        /// Изменение записи в таблице "Новости"
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditAsync(Guid id, UpdatingInfoModel updatingInfoModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingInfoModel, UpdatingInfoDto>(updatingInfoModel));
            return Ok();
        }

        /// <summary>
        /// Удаление записи из таблицы "Новости"
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

