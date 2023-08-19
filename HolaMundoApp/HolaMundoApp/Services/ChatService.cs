using HolaMundoApp.Data.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HolaMundoApp.Services
{
    public class ChatService: IChatService
    {
        private readonly HubConnection hubConnection;

        public ChatService()
        {
            hubConnection = new HubConnectionBuilder()
                                 .WithUrl(Settings.ChatHubBaseUri)
                                 .Build();

            hubConnection.ServerTimeout = TimeSpan.FromMinutes(1);
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
            if (hubConnection.State == HubConnectionState.Disconnected)
                await hubConnection.StartAsync();

            await hubConnection.InvokeAsync("SendMessageToAll", messageItem);
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
