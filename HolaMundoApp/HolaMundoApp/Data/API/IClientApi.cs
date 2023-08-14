using HolaMundoApp.Data.Models;
using HolaMundoApp.Data.Models.Dto;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolaMundoApp.Data.API
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Client>> GetClientsAsync();

        [Get("/Clients/{id}")]
        Task<ClientDetailDto> GetClient(long id);


    }
}
