using AnimalShelter.AuthServer.Models.ViewModels.Consent;

namespace AnimalShelter.AuthServer.Models.ViewModels.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}