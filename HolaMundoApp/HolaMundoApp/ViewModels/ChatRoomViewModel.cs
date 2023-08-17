using HolaMundoApp.Services;

namespace HolaMundoApp.ViewModels
{
    public class ChatRoomViewModel : BaseViewModel
    {
        private readonly IChatService _chatService;

        public ChatRoomViewModel(IChatService chatService)
        {
            _chatService = chatService;
        }
    }
}
