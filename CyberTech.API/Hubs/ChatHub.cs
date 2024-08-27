using Microsoft.AspNetCore.SignalR;

namespace CyberTech.API.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            var name = Context.User.Claims.Where(x => x.Type == "name").Select(x => x.Value).First();
            await Clients.Caller.SendAsync("ReceiveMessage", $"Привет, {name}!");
        }
    }
}
