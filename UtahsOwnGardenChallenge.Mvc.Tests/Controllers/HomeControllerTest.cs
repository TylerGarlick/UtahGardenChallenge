using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtahsOwnGardenChallenge.Mvc.Controllers;

namespace UtahsOwnGardenChallenge.Mvc.Tests.Controllers
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
			Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
		}
	}
}
