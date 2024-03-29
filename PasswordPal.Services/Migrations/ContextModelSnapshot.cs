﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasswordPal.Services.Database;

#nullable disable

namespace PasswordPal.Services.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PasswordPal.Core.Models.PasswordCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PasswordCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Social"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Streaming"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shopping"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gaming"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Financial"
                        });
                });

            modelBuilder.Entity("PasswordPal.Core.Models.StoredPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncryptedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StoredPassword");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 0,
                            CreatedAt = "2023-07-04 14:00:00",
                            EncryptedPassword = "encryptedPassword1",
                            Title = "Title1",
                            UpdatedAt = "2023-07-04 14:00:00",
                            UserId = 1,
                            Username = "Username1",
                            Website = "www.website1.com"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 0,
                            CreatedAt = "2023-07-04 14:00:00",
                            EncryptedPassword = "encryptedPassword2",
                            Title = "Title2",
                            UpdatedAt = "2023-07-04 14:00:00",
                            UserId = 2,
                            Username = "Username2",
                            Website = "www.website2.com"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 0,
                            CreatedAt = "2023-07-04 14:00:00",
                            EncryptedPassword = "encryptedPassword3",
                            Title = "Title3",
                            UpdatedAt = "2023-07-04 14:00:00",
                            UserId = 3,
                            Username = "Username3",
                            Website = "www.website3.com"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 0,
                            CreatedAt = "2023-07-04 14:00:00",
                            EncryptedPassword = "encryptedPassword4",
                            Title = "Title4",
                            UpdatedAt = "2023-07-04 14:00:00",
                            UserId = 4,
                            Username = "Username4",
                            Website = "www.website4.com"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 0,
                            CreatedAt = "2023-07-04 14:00:00",
                            EncryptedPassword = "encryptedPassword5",
                            Title = "Title5",
                            UpdatedAt = "2023-07-04 14:00:00",
                            UserId = 5,
                            Username = "Username5",
                            Website = "www.website5.com"
                        });
                });

            modelBuilder.Entity("PasswordPal.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "testUser1@email.com",
                            Password = "testPassword1",
                            Salt = "exampleSalt",
                            Username = "testUser1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "testUser2@email.com",
                            Password = "testPassword2",
                            Salt = "exampleSalt",
                            Username = "testUser2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "testUser3@email.com",
                            Password = "testPassword3",
                            Salt = "exampleSalt",
                            Username = "testUser3"
                        },
                        new
                        {
                            Id = 4,
                            Email = "testUser4@email.com",
                            Password = "testPassword4",
                            Salt = "exampleSalt",
                            Username = "testUser4"
                        },
                        new
                        {
                            Id = 5,
                            Email = "testUser5@email.com",
                            Password = "testPassword5",
                            Salt = "exampleSalt",
                            Username = "testUser5"
                        },
                        new
                        {
                            Id = 6,
                            Email = "a@email.com",
                            Password = "a",
                            Salt = "exampleSalt",
                            Username = "a"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
