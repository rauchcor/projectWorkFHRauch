using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(TestUsers.Users)
                .AddSigningCredential(IdentityServerBuilderExtensionsCrypto.CreateRsaSecurityKey());

            /* services.AddIdentityServer()
                 .AddInMemoryApiResources(Config.GetApis())
                 .AddInMemoryIdentityResources(Config.GetIdentityResources())
                 .AddInMemoryClients(Config.GetClients())
                 .AddTestUsers(TestUsers.Users)
                 .AddSigningCredential(IdentityServerBuilderExtensionsCrypto.CreateRsaSecurityKey());

             services.AddAuthentication()
                 .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
                 {
                     options.Authority = "https://localhost:18140";

                     options.ApiName = "api";
                     options.ApiSecret = "secret";
                 });

             // add CORS policy for non-IdentityServer endpoints
             services.AddCors(options =>
             {
                 options.AddPolicy("api", policy =>
                 {
                     policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                 });
             });

             // demo versions
             services.AddTransient<IRedirectUriValidator, RedirectValidator>();
             services.AddTransient<ICorsPolicyService, CorsPolicy>();*/

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

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityServer V1");
            });
            app.UseDeveloperExceptionPage();

            app.UseCors("api");
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}
