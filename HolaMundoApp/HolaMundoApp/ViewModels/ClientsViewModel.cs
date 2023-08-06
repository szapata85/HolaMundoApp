using HolaMundoApp.Data.Models;
using HolaMundoApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace HolaMundoApp.ViewModels
{
    public class ClientsViewModel: BaseViewModel
    {
        private readonly IClientService _clientService;
        public ICommand AppearingCommand { get; set; }
        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();


        public ClientsViewModel(IClientService clientService)
        {
            this.Title = "Clients";
            this.AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            _clientService = clientService;
        }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                this.IsBusy = true;
                List<Client> clients = await _clientService.GetClientsAsync();
                if (clients != null)
                {
                    Clients.ReplaceRange(clients);
                }
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
