﻿using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolaMundoApp.Data.API
{
    public interface IAccountApi
    {
        [Get("/Account/Login")]
        Task<HttpResponseMessage> LoginAsync(string userName, string password);
    }

}
