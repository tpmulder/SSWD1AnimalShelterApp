using AnimalShelter.AuthServer.Models.Consent.InputModels;

namespace AnimalShelter.AuthServer.Models.Device.InputModels
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}