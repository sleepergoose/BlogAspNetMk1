using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;
using System.Data.Entity;
using System.Net;

namespace Blog.Controllers
{
    public class ArticleHoldingController : Controller
    {
        const int ArticleShortDescriptionLenth = 500;

        // GET: ArticleHolding
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteArticle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (BlogDbContext BlogDB = new BlogDbContext())
            {
                Article article = BlogDB.Articles.Find(id);
                if (article == null)
                {
                    return HttpNotFound();
                }    
                return View(article);
            }
        }

        [HttpPost, ActionName("DeleteArticle")]
        public ActionResult DeleteArticle(int id)
        {
            using (BlogDbContext BlogDB = new BlogDbContext())
            {
                Article article = BlogDB.Articles.Find(id);
                BlogDB.Articles.Remove(article);
                BlogDB.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult EditArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditArticle(int Id)
        {
            using (BlogDbContext BlogDB = new BlogDbContext())
            {
                Article article = BlogDB.Articles.Find(Id);
                return PartialView("PartialEditBook", article);
            }
            
        }

        [HttpGet]
        public ActionResult ReadMore(int Id)
        {
            Article article;
            using (BlogDbContext BlogDB = new BlogDbContext())
            {
                article = BlogDB.Articles.Find(Id);
                ViewBag.Comments = BlogDB.Comments.Find(Id);
            }
            
            /*
            var dataFile = Server.MapPath("/Content/2.cshtml");
            ViewBag.Content = Content(article.Text, "text/html").Content;
            */
            return View(article);
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(Article article)
        {
            if (article == null)
            {
                throw new Exception();
            }

            if (ModelState.IsValid)
            {
                article.Id = 0;
                article.Date = DateTime.Now;

                if (article.ShortDescription.Length > 500)
                {
                    article.ShortDescription = article.ShortDescription.Substring(0, ArticleShortDescriptionLenth);
                }

                using (BlogDbContext BlogDB = new BlogDbContext())
                {
                    BlogDB.Articles.Add(article);
                    BlogDB.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("ErrorView", new { error = "Article wasn't saved" });
            }
        }

    }
}