using MicroBlog.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MicroBlog.Data.Configuration
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
        }

        public PostConfiguration(string schema)
        {
            ToTable(schema + ".Posts");
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Title).IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(e => e.Content).IsRequired().HasColumnType("nvarchar");
            Property(e => e.PublicationDate).IsRequired().HasColumnType("datetime");

            HasRequired(p => p.Author).WithMany(a => a.Posts).HasForeignKey(p => p.Id);
        }
    }
}
