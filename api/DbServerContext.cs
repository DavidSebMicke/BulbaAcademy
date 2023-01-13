using BulbasaurAPI.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI
{
    public class DbServerContext : DbContext
    {
        public readonly IConfiguration Configuration;

        public DbServerContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbServerContext()
        { }

        //public DbServerContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Caregiver> Caregivers { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

        //public virtual DbSet<GroupPerson> GroupPersons { get; set; }

        public virtual DbSet<Personell> Personells { get; set; }

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = DotEnv.Read()["_connString"];
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Person>().ToTable("Persons")
                .HasOne<Role>(c => c.Role); 
            modelBuilder.Entity<Caregiver>().ToTable("Caregivers");
            modelBuilder.Entity<Child>().ToTable("Children");
                
            modelBuilder.Entity<Personell>().ToTable("Personells");
            modelBuilder.Entity<Group>().ToTable("Groups");

            modelBuilder.Entity<Chat>().ToTable("Chats");
            modelBuilder.Entity<ChatItem>().ToTable("ChatItems");
            modelBuilder.Entity<User>().ToTable("Users"); ;
            modelBuilder.Entity<Document>().ToTable("Documents");
            modelBuilder.Entity<TOTP>().ToTable("TOTPs");
            modelBuilder.Entity<Logging>().ToTable("Loggings");
            modelBuilder.Entity<LogInInformation>().ToTable("LogInInformations");
            modelBuilder.Entity<AccessToken>().ToTable("AccessTokens");
            modelBuilder.Entity<TwoFToken>().ToTable("TwoFToken");


            //modelBuilder.Entity<CaregiverChild>()
            //    .HasKey(cg => new { cg.CaregiverId, cg.ChildId });
            //modelBuilder.Entity<CaregiverChild>()
            //    .HasOne(c => c.Caregiver)
            //    .WithMany(c => c.CaregiverChildren)
            //    .HasForeignKey(c => c.CaregiverId);
            //modelBuilder.Entity<CaregiverChild>()
            //    .HasOne(c => c.Child)
            //    .WithMany(c => c.CaregiverChildren)
            //    .HasForeignKey(c => c.ChildId);

            //modelBuilder.Entity<GroupPerson>()
            //    .HasKey(cg => new { cg.GroupId, cg.PersonId });
            //modelBuilder.Entity<GroupPerson>()
            //    .HasOne(c => c.Group)
            //    .WithMany(c => c.GroupPersons)
            //    .HasForeignKey(c => c.GroupId);
            //modelBuilder.Entity<GroupPerson>()
            //    .HasOne(c => c.Person)
            //    .WithMany(c => c.GroupPersons)
            //    .HasForeignKey(c => c.PersonId);
        }
    }
}