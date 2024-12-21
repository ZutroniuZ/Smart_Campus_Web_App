using Microsoft.AspNetCore.SignalR;
using Smart_Campus_Web_App.Models;
namespace Smart_Campus_Web_App.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }

        
    }
}
