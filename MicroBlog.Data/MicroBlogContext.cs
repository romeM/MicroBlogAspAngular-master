using MicroBlog.Data.Configuration;
using MicroBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MicroBlog.Data
{
    public class MicroBlogContext : DbContext
    {
        static MicroBlogContext()
        {
            Database.SetInitializer<MicroBlogContext>(new DbInitializer());
            using (MicroBlogContext db = new MicroBlogContext())
                db.Database.Initialize(false);
        }

        public MicroBlogContext()
            : base("Name=MicroBlog")
        {
        }
        
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
        }

    }
    class DbInitializer : DropCreateDatabaseAlways<MicroBlogContext>
    {
        protected override void Seed(MicroBlogContext microBlogContext)
        {
            // insert some file generes
            microBlogContext.Authors.Add(new Author()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john@smith.com",
                CreationDate = DateTime.Now.AddDays(-4),
                Posts = new List<Post>
                {
                    new Post() { Content="Le contenu du premier billet.",
                        PublicationDate = DateTime.Now.AddDays(-3),
                        Title= "Premier Billet" },
                    new Post() { Content="Le contenu du second billet.",
                        PublicationDate = DateTime.Now.AddDays(-2),
                        Title= "Second Billet" }
                }
            });

            microBlogContext.Authors.Add(new Author()
            {
                FirstName = "Steeve",
                LastName = "Ric",
                Email = "Steeve@Ric.com",
                CreationDate = DateTime.Now.AddDays(-5)
            });

            microBlogContext.Authors.Add(new Author()
            {
                FirstName = "Gerard",
                LastName = "Darmon",
                Email = "gg@darmon.com",
                CreationDate = DateTime.Now.AddDays(-7),
                Posts = new List<Post>
                {
                    new Post() { Content="Le contenu du premier billet de Gérard.",
                        PublicationDate = DateTime.Now.AddDays(-3),
                        Title= "Premier Billet de Gérard" },
                    new Post() { Content="Le contenu du second billet de Gérard.",
                        PublicationDate = DateTime.Now.AddDays(-6),
                        Title= "Second Billet de Gérard" }
                }
            });

            microBlogContext.Authors.Add(new Author()
            {
                FirstName = "Thomas",
                LastName = "Heron",
                Email = "Thomas@Heron.com",
                CreationDate = DateTime.Now.AddDays(-2)
            });

            microBlogContext.Authors.Add(new Author()
            {
                FirstName = "Bruce",
                LastName = "Mesquito",
                Email = "Bruce@Mesquito.com",
                CreationDate = DateTime.Now.AddDays(-1)
            });
            base.Seed(microBlogContext);
        }

    }

}


