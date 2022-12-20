namespace BulbasaurAPI
{
    internal class TOTP
    {
        internal Guid Key { get; set; }
        internal byte[] Secret { get; set; }
        internal long? TimeWindowUsed { get; set; }

    }
}
