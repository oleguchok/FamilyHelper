using System.Linq;
using CryptoHelper;
using FamilyHelper.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict;

namespace FamilyHelper.API.Tools
{
    public static class DbSeeder
    {
        public static void UseDbSeeder(this IApplicationBuilder app)
        {
            using (var context = app.ApplicationServices.GetService<FamilyHelperContext>())
            {
                if (!context.Applications.Any(a => a.ClientId == "Angular.OpenIdConnect"))
                {
                    context.Applications.Add(new OpenIddictApplication<long>
                    {
                        ClientId = "Angular.OpenIdConnect",
                        DisplayName = "Angular Open Id Connect",
                        Type = OpenIddictConstants.ClientTypes.Public,
                        RedirectUri = "http://localhost:52334/login",
                        ClientSecret = Crypto.HashPassword("secret_secret_secret")
                    });

                    context.Applications.Add(new OpenIddictApplication<long>
                    {
                        ClientId = "postman",
                        DisplayName = "Postman",
                        RedirectUri = "https://www.getpostman.com/oauth2/callback",
                        Type = OpenIddictConstants.ClientTypes.Public
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
