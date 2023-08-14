using HolaMundoApp.Data.Models;
using HolaMundoApp.Data.Models.Dto;
using HolaMundoApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    [QueryProperty(nameof(ClientId), nameof(ClientId))]

    public class ClientViewModel: BaseViewModel
    {
        private readonly IClientService _clientService;

        private ClientDetailDto _client;
        private long _clientId;

        public ClientViewModel(IClientService clientService)
        {
            _clientService = clientService;

            AppearingCommand = new AsyncCommand(async () => await Appearing());
        }

        public ClientDetailDto Client { get => _client; set => SetProperty(ref _client, value); }
        public long ClientId { get => _clientId; set => SetProperty(ref _clientId, value); }

        public ICommand AppearingCommand { get; set; }


        private async Task Appearing()
        {
            await LoadClient();
        }

        private async Task LoadClient()
        {
            if (ClientId < 0)
            {
                return;
            }

            IsBusy = true;
            try
            {
                Client = await _clientService.GetClient(ClientId);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
