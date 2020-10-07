using AnimalShelter.AuthServer.Models.Account.InputModels;

namespace AnimalShelter.AuthServer.Models.Account
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
