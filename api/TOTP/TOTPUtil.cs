using OtpNet;

namespace BulbasaurAPI.TOTP
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

        internal static bool VerifyTOTP(byte[] TOTPSecret, string totpCode)
        {
            var totp = new Totp(TOTPSecret);
            return totp.VerifyTotp(totpCode, out long timeWindowUsed);
        }
    }
}