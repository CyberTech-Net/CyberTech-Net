using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TeamRatingController(ITeamRatingService teamRatingService) : ControllerBase
    {
        private readonly ITeamRatingService _service = teamRatingService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _service.GetTeamRating();
            return Ok(response);
        }
    }   
}
