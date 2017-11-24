using MicroBlog.Data;
using MicroBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace MicroBlog.Controllers
{
    public class PostsController : ApiController
    {

        MicroBlogContext microBlogContext;
        public PostsController(MicroBlogContext microBlogContext)
        {
            this.microBlogContext = microBlogContext;
        }
        // GET api/<controller>
        public IEnumerable<Post> Get()
        {
            return microBlogContext.Posts.Include(p => p.Author).OrderByDescending(a => a.PublicationDate);
        }

        public Post Get(int id)
        {
            return microBlogContext.Posts.Find(id);
        }

        public void Post(Post post)
        {
            post.PublicationDate = DateTime.Now;
            Author author = microBlogContext.Authors.First(p => p.Id == post.Author.Id);
            post.Author = author;
            microBlogContext.Posts.Add(post);
            microBlogContext.SaveChanges();
        }

        public void Put(Post post)
        {
            Post postToUpdate = microBlogContext.Posts.Include(p => p.Author).First(p => p.Id == post.Id);
            Author author = microBlogContext.Authors.First(p => p.Id == post.Author.Id);
            postToUpdate.Content = post.Content;
            postToUpdate.Title = post.Title;
            postToUpdate.Author = author;
            microBlogContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Post postToDelete = microBlogContext.Posts.Find(id);
            microBlogContext.Posts.Remove(postToDelete);
            microBlogContext.SaveChanges();
        }
    }
}