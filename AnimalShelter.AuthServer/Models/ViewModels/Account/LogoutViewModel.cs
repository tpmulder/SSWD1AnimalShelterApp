using AnimalShelter.AuthServer.Models.ViewModels.Account;
using AnimalShelter.AuthServer.Models.ViewModels.Account.InputModels;

namespace AnimalShelter.AuthServer.Models.ViewModels.Account
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
