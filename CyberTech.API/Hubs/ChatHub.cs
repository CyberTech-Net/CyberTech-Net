using Microsoft.AspNetCore.SignalR;

namespace CyberTech.API.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Users(Context.UserIdentifier).SendAsync("ReceiveMessage", $"Привет, {Context.UserIdentifier}!");
        }
    }
}
