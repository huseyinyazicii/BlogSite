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
    public class MessageMapping : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.UserName).HasMaxLength(50);
            builder.Property(m => m.UserName).IsRequired(true);

            builder.Property(m => m.UserEmail).HasMaxLength(50);
            builder.Property(m => m.UserEmail).IsRequired(true);

            builder.Property(m => m.UserPhone).HasMaxLength(11);
            builder.Property(m => m.UserPhone).IsRequired(true);

            builder.Property(m => m.UserMessage).HasMaxLength(500);
            builder.Property(m => m.UserMessage).IsRequired(true);

            builder.Property(m => m.Title).HasMaxLength(50);
            builder.Property(m => m.Title).IsRequired(true);

            builder.ToTable("Messages");
        }
    }
}
