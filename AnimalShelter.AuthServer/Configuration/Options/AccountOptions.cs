using System;

namespace AnimalShelter.AuthServer.Configuration.Options
{
    public class AccountOptions
    {
        public bool AllowLocalLogin = true;
        public bool AllowRememberLogin = true;
        public TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        public bool ShowLogoutPrompt = true;
        public bool AutomaticRedirectAfterSignOut = false;
    }
}
