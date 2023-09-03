using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechChallengeTwo.Models.Entities.Blog
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable(nameof(BlogPost));

            builder.Property(p => p.Title)
                .HasMaxLength(BlogPostConstant.TitleLength)
                .IsRequired();
            builder.Property(p => p.Content)
                .HasMaxLength(BlogPostConstant.ContentLength)
                .IsRequired();
            builder.Property(p => p.Author)
                .HasMaxLength(BlogPostConstant.AuthorLength)
                .IsRequired();

            builder.Property(p => p.PublishDate)
                .IsRequired();
        }
    }
}
