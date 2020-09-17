using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public  ActionResult Index()
        {
            IEnumerable<Article> articles;

            using (BlogDbContext BlogDB = new BlogDbContext())
            {
                articles = from a in BlogDB.Articles.ToList()
                                                orderby a.Id descending
                                                select a;
            } 
            if (articles != null)
            {
                return View(articles);
            }
            else
            {
                return View("ErrorView", new { error = "Database was not loaded" } );
            }
            
        }


        [HttpGet]
        public ActionResult ShowCategory(string category)
        {
            IEnumerable<Article> articles;
            using (BlogDbContext BLogDB = new BlogDbContext())
            {
                articles = BLogDB.Articles.Where(i => i.Category == category).ToList();
                return View("Index", articles);
            }
        }

        [HttpGet]
        public  ActionResult SelectByAuthor(string author)
        {
            IEnumerable<Article> articles;
            using (BlogDbContext BLogDB = new BlogDbContext())
            {
                articles = BLogDB.Articles.Where(i => i.Author == author).ToList();
                return View("Index", articles);
            }
        }

        public ActionResult ShowBooks()
        {
            return View();
        }

        public ActionResult ShowAboutMe()
        {
            return View();
        }

        public ActionResult Profiles()
        {
            return View();
        }

        public ActionResult ErrorView(string error)
        {
            ViewBag.ErrorMessage = error;
            return View();
        }

    }
}