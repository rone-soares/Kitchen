using Business.Interfaces.Registrations;
using Library.Resources;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiKitchen.Identity
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            /*The validation CORS.*/
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "*" });

            bool authenticateUser = true;

            if (!authenticateUser)
            {
                context.SetError("invalid_user", MessageResource.InvalidUser);
                context.Rejected();
                return Task.FromResult<object>(null);
            }

            IdentityUser idUser = new IdentityUser()
            {
                UserName = context.UserName,
                PasswordHash = context.Password,
                Email = context.UserName,
                EmailConfirmed = true
            };

            var ticket = new AuthenticationTicket(SetClaimsIdentity(context, idUser), new AuthenticationProperties());
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, IdentityUser user)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));

            string nameProfile = context.UserName;

            identity.AddClaim(new Claim(ClaimTypes.Role, nameProfile));

            return identity;
        }
    }
}