using HolaMundoApp.Data.Models;
using HolaMundoApp.Resources;
using HolaMundoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    [QueryProperty(nameof(Username), nameof(Username))]
    public class ChatRoomViewModel : BaseViewModel
    {
        private readonly IChatService _chatService;
        public ICommand AppearingCommand { get; set; }
        public ICommand SendMsgCommand { get; }

        private string _Username;
        private string _Message;
        private IEnumerable<MessageModel> _MessagesList;
        public string Username { get => _Username; set => SetProperty(ref _Username, value); }
        public string Message { get => _Message; set => SetProperty(ref _Message, value); }

        public IEnumerable<MessageModel> MessagesList { get => _MessagesList; set => SetProperty(ref _MessagesList, value); }

        public ChatRoomViewModel(IChatService chatService)
        {
            _chatService = chatService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            SendMsgCommand = new AsyncCommand(async () => await OnSendMsgClicked());
            //SendMsgCommand = new Command(OnSendMsgClicked);
        }

        private async Task OnSendMsgClicked()
        {
            await _chatService.SendMessageToAll(new MessageItem { Message = Message, SourceId = 0});
            AddMessage(Username, Message, true);
        }

        private void GetMessage(MessageItem messageItem)
        {
            AddMessage(messageItem.SourceId.ToString(), messageItem.Message, false);
        }

            private void AddMessage(string User, string message, bool isOwner = true)
        {
            List<MessageModel> tempList = MessagesList.ToList();
            tempList.Add(new MessageModel { IdOwnerMessage = isOwner, Message = message, UserName = User });
            MessagesList = new List<MessageModel>(tempList);
            Message = string.Empty;
        }

        private async Task OnAppearingAsync()
        {
            Username = GlobalVarsApplication.USERNAME;

            _chatService.ReceiveMessage(GetMessage);
            await _chatService.Connect();
        }
    }
}
