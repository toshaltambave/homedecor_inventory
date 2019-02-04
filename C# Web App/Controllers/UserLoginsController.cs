using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeDecor.Models;
using Microsoft.AspNetCore.Http;

namespace HomeDecor.Controllers
{
    public class UserLoginsController : Controller
    {
        private readonly HomeDecorContext _context;

        public UserLoginsController(HomeDecorContext context)
        {
            _context = context;
        }

        // GET: UserLogins/Login
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin lg)
        {
            //if (ModelState.IsValid)
            //{
                var userAccount = _context.Users.Where(m => m.UserName.Equals(lg.UserName) && m.UserPassword.Equals(lg.UserPassword)).FirstOrDefault();
                //if (userAccount != null && userAccount.UserName.Equals("prachi"))
                if (userAccount != null)
                {
                    if (userAccount.AccessRights.Equals("RWX"))
                    {
                        HttpContext.Session.SetString("Username", userAccount.UserName.ToString());


                        TempData["username"] = HttpContext.Session.GetString("Username");

                        return RedirectToAction("AdminLogin", "UserLogins");
                    }
                    else if (userAccount.AccessRights.Equals("RW"))
                    {
                        HttpContext.Session.SetString("Username", userAccount.UserName.ToString());
                        return RedirectToAction("Index", "DecorModels");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Username", userAccount.UserName.ToString());
                        return RedirectToAction("Index2", "DecorModels");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password does not match");
                }
            //}
            return View();
        }
        [HttpGet]
        public IActionResult AdminLogin()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }

        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "UserLogins");
        }

    }
}
