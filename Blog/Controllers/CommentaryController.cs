using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;

namespace Blog.Controllers
{
    public class CommentaryController : Controller
    {
        private static int? _ArticleId = null;

        // GET: Commentary
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WriteCommentary(int ArticleId)
        {
            _ArticleId = ArticleId;
            ViewBag.ArticleId = ArticleId;
            return PartialView("PartialAddCommentForm");
        }                                          

        [HttpPost]
        public ActionResult AddCommentary(Comment comment, int ArticleId)
        {
            if (comment == null && _ArticleId != null)
            {
                return View("~/Views/Home/ErrorView", new { error = "Commentary was not received" });
            }
            if (comment.Text.Length > 400)
            {
                comment.Text = comment.Text.Substring(0, 400);
            }
            if (ModelState.IsValid)
            {
                comment.ArticleId = (int)_ArticleId;
                comment.ArticleId = ArticleId;
                comment.Id = 0;
                comment.Date = DateTime.Now;

                using (BlogDbContext BlogDB = new BlogDbContext())
                {
                    BlogDB.Comments.Add(comment);
                    BlogDB.SaveChanges();
                }

                return PartialView("PartialAppendComment", comment);
            }
            else
            {
                return View("~/Views/Home/ErrorView", new { error = "Commentary was not received" });
            }
        }
    }
}