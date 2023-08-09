using HolaMundoApp.Resx;
using HolaMundoApp.Services;
using HolaMundoApp.Views;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private string _username;
        private string _password;

        public LoginViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            LoginCommand = new Command(OnLoginClicked);
        }

        public string UserName { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            
            if (await _accountService.LoginAsync(UserName, Password))
            {
                await Shell.Current.GoToAsync($"//{nameof(ClientsPage)}");
            }
            else{
                await Application.Current.MainPage.DisplayAlert(
                    AppResources.LoginPageInvalidLoginTitle,
                    AppResources.LoginPageInvalidLoginMessage, 
                    AppResources.OkText);
            }
        }
        private bool ValidateFields()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

       
    }
}
