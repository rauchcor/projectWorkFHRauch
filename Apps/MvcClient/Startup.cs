using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MvcClient
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    
                    options.SignInScheme = "Cookies";
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "mvc";
                    /*in order for the mvc app to get the access_token the app it self has to 
                     * authenticate to the tokenserver therefore it needs the ClientSecret
                     * generate a 128 bit random number as a secret not 'secret' thats bad
                    */
                    options.ClientSecret = "secret";
                    //with hybrid flow code gets add to the id token 
                    //implicid only through the authorization_endpoint 
                    //hybride also programatically talk to the the tokenserver via the token_endpoint
                    //the tokenserver delivers through the browser the id_token and gets the code to the mvc app
                    //the mvc appp makes a backchannel call and exchanges the code for the accesstoken
                    //-> in order to minimice the exposure of the accesstoken -> on the expense of another roundtrip
                    options.ResponseType = "code id_token";
                    //puts the id_token into the cookie (its the only state management we have) 
                    options.SaveTokens = true;

                    options.Scope.Add("profile");
                    options.Scope.Add("openid");
                    //overlode the scope for authorization
                    options.Scope.Add("carApi");
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}