using IdentityServer4.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new("TestApi", "PersonServiceAPI")
    };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "TestApi" }
            }
        };
}