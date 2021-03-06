﻿using System;
using System.Collections.Generic;

namespace MicroBlog.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}