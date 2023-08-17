using HolaMundoApp.Data.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public class ChatService: IChatService
    {
        private readonly HubConnection hubConnection;

        public ChatService()
        {
            hubConnection = new HubConnectionBuilder()
                                 .WithUrl("http://192.168.1.70:5000/ChatHub")
                                 .Build();
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
        } 
        
        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }
        
        public async Task SendMessageToAll(MessageItem messageItem)
        {
            await hubConnection.InvokeAsync("SendMessageToAll", messageItem);
        }
        
        public void ReceiveMessage(Action<MessageItem> messageItem)
        {
            hubConnection.On("Receive", messageItem);
        }
    }
}
