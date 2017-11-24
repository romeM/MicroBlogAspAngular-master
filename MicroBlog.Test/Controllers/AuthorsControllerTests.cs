using MicroBlog.Controllers;
using MicroBlog.Data;
using MicroBlog.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MicroBlog.Test.Controllers
{
    [TestClass]
    public class AuthorsControllerTests
    {
        [TestMethod]
        public void Get_Returns_Authors()
        {
            //Arrange
            var data = new List<Author>
            {
                new Author { LastName = "BBB" },
                new Author { LastName = "ZZZ" },
                new Author { LastName = "AAA" },
            }.AsQueryable();

            var authorDbSetMock = new Mock<DbSet<Author>>();
            //authorDbSetMock.As<IQueryable<Author>>().Setup(m => m.OrderBy(a => a.LastName))
            //    .Returns(data);

            var microBlogContextMock = new Mock<MicroBlogContext>(true);
            microBlogContextMock.Setup(m => m.Authors).Returns(authorDbSetMock.Object);
            var authorController = new AuthorsController(microBlogContextMock.Object);

            //Act
            var authorsDbSet =  authorController.Get();

            //Assert
            Assert.AreSame(authorDbSetMock.Object, authorsDbSet);
        }
    }
}
