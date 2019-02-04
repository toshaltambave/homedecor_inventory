using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeDecor.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace HomeDecor.Controllers
{
    public class UserRegistrationsController : Controller
    {
        private readonly HomeDecorContext _context;

        public UserRegistrationsController(HomeDecorContext context)
        {
            _context = context;
        }

        // GET: UserRegistration/Register
        [HttpGet]
        public IActionResult Register()
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                var items = from m in _context.Facility
                            select m.Facility_code;
                ViewData["facility"] = items;
                return View();

            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }

        }

        //Get: //UserRegistration/ComfirmEmail
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(int? UserID, string ctoken)
        {

                if (ModelState.IsValid)
                {
                    if (UserID == null || ctoken == null)
                    {
                        return View("Error");
                    }
                    var user = await _context.Users.SingleOrDefaultAsync(m => m.UserID == UserID);

                    if (user == null)
                    {
                        return View("Error");
                    }
                    if (UserID.Equals(user.UserID) && ctoken == "1234")
                    {

                        return RedirectToAction("Success", "UserRegistrations");

                    }

                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    return View("Error");
                }
            }

        //// POST: /Account/Register 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind("UserID,UserName,UserPassword,AccessRights,Email,Facility_code,isActive")] UserAccount user)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                _context.Add(user);
                var result = await _context.SaveChangesAsync();
                ViewBag.rue = result;
                {
                    var SenderEmail = new MailAddress("cse5320.team2@gmail.com", "Admin");
                    var RecieverEmail = new MailAddress(user.Email, "reciever");
                    const string SenderPassword = "pass";
                    const string subject = "Test";
                    string ConfirmToken = "1234";
                    string body = string.Format("Dear {0}<BR/>Thank you for your registration, " +
                        "please click on the below link to comlete your registration: " +
                        "<a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", user.UserID, Url.Action("ConfirmEmail", "UserRegistrations", new
                        {
                            UserID = user.UserID,
                            ctoken = ConfirmToken


                        }, protocol: HttpContext.Request.Scheme));

                    var smtp = new SmtpClient
                    {
                        Host = "Smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(SenderEmail.Address, SenderPassword)

                    };

                    using (var message = new MailMessage(SenderEmail, RecieverEmail)
                    {
                        Subject = subject,
                        Body = body

                    }
                        )
                    {
                        smtp.Send(message);
                    }
                    return RedirectToAction("Index", "UserAccounts");
                }
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }
        [HttpGet]
        public IActionResult Success()
        {

            return View();
        }

        // If we got this far, something failed, redisplay formreturn View(model); 
    }
}

