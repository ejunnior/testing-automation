namespace FrontEnd.Configuration
{
    using System.Configuration;
    using IdentityModel;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class AuthenticationConfiguration
    {
        private static string IdentityProvider =>
            ConfigurationManager.AppSettings["IdentityProvider"].ToString();

        public static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
                //}).AddCookie("Cookies")
            }).AddCookie("Cookies", (options) =>
            {
                options.AccessDeniedPath = "/Authorization/AccessDenied";
            })
               .AddOpenIdConnect("oidc", options =>
               {
                   options.SignInScheme = "Cookies";
                   options.Authority = IdentityProvider;
                   options.ClientId = "frontend-mvc";
                   options.ResponseType = "code id_token";
                   //options.CallbackPath= new PathString();
                   //options.SignedOutCallbackPath = new PathString();
                   options.Scope.Add("openid");
                   options.Scope.Add("profile");
                   options.Scope.Add("address");
                   options.Scope.Add("roles");
                   options.Scope.Add("financeapi");
                   options.Scope.Add("country");
                   options.Scope.Add("offline_access");
                   options.SaveTokens = true;
                   options.ClientSecret = "secret";
                   options.GetClaimsFromUserInfoEndpoint = true;
                   options.ClaimActions.Remove("amr");
                   options.ClaimActions.DeleteClaim("sid");
                   options.ClaimActions.DeleteClaim("idp");
                   options.ClaimActions.DeleteClaim("address");
                   options.ClaimActions.MapUniqueJsonKey("role", "role");
                   options.ClaimActions.MapUniqueJsonKey(claimType: "country", jsonKey: "country");

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       NameClaimType = JwtClaimTypes.GivenName,
                       RoleClaimType = JwtClaimTypes.Role
                   };
               });

            return services;
        }
    }
}