using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalShelter.AuthServer.Configuration
{
    public class IdentityServerConfiguration
    {
        private readonly IdentityServerSettings _settings;
        private readonly string _applicationName = "AnimalShelter";

        public IdentityServerConfiguration(IdentityServerSettings settings)
        {
            _settings = settings;
        }

        public IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public IEnumerable<ApiResource> Apis =>
            _settings.Apis.Select(e => new ApiResource
            {
                Name = e.Name,
                DisplayName = e.DisplayName,
                Scopes = e.Scopes?.Select(e => $"{_applicationName}.{e}").ToArray() ?? new[] { $"{_applicationName}.Api" }
            });

        public IEnumerable<ApiScope> ApiScopes =>
            _settings.Apis.SelectMany(e => e.Scopes).Select(e => new ApiScope($"{_applicationName}.{e}"));

        public IEnumerable<Client> Clients =>
            _settings.Clients.Select(e => new Client
            {
                ClientId = e.Name,

                RedirectUris = { $"{e.Url}/signin-oidc" },

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials.Append(GrantType.AuthorizationCode).ToArray(),

                // secret for authentication
                ClientSecrets = e.Secrets.Select(f => new Secret(f.ToSha256())).ToArray(),

                // scopes that client has access to
                AllowedScopes = (e.Scopes?.Select(e => $"{_applicationName}.{e}").ToArray() ?? new[] { $"{_applicationName}.Api" })
                    .Append(IdentityServerConstants.StandardScopes.OpenId)
                    .Append(IdentityServerConstants.StandardScopes.Profile)
                    .ToArray()
            });

        public static IEnumerable<TestUser> TestUsers =>
            new List<TestUser> {
                new TestUser
                {
                    SubjectId = "818727",
                    Username = "alice",
                    Password = "alice",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonConvert.SerializeObject(CreateAddress()), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "88421113",
                    Username = "bob",
                    Password = "bob",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, JsonConvert.SerializeObject(CreateAddress()), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                }
            };

        private static object CreateAddress() =>
            new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = "3057GK",
                country = "Netherlands"
            };
    }
}
