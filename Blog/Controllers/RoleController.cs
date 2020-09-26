using Blog.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class RoleController : Controller
    {
        private AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
        public AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }


        public ActionResult Index()
        {
            if (RoleManager.Roles != null)
            {
                return View(RoleManager.Roles);
            }
            else
            {
                return RedirectToAction("Create", "Role");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppRole model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole { Name = model.Name };
                IdentityResult result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "RoleManager");
                }
                else
                {
                    ModelState.AddModelError("", "It's something wrong");
                }
            }
            return View(model);
        }
    }
}