using OtpNet;
using BulbasaurAPI.Models;

namespace BulbasaurAPI.Utils
{
    internal class TOTPUtil
    {
        internal static byte[] GenerateTOTPSecret()
        {
            byte[] key = KeyGeneration.GenerateRandomKey(20);
            string base32String = Base32Encoding.ToString(key);
            byte[] secret = Base32Encoding.ToBytes(base32String);
            return secret;
        }

        internal static bool VerifyTOTP(TOTP userTotp, string totpCode)
        {
            var totp = new Totp(userTotp.Secret);
            bool result = totp.VerifyTotp(totpCode, out long timeWindowUsed);

            if (result)
            {
                return timeWindowUsed != userTotp.TimeWindowUsed;
            }

            return result;
        }
    }
}