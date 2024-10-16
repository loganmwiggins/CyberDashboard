using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace CyberDashboardProj.Controllers
{
    public class NewsFeedController : Controller
    {
       public IActionResult Index(string filter = "Cybersecurity")
        {
            var articles = APIitems.GetArticles(filter);

            return View(articles); // Pass the articles to the Index view
        }

        [HttpPost]
        public IActionResult FilterResults(string filter)
        {
        // Redirect to Index action, passing the filter as a query parameter
            return RedirectToAction("Index", new { filter = filter });
        }

    }
    

    public class APIitems
    {
        public static List<Article> GetArticles(string query) { 
            string API_KEY = "667cf68eaa6e48b0b06f3bf0a9590003";
            List<Article> ArtList = new List<Article>();
            var newsApiClient = new NewsApiClient(API_KEY);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = query,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,

            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                foreach (var article in articlesResponse.Articles)
                {
                    if (article.Title != "[Removed]")
                    {
                        ArtList.Add(new Article(article.Title, article.Author, article.Description, article.PublishedAt.ToString(), article.Url,article.UrlToImage));
                    }

                }
            }
            return ArtList;
        }

        }
    


  

    public struct Article
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string Url { get; set; }
       public string ImagePath { get; set; }

        public Article(string title, string author, string description, string dateTime, string url, string imagepath)
        {
            Title = title;
            Author = author;
            Description = description;
            DateTime = dateTime;
            Url = url;
            ImagePath = imagepath;
        }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nDescription: {Description}\nDate: {DateTime}\nURL: {Url}\nImage: {ImagePath}";
        }
    }
}