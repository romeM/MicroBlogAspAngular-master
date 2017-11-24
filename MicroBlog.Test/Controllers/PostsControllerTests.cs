using MicroBlog.Controllers;
using MicroBlog.Data;
using MicroBlog.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MicroBlog.Test.Controllers
{
    /*************************************************************************
    **************************************************************************
    In order to run the tests, the connectionstring in the App.Config file of the MicroBlog.Test 
    project has to been configured to point to the right database full relative path in MicroBlog/App_Data.
    Example : 
    <add name="MicroBlog" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;
    AttachDbFilename=C:\Dev\MicroBlogAspAngular-master\MicroBlog\App_Data\MicroBlogDb.mdf;
    Integrated Security=True" providerName="System.Data.SqlClient" />
    **************************************************************************
    **************************************************************************
    *************************************************************************/
    [TestClass]
    public class PostsControllerTests
    {
        private MicroBlogContext microBlogContext;
        private PostsController postController;
        public PostsControllerTests()
        {
            //Arrange
            this.microBlogContext = new MicroBlogContext();
            this.postController = new PostsController(microBlogContext);
        }

        [TestMethod]
        public void Get_Returns_PublicationDateDescendingOrderedPosts()
        {
            //Arrange
            List<Post> postsList = this.microBlogContext.Posts.OrderByDescending(a => a.PublicationDate).ToList();

            //Act
            var posts = this.postController.Get().ToList();

            //Assert
            Assert.AreSame(postsList[0], posts[0]);
            Assert.AreSame(postsList[1], posts[1]);
            Assert.AreSame(postsList[2], posts[2]);
            Assert.AreSame(postsList[3], posts[3]);
        }

        [TestMethod]
        public void Get_With_Id_Returns_Post()
        {
            //Arrange
            int id = 1;
            Post post1 = this.microBlogContext.Posts.Include(a => a.Author).First(a => a.Id == id);

            //Act
            var postGet = this.postController.Get(id);

            //Assert
            Assert.AreSame(post1, postGet);
        }

        [TestMethod]
        public void Post_Post_AddPost()
        {
            //Arrange
            Post post = new Post()
            {
                Title = "toto",
                Content = "tata",
                Author = new Author() { Id=1 }
            };

            //Act
            this.postController.Post(post);
            Post addedPost = this.microBlogContext.Posts.Find(post.Id);

            //Assert
            Assert.AreSame(post, addedPost);
        }

        [TestMethod]
        public void Put_Post_UpdatePost()
        {
            //Arrange
            Post post = new Post()
            {
                Id = 1,
                Title = "toto",
                Content = "tata",
                Author = new Author() { Id = 1 }
            };

            //Act
            this.postController.Put(post);
            Post updatedPost = this.microBlogContext.Posts.Find(post.Id);

            //Assert
            Assert.AreEqual(post.Id, updatedPost.Id);
            Assert.AreEqual(post.Content, updatedPost.Content);
            Assert.AreEqual(post.Title, updatedPost.Title);
            Assert.AreEqual(post.Author.Id, updatedPost.Author.Id);
        }

        [TestMethod]
        public void Delete_Deletes_Post()
        {
            //Arrange
            int id = 2;

            //Act
            bool postExist = this.microBlogContext.Posts.Any(a => a.Id == id);
            this.postController.Delete(id);
            bool postDelete = this.microBlogContext.Posts.Any(a => a.Id == id);

            //Assert
            Assert.IsFalse(postDelete);
            Assert.IsTrue(postExist);
        }
    }
}
