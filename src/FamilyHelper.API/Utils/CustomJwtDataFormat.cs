using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace FamilyHelper.API.Utils
{
    public class CustomJwtDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _algorithm;
        private readonly TokenValidationParameters _validationParameters;

        public CustomJwtDataFormat(string algirithm, TokenValidationParameters validationParameters)
        {
            _algorithm = algirithm;
            _validationParameters = validationParameters;
        }

        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;
            SecurityToken validToken = null;
            
            try
            {
                principal = handler.ValidateToken(protectedText, _validationParameters, out validToken);
                var validJwt = validToken as JwtSecurityToken;

                if (validJwt == null)
                {
                    throw new ArgumentException("Invalid JWT");
                }

                if (!validJwt.Header.Alg.Equals(_algorithm, StringComparison.Ordinal))
                {
                    throw new ArgumentException($"Algorithm must be '{_algorithm}'");
                }
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

            return new AuthenticationTicket(principal, new AuthenticationProperties(), "Cookie");
        }

        public AuthenticationTicket Unprotect(string protectedText) => Unprotect(protectedText, null);

        public string Protect(AuthenticationTicket data, string purpose)
        {
            return null;
        }

        public string Protect(AuthenticationTicket data) => Protect(data, null);
    }
}
