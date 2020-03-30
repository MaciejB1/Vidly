using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidly.Controllers;

namespace VidlyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.About() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
