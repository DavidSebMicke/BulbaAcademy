using BulbasaurAPI.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace BulbasaurAPI
{
    public class DbServerContext : DbContext
    {
        public readonly IConfiguration Configuration;

        public DbServerContext( IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        

        //public DbServerContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Caregiver> Caregivers { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Personell> Personells { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatItem> ChatItems { get; set; }
        
        public virtual DbSet<Document> Documents { get; set; }
        
        public virtual DbSet<Logging> Loggs { get; set; }
        public virtual DbSet<LogInInformation> LogInInformations { get; set; }
        public virtual DbSet<TOTP> TOTPs { get; set; }




        public virtual DbSet<User> Users { get; set; }



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
            modelBuilder.Entity<Person>().ToTable("Persons");
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







        }

        
    }
}
