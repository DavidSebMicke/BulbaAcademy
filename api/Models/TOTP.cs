namespace BulbasaurAPI.Models
{
    public class TOTP
    {
        public int Id { get; set; }

        internal Guid Key { get; set; }
        internal byte[] Secret { get; set; }
        internal long? TimeWindowUsed { get; set; }
    }
}