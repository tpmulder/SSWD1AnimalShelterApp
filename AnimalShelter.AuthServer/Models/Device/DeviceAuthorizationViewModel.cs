using AnimalShelter.AuthServer.Models.Consent;

namespace AnimalShelter.AuthServer.Models.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}