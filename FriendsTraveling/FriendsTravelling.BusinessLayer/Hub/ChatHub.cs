using FriendsTraveling.DataLayer.Models;
using Microsoft.AspNetCore.SignalR;

namespace FriendsTraveling.BusinessLayer.HubN
{
    public class ChatHub : Hub
    {
        public void SendMessage(Message message)
        {
            Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}
