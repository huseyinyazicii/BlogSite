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
    public class BlogMapping : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Title).HasMaxLength(100);
            builder.Property(b => b.Title).IsRequired(true);

            builder.Property(b => b.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(b => b.Content).IsRequired(true);

            builder.Property(b => b.Image).HasColumnType("NVARCHAR(MAX)");
            builder.Property(b => b.Image).IsRequired(true);

            builder.Property(b => b.NumberOfComments).IsRequired(true);

            builder.Property(b => b.NumberOfLikes).IsRequired(true);

            builder.Property(b => b.Status).IsRequired(true);

            builder.Property(b => b.Date).IsRequired(true);

            builder.Property(b => b.CategoryId).IsRequired(true);
            builder.Property(b => b.WriterId).IsRequired(true);
            builder.HasOne<Category>(b => b.Category).WithMany(c => c.Blogs).HasForeignKey(b => b.CategoryId);
            builder.HasOne<Writer>(b => b.Writer).WithMany(w => w.Blogs).HasForeignKey(b => b.WriterId);

            builder.ToTable("Blogs");
        }
    }
}
