﻿using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataAccessLayer.EntityConfiguration
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(40);
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(40);
            Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(30);

            HasKey(x => x.Id);

        }
    }
}
