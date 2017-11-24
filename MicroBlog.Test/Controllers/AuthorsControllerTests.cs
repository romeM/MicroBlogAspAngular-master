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
    public class AuthorsControllerTests
    {
        private MicroBlogContext microBlogContext;
        private AuthorsController authorController;
        public AuthorsControllerTests()
        {
            //Arrange
            this.microBlogContext = new MicroBlogContext();
            this.authorController = new AuthorsController(microBlogContext);
        }

        [TestMethod]
        public void Get_Returns_LastNameOrderedAuthors()
        {
            //Arrange
            List<Author> authorsList = this.microBlogContext.Authors.OrderBy(a => a.LastName).ToList();

            //Act
            var authors = this.authorController.Get().ToList();

            //Assert
            Assert.AreSame(authorsList[0], authors[0]);
            Assert.AreSame(authorsList[1], authors[1]);
            Assert.AreSame(authorsList[2], authors[2]);
            Assert.AreSame(authorsList[3], authors[3]);
            Assert.AreSame(authorsList[4], authors[4]);
        }

        [TestMethod]
        public void Get_With_Id_Returns_Author()
        {
            //Arrange
            int id = 1;
            Author author1 = this.microBlogContext.Authors.Include(a => a.Posts).First(a => a.Id == id);

            //Act
            var authorGet = this.authorController.Get(id);

            //Assert
            Assert.AreSame(author1, authorGet);
        }

        [TestMethod]
        public void Post_Author_AddAuthor()
        {
            //Arrange
            Author author = new Author()
            {
                LastName = "toto",
                FirstName = "tata",
                Email = "tata@toto.com"
            };

            //Act
            this.authorController.Post(author);
            Author addedAuthor = this.microBlogContext.Authors.Find(author.Id);

            //Assert
            Assert.AreSame(author, addedAuthor);
        }

        [TestMethod]
        public void Put_Author_UpdateAuthor()
        {
            //Arrange
            Author author = new Author()
            {
                Id=1,
                LastName = "toto",
                FirstName = "tata",
                Email = "tata@toto.com"
            };

            //Act
            this.authorController.Put(author);
            Author updatedAuthor = this.microBlogContext.Authors.Find(author.Id);

            //Assert
            Assert.AreEqual(author.Id, updatedAuthor.Id);
            Assert.AreEqual(author.LastName, updatedAuthor.LastName);
            Assert.AreEqual(author.FirstName, updatedAuthor.FirstName);
            Assert.AreEqual(author.Email, updatedAuthor.Email);
            Assert.AreNotEqual(author.CreationDate, updatedAuthor.CreationDate);
        }

        [TestMethod]
        public void Delete_Deletes_Author()
        {
            //Arrange
            int id = 2;

            //Act
            bool authorExist = this.microBlogContext.Authors.Any(a => a.Id == id);
            this.authorController.Delete(id);
            bool authorDelete = this.microBlogContext.Authors.Any(a => a.Id == id);

            //Assert
            Assert.IsFalse(authorDelete);
            Assert.IsTrue(authorExist);
        }
    }
}
