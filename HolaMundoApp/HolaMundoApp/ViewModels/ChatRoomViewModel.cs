using HolaMundoApp.Data.Models;
using HolaMundoApp.Resources;
using HolaMundoApp.Services;
using System;
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

        private string _Username;

        public string Username { get => _Username; set => SetProperty(ref _Username, value); }

        public ChatRoomViewModel(IChatService chatService)
        {
            _chatService = chatService;
            this.AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
        }

        private async Task OnAppearingAsync()
        {
            Username = GlobalVarsApplication.USERNAME;
        }
    }
}
