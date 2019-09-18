using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Store.BL.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "MyServer";
        public const string AUDIENCE = "https://localhost:44326/";
        const string KEY = "It is a trap";
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
