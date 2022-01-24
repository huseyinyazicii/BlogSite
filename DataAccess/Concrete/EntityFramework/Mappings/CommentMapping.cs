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
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.UserName).HasMaxLength(50);
            builder.Property(c => c.UserName).IsRequired(true);

            builder.Property(c => c.Content).HasMaxLength(500);
            builder.Property(c => c.Content).IsRequired(true);

            builder.Property(c => c.Date).IsRequired(true);

            builder.Property(c => c.Status).IsRequired(true);

            builder.Property(c => c.BlogId).IsRequired(true);
            builder.HasOne<Blog>(c => c.Blog).WithMany(b => b.Comments).HasForeignKey(c => c.BlogId);

            builder.ToTable("Comments");
        }
    }
}
