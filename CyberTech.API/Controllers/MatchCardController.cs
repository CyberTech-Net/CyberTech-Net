using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class MatchCardController(IMatchCardService matchCardService) : ControllerBase
    {
        private readonly IMatchCardService _service = matchCardService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _service.GetMatchCard(cancellationToken);
            return Ok(response);
            
        }
    }
}
