using Microsoft.AspNet.Mvc;

namespace WebMarkupMin.AspNet5.FileActionResultError.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("file.xml")]
        public IActionResult GetFile()
        {
            var xml = @"<xml version='1.0'><root><greeting>Hello, World</greeting></root>";

            var xmlBytes = System.Text.Encoding.UTF8.GetBytes(xml);

            return File(xmlBytes, "application/atom+xml", "feed.xml");
        }
    }
}
