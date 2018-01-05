using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Quickstart.UI;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddMvc();

            services.AddIdentityServer()
                .AddSigningCredential("B8397639321E28E5168BFCA7195A451B1613DCF5", StoreLocation.CurrentUser, NameType.Thumbprint)
                //.AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(TestUsers.Users);


      
            // add CORS policy for non-IdentityServer endpoints
            services.AddCors(options =>
             {
                 options.AddPolicy("allowed", policy =>
                 {
                     policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                     //policy.WithOrigins("http://localhost:4427")
                     //    .AllowAnyMethod()
                     //    .AllowAnyHeader();
                 });
             });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IdentityServer", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("allowed");
            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();

         
        }
    }
}
