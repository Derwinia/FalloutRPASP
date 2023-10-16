using System.Security.Cryptography;
using System.Text;

namespace FalloutRPDAL.Services
{
    public class PasswordService
    {
        public static void PasswordHashCreate(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
