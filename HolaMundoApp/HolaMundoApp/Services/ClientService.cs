using HolaMundoApp.Data.API;
using HolaMundoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientApi _clientApi;

        public ClientService(IClientApi clientApi)
        {
            _clientApi = clientApi;
        }

       public async Task<List<Client>> GetClientsAsync()
        {
            List<Client> clients = new List<Client>();
            try
            {
                var response = await _clientApi.GetClientsAsync();
                return response;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return clients;
        }
    }

}
