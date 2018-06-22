﻿// <auto-generated />
using System;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180620024514_asdsdas")]
    partial class asdsdas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Domain.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(256);

                    b.Property<string>("MacAddress")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<long?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Application.Domain.Membership.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Application.Domain.Membership.RoleClaim", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Application.Domain.Membership.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Application.Domain.Membership.UserClaim", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Application.Domain.Membership.UserLogin", b =>
                {
                    b.Property<long>("LoginProvider")
                        .HasMaxLength(256);

                    b.Property<long>("ProviderKey")
                        .HasMaxLength(256);

                    b.Property<long>("Id");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(256);

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Application.Domain.Membership.UserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.Property<long?>("RoleId1");

                    b.Property<long?>("UserId1");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Application.Domain.Membership.UserToken", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("Value")
                        .HasMaxLength(256);

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Application.Domain.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ControllerName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Disable");

                    b.Property<bool>("HasAccess");

                    b.Property<string>("MenuArea")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Application.Domain.Category", b =>
                {
                    b.HasOne("Application.Domain.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Application.Domain.Membership.RoleClaim", b =>
                {
                    b.HasOne("Application.Domain.Membership.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Application.Domain.Membership.UserClaim", b =>
                {
                    b.HasOne("Application.Domain.Membership.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Application.Domain.Membership.UserLogin", b =>
                {
                    b.HasOne("Application.Domain.Membership.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Application.Domain.Membership.UserRole", b =>
                {
                    b.HasOne("Application.Domain.Membership.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Application.Domain.Membership.Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("Application.Domain.Membership.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Application.Domain.Membership.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Application.Domain.Membership.UserToken", b =>
                {
                    b.HasOne("Application.Domain.Membership.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Application.Domain.Menu", b =>
                {
                    b.HasOne("Application.Domain.Menu", "ParentMenu")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
