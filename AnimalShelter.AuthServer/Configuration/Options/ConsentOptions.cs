namespace AnimalShelter.AuthServer.Configuration.Options
{
    public class ConsentOptions
    {
        public bool EnableOfflineAccess = true;
        public string OfflineAccessDisplayName = "Offline Access";
        public string OfflineAccessDescription = "Access to your applications and resources, even when you are offline";

        public readonly string MustChooseOneErrorMessage = "You must pick at least one permission";
        public readonly string InvalidSelectionErrorMessage = "Invalid selection";
    }
}
