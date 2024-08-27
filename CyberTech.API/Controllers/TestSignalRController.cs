using CyberTech.API.HubSignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CyberTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSignalRController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;
        public TestSignalRController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("SendSingle")]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            var messageObject = new
            {
                id = Guid.NewGuid().ToString(),
                text = message
            };

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", messageObject);
            return Ok();
        }

        [HttpPost("SendMultiple")]
        public async Task<IActionResult> SendMultipleMessages([FromBody] string[] messages)
        {
            var messageObjects = messages.Select(m => new
            {
                id = Guid.NewGuid().ToString(),
                text = m
            }).ToArray();

            await _hubContext.Clients.All.SendAsync("ReceiveMultipleMessages", messageObjects);
            return Ok();
        }
    }
}
