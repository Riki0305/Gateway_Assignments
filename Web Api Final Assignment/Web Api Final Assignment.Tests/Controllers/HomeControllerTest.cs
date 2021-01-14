using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Web_Api_Final_Assignment;
using Web_Api_Final_Assignment.Controllers;

namespace Web_Api_Final_Assignment.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
