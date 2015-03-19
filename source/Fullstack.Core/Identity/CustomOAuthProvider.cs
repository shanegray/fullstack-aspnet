using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using Owin;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace Fullstack.Core.Identity {
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {

            var userManager = context.OwinContext.GetUserManager<UserManager>();

            var user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null) {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }         

            var claims = await userManager.CreateIdentityAsync(user, "JWT");
            var ticket = new AuthenticationTicket(claims, null);

            context.Validated(ticket);

        }
    }
}
