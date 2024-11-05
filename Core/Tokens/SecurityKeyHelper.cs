using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Tokens;

public class SecurityKeyHelper
{
    public static SecurityKey GetSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}