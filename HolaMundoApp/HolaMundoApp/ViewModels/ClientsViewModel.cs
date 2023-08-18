using HolaMundoApp.Data.Models;
using HolaMundoApp.Resources;
using HolaMundoApp.Services;
using HolaMundoApp.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class ClientsViewModel: BaseViewModel
    {
        private readonly IClientService _clientService;
        public ICommand AppearingCommand { get; set; }
        public ICommand ClientTappedCommand { get; set; }
        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();


        public ClientsViewModel(IClientService clientService)
        {
            this.Title = "Clients";
            this.AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            this.ClientTappedCommand = new AsyncCommand<Client>(OnClientTapped);
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
                IsBusy = true;
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

        private Task OnClientTapped(Client client)
        {
            if (client == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ClientPage)}?{nameof(ClientViewModel.ClientId)}={client.Id}");

        }
    }
}
