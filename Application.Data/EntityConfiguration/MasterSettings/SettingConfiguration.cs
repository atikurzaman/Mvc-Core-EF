﻿using Application.Domain.MasterSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration.MasterSettings
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Key).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Value).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Group).HasMaxLength(256).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.ToTable("Setting");
        }
    }
}
