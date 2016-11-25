using CryptoHelper;
using FamilyHelper.Data;
using FamilyHelper.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using OpenIddict;

namespace FamilyHelper.AuthenticationServer
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = configBuilder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FamilyHelperContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:FamilyHelperDatabase"]));

            services.AddIdentity<User, IdentityRole<long>>(opt =>
            {
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<FamilyHelperContext, long>();

            services.AddOpenIddict<FamilyHelperContext, long>()
                .AddMvcBinders()
                .EnableTokenEndpoint("/connect/token")
                .EnableIntrospectionEndpoint("/connect/introspect")
                .AllowPasswordFlow()
                .DisableHttpsRequirement()
                .AddEphemeralSigningKey();

            services.AddCors();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            app.UseOpenIddict();

            app.UseOAuthValidation();

            app.UseMvcWithDefaultRoute();

            SeedDatabase(app);
        }

        private void SeedDatabase(IApplicationBuilder app)
        {
            var options = app
                .ApplicationServices
                .GetRequiredService<DbContextOptions<FamilyHelperContext>>();

            using (var context = new FamilyHelperContext(options))
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                if (!context.Applications.Any())
                {
                    context.Applications.Add(new OpenIddictApplication<long>
                    {
                        ClientId = "FamilyHelper.OpenIdConnect",
                        DisplayName = "Family Helper Open Id Connect",
                        LogoutRedirectUri = "http://localhost:52334/signout-oidc",
                        RedirectUri = "http://localhost:52334/signin-oidc",
                        Type = OpenIddictConstants.ClientTypes.Public
                    });

                    context.Applications.Add(new OpenIddictApplication<long>
                    {
                        ClientId = "FamilyHelper.API",
                        ClientSecret = Crypto.HashPassword("secret_secret_secret"),
                        Type = OpenIddictConstants.ClientTypes.Confidential
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
