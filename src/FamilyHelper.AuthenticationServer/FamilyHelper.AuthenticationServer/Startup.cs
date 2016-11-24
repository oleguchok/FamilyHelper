using FamilyHelper.Data;
using FamilyHelper.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

            services.AddOpenIddict<FamilyHelperContext>()
                .AddMvcBinders()
                .EnableTokenEndpoint("/connect/token")
                .UseJsonWebTokens()
                .AllowPasswordFlow()
                .DisableHttpsRequirement()
                .AddEphemeralSigningKey();

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

            app.UseOpenIddict();

            app.UseMvcWithDefaultRoute();
        }
    }
}
