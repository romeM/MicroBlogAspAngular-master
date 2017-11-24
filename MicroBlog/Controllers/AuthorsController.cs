using MicroBlog.Data;
using MicroBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace MicroBlog.Controllers
{
    public class AuthorsController : ApiController
    {
        MicroBlogContext microBlogContext;
        public AuthorsController(MicroBlogContext microBlogContext)
        {
            this.microBlogContext = microBlogContext;
        }
        
        public IEnumerable<Author> Get()
        {
            var result = microBlogContext.Authors.Include(a => a.Posts).OrderBy(a => a.LastName).ToList();
            
            return result;
        }
        
        public Author Get(int id)
        {
            return microBlogContext.Authors.Include(a => a.Posts).First(a => a.Id == id);
        }
        
        public void Post(Author author)
        {
            author.CreationDate = DateTime.Now;
            microBlogContext.Authors.Add(author);
            microBlogContext.SaveChanges();
        }
        
        public void Put(Author author)
        {
            Author authorToUpdate = microBlogContext.Authors.Find(author.Id);
            authorToUpdate.Email = author.Email;
            authorToUpdate.FirstName = author.FirstName;
            authorToUpdate.LastName = author.LastName;
            microBlogContext.SaveChanges();
        }
        
        public void Delete(int id)
        {
            Author authorToDelete = microBlogContext.Authors.Include(a => a.Posts).First(a => a.Id == id);
            microBlogContext.Authors.Remove(authorToDelete);
            microBlogContext.SaveChanges();
        }
    }
}