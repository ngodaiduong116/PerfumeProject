using ePerfume.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.Dob).IsRequired(true);
        }
    }
}
