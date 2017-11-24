using System;

namespace MicroBlog.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set;}
    }
}