using HolaMundoApp.Data.Models;
using System;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public interface IChatService
    {
        Task Connect();
        Task Disconnect();
        Task SendMessageToAll(MessageItem messageItem);
        void ReceiveMessage(Action<MessageItem> messageItem);
    }
}
