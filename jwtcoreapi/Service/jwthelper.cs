using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace jwtcoreapi.Service
{
    public class jwthelper
    {

        public string jwtDecode()
        {
            const string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZGVudGlmaWVyIjoiYWRtaW5AZW1haWwuY29tIiwiZW1haWwiOiIiLCJuYW1lIjpudWxsLCJnaXZlbm5hbWUiOm51bGwsImRhdGUiOiJcL0RhdGUoMClcLyJ9.W0VxCqV1dYT2lh5r31eOfRmqAviqw5SP4smq2ndCOGs";
            const string jwtkey = "56f5cf91ae93cc995739dcd1b0c4b75d646e0f9e";
            
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(jwtkey));

            List<Microsoft.IdentityModel.Tokens.SymmetricSecurityKey> val = new List<SymmetricSecurityKey>();
            val.Append(securityKey);

            TokenValidationParameters validationParameters =
                    new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = securityKey,
                    };

            SecurityToken validateToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            var JwtUserClaims = handler.ValidateToken(token, validationParameters, out validateToken);
            var JwtUserClaimsList = JwtUserClaims.Claims.ToList();
            
            string display = "";

            foreach (Claim claim in JwtUserClaimsList)
            {
                display = display + claim.Type + "-->" + claim.Value + "\n";
            }

            return display;

        }

    }
}