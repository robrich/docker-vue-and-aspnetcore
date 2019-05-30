using Microsoft.AspNetCore.Mvc;

namespace MusicRank.Controllers
{
    public class SpaController : Controller
    {
        // Enumerate all SPA urls so we boot the Vue app correctly
        // Alternatively, use this as the 404 page so any unhandled url will boot the vue app
        [HttpGet("/")]
        [HttpGet("/about")]
        public ActionResult Index(string id) => File("/index.html", "text/html");
    }
}
