using MicroBlog.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MicroBlog.Data.Configuration
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
        }

        public AuthorConfiguration(string schema)
        {
            ToTable(schema + ".Authors");
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.FirstName).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(e => e.LastName).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(e => e.Email).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(e => e.CreationDate).IsRequired().HasColumnType("datetime");
            
            HasMany(b => b.Posts)
            .WithOptional()
            .WillCascadeOnDelete();
        }
    }
}
