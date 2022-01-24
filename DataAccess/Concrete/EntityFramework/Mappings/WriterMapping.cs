using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class WriterMapping : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).ValueGeneratedOnAdd();

            builder.Property(w => w.FirstName).HasMaxLength(50);
            builder.Property(w => w.FirstName).IsRequired(true);

            builder.Property(w => w.LastName).HasMaxLength(50);
            builder.Property(w => w.LastName).IsRequired(true);

            builder.Property(w => w.Email).HasMaxLength(50);
            builder.Property(w => w.Email).IsRequired(true);

            builder.Property(w => w.Password).HasMaxLength(50);
            builder.Property(w => w.Password).IsRequired(true);

            builder.Property(w => w.Status).IsRequired(true);

            builder.ToTable("Writers");
        }
    }
}
