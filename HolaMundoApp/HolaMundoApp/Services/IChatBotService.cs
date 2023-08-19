using HolaMundoApp.Data.Models;
using System;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public interface IChatBotService
    {
        Task Connect();
        Task Disconnect();
        Task Init(string Username);
        Task SendMessage(MessageItem messageItem);
        void ReceiveMessage(Action<MessageItem> messageItem);
    }
}
