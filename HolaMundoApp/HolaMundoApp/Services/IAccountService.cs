using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string userName, string password);
    }

}
