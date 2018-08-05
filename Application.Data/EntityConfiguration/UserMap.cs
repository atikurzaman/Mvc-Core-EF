﻿using Application.Domain;
using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{    
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.Id).ValueGeneratedOnAdd();            

            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.Email).HasMaxLength(256).IsRequired();            

            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            builder.Property(u => u.UserName).HasMaxLength(256).IsRequired();

            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);

            builder.Property(u => u.PasswordHash).IsRequired();            

            builder.Property(u => u.PhoneNumber).IsRequired();            

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.NormalizedEmail)
                .HasName("EmailIndex");

            builder.HasIndex(u => u.NormalizedUserName)
                .IsUnique()
                .HasName("UserNameIndex")
                .HasFilter("[NormalizedUserName] IS NOT NULL");

            builder.ToTable("User");
        }
    }
}
