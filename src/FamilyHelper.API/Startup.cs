using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FamilyHelper.Data;
using FamilyHelper.Data.Infrastructure;
using FamilyHelper.Entities.Entities;
using FamilyHelper.Service.Abstract;
using FamilyHelper.Service.Implementation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FamilyHelper.API
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
            // Setting up CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddDbContext<FamilyHelperContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:FamilyHelperDatabase"]));

            services.AddIdentity<User, IdentityRole<long>>()
                .AddEntityFrameworkStores<FamilyHelperContext, long>();

            // DI
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFamilyService, FamilyService>();

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
            app.UseCors("CorsPolicy");

            app.UseOAuthIntrospection(options => {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.Authority = "http://localhost:54956/";
                options.Audiences.Add("FamilyHelper.API");
                options.ClientId = "FamilyHelper.API";
                options.ClientSecret = "secret_secret_secret";
            });
            
            app.UseMvc();
        }
    }
}
