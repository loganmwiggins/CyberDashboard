using Microsoft.AspNetCore.Mvc;

namespace CyberDashboardProj.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        /*
         private static readonly string API_KEY = "667cf68eaa6e48b0b06f3bf0a9590003";
        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = query,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                //  From = new DateTime(2018, 1, 25)
            });
         */
    }
}
