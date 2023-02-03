namespace BulbasaurAPI.Models
{
    public class TOTP
    {
        public int Id { get; set; }

        public Guid Key { get; set; }
        public byte[] Secret { get; set; }
        public long? TimeWindowUsed { get; set; }
    }
}