using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using HolaMundoApp.Services;
using System.Net.Http.Headers;

namespace HolaMundoApp.Helpers.HttpMessageHandlers
{
    public class BaseAddressHandler: DelegatingHandler
    {
        private readonly IAppUserSettingService _appUserSettingService;
        public BaseAddressHandler(IAppUserSettingService appUserSettingService)
        {
            _appUserSettingService = appUserSettingService;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.RequestUri.AbsolutePath.EndsWith("Login"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _appUserSettingService.UserToken);
            }


            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }

}

