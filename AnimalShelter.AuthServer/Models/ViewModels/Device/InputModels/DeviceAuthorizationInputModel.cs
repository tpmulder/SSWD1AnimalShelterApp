using AnimalShelter.AuthServer.Models.ViewModels.Consent.InputModels;

namespace AnimalShelter.AuthServer.Models.ViewModels.Device.InputModels
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}