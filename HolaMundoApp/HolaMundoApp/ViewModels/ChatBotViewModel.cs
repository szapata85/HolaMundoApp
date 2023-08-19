using HolaMundoApp.Data.Models;
using HolaMundoApp.Resources;
using HolaMundoApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace HolaMundoApp.ViewModels
{
    public class ChatBotViewModel : BaseViewModel
    {
        private readonly IChatBotService _chatService;
        public ICommand AppearingCommand { get; set; }
        public ICommand SendMsgCommand { get; }

        
        private string _Username;
        public string Username { get => _Username; set => SetProperty(ref _Username, value); }

        private string _MessageIn;
        public string MessageIn { get => _MessageIn; set => SetProperty(ref _MessageIn, value); }

        private IEnumerable<MessageModel> _MessagesList;
        public IEnumerable<MessageModel> MessagesList { get => _MessagesList; set => SetProperty(ref _MessagesList, value); }

        public ChatBotViewModel(IChatBotService chatService)
        {
            _chatService = chatService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            SendMsgCommand = new AsyncCommand(async () => await OnSendMsgClicked());

            _chatService.Connect();
            _chatService.ReceiveMessage(GetMessage);
        }

        private async Task OnSendMsgClicked()
        {
            if (!string.IsNullOrEmpty(MessageIn))
            {
                await _chatService.SendMessage(new MessageItem { Message = MessageIn, SourceId = Username, TargetId = Username });
                AddMessage(Username, MessageIn, true);
            }
        }

        private void GetMessage(MessageItem messageItem)
        {
            if (!string.IsNullOrEmpty(messageItem.Message))
                AddMessage(messageItem.SourceId, messageItem.Message, false);
        }

            private void AddMessage(string User, string message, bool isOwner = true)
        {
            List<MessageModel> tempList = MessagesList.ToList();
            tempList.Add(new MessageModel { IsOwnerMessage = isOwner, Message = message, UserName = User });
            MessagesList = new List<MessageModel>(tempList);
            MessageIn = string.Empty;
        }

        private async Task OnAppearingAsync()
        {
            Username = GlobalVarsApplication.USERNAME;
            if (MessagesList == null)
            {
                MessagesList = new List<MessageModel>();
                AddMessage(Username, "Bienvenido", false);
            }
            await _chatService.Init(Username);

        }
    }
}
