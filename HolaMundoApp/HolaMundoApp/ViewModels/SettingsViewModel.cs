using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace HolaMundoApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand swNotifyCommand { get; set; }

        private bool _IsToggled;
        public bool IsToggled { get => _IsToggled; set => SetProperty(ref _IsToggled, value); }

        public SettingsViewModel()
        {
            swNotifyCommand = new AsyncCommand<bool>(async (value) => await onNotifiCommand(value));
        }

        private async Task onNotifiCommand(bool value)
        {
            
        }
    }
}
