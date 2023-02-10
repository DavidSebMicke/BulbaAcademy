using BulbasaurAPI.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Database
{
    public class DbServerContext : DbContext
    {
        public readonly IConfiguration Configuration;

        //public DbServerContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private DbContextOptions<DbServerContext> _options;

        public DbServerContext(DbContextOptions<DbServerContext> options) : base(options)
        {
            _options = options;
        }

        public DbServerContext()
        { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Caregiver> Caregivers { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatItem> ChatItems { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Logging> Loggs { get; set; }
        public virtual DbSet<LogInInformation> LogInInformations { get; set; }
        public virtual DbSet<TOTP> TOTPs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<TwoFToken> TwoFTokens { get; set; }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connString = Configuration.GetConnectionString("_connString");
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(connString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Person>().ToTable("Persons")
                .HasOne(c => c.Role);
            modelBuilder.Entity<Caregiver>().ToTable("Caregivers");
            modelBuilder.Entity<Child>().ToTable("Children");

            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<Address>().ToTable("Addresses");

            modelBuilder.Entity<Chat>().ToTable("Chats");
            modelBuilder.Entity<ChatItem>().ToTable("ChatItems");
            modelBuilder.Entity<User>().ToTable("Users"); ;
            modelBuilder.Entity<Document>().ToTable("Documents");
            modelBuilder.Entity<TOTP>().ToTable("TOTPs");
            modelBuilder.Entity<Logging>().ToTable("Loggings");
            modelBuilder.Entity<LogInInformation>().ToTable("LogInInformations");
            modelBuilder.Entity<AccessToken>().ToTable("AccessTokens");
            modelBuilder.Entity<TwoFToken>().ToTable("TwoFTokens");
        }
    }
}