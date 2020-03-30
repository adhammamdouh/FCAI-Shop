using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace FCAI_Shop.DbContext
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

#pragma warning disable 1998
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var x = 5;
            context.Validated();
        }

#pragma warning disable 1998
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = ApplicationUserRepository.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            context.Validated(identity);

        }
    }
}
