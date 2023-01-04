﻿// <auto-generated />
using System;
using BulbasaurAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulbasaurAPI.Migrations
{
    [DbContext(typeof(DbServerContext))]
    partial class DbServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BulbasaurAPI.Models.CaregiverChild", b =>
                {
                    b.Property<int>("CaregiverId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.HasKey("CaregiverId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("CaregiverChildren");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Chats", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.ChatItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ChatId");

                    b.ToTable("ChatItems", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Documents", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.GroupPerson", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("GroupPersons");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Logging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Loggings", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.LogInInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogInCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoggedInDevice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LogInInformations", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.TOTP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("TOTPs", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<Guid>("GUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("PersonId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Caregiver", b =>
                {
                    b.HasBaseType("BulbasaurAPI.Models.Person");

                    b.ToTable("Caregivers", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Child", b =>
                {
                    b.HasBaseType("BulbasaurAPI.Models.Person");

                    b.ToTable("Children", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Personell", b =>
                {
                    b.HasBaseType("BulbasaurAPI.Models.Person");

                    b.Property<string>("Employment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FullTimeEmployment")
                        .HasColumnType("bit");

                    b.ToTable("Personells", (string)null);
                });

            modelBuilder.Entity("BulbasaurAPI.Models.CaregiverChild", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Caregiver", "Caregiver")
                        .WithMany("CaregiverChildren")
                        .HasForeignKey("CaregiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulbasaurAPI.Models.Child", "Child")
                        .WithMany("CaregiverChildren")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caregiver");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.ChatItem", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulbasaurAPI.Models.Chat", null)
                        .WithMany("ChatItemList")
                        .HasForeignKey("ChatId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Group", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Person", null)
                        .WithMany("Groups")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.GroupPerson", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Group", "Group")
                        .WithMany("GroupPersons")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulbasaurAPI.Models.Person", "Person")
                        .WithMany("GroupPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Logging", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.LogInInformation", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Person", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Document", null)
                        .WithMany("EligableList")
                        .HasForeignKey("DocumentId");

                    b.HasOne("BulbasaurAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.User", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Chat", null)
                        .WithMany("InvolvedUsersList")
                        .HasForeignKey("ChatId");

                    b.HasOne("BulbasaurAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Caregiver", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("BulbasaurAPI.Models.Caregiver", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Child", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("BulbasaurAPI.Models.Child", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Personell", b =>
                {
                    b.HasOne("BulbasaurAPI.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("BulbasaurAPI.Models.Personell", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Chat", b =>
                {
                    b.Navigation("ChatItemList");

                    b.Navigation("InvolvedUsersList");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Document", b =>
                {
                    b.Navigation("EligableList");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Group", b =>
                {
                    b.Navigation("GroupPersons");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Person", b =>
                {
                    b.Navigation("GroupPersons");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Caregiver", b =>
                {
                    b.Navigation("CaregiverChildren");
                });

            modelBuilder.Entity("BulbasaurAPI.Models.Child", b =>
                {
                    b.Navigation("CaregiverChildren");
                });
#pragma warning restore 612, 618
        }
    }
}
