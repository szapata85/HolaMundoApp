using HolaMundoApp.Data.Models;
using HolaMundoApp.Data.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClientsAsync();

        Task<ClientDetailDto> GetClient(long clientId);
    }

}
