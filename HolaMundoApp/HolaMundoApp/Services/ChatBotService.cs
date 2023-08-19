using HolaMundoApp.Data.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HolaMundoApp.Services
{
    public class ChatBotService: IChatBotService
    {
        private readonly HubConnection hubConnection;

        public ChatBotService()
        {
            hubConnection = new HubConnectionBuilder()
                                 .WithUrl("http://192.168.1.70:5000/ChatBotHub")
                                 .Build();

            hubConnection.ServerTimeout = TimeSpan.FromMinutes(5);
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
        } 
        
        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }

    public async Task SendMessage(MessageItem messageItem)
        {
            if (hubConnection.State == HubConnectionState.Disconnected)
                await hubConnection.StartAsync();

            await hubConnection.InvokeAsync("SendMessageToDevice", messageItem);
        }
        
        public void ReceiveMessage(Action<MessageItem> messageItem)
        {
            hubConnection.On("Receive", messageItem);
        }

        public async Task Init(string Username)
        {
            if (hubConnection.State == HubConnectionState.Disconnected)
                await hubConnection.StartAsync();

            await hubConnection.InvokeAsync("Init", new InfoDevice { Username = Username });
        }
    }
}
