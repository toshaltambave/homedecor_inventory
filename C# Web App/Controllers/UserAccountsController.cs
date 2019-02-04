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
    public class UserAccountsController : Controller
    {
        private readonly HomeDecorContext _context;
        public UserAccountsController(HomeDecorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int SearchString1, string searchString)         {
            var items = from m in _context.Users
                        select m;

            if (!String.IsNullOrEmpty(searchString))             {                 items = items.Where(s => s.UserName.Contains(searchString));             }              if (SearchString1 != 0)             {                 items = items.Where(s => s.UserID == SearchString1);
                // items = items.OrderByDescending(s=>s.UserName);
            }              TempData["username"] = HttpContext.Session.GetString("Username");             if (TempData["username"] != null)             {                 return View(await items.ToListAsync());             }             else             {                 return RedirectToAction("Login", "UserLogins");             }         }    


        // GET: UserAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var userAccount = await _context.Users
                    .SingleOrDefaultAsync(m => m.UserID == id);
                if (userAccount == null)
                {
                    return NotFound();
                }

                return View(userAccount);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: UserAccounts/Create
        public IActionResult Create()
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");

            }

        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,UserPassword,AccessRights,Email,isActive")] UserAccount userAccount)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userAccount);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(userAccount);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var userAccount = await _context.Users.SingleOrDefaultAsync(m => m.UserID == id);
                if (userAccount == null)
                {
                    return NotFound();
                }
                return View(userAccount);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,UserName,UserPassword,AccessRights,Email,isActive")] UserAccount userAccount)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {


                if (id != userAccount.UserID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(userAccount);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserAccountExists(userAccount.UserID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(userAccount);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var userAccount = await _context.Users.SingleOrDefaultAsync(m => m.UserID == id);
                if (userAccount == null)
                {
                    return NotFound();
                }
                return View(userAccount);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [Bind("UserID,UserName,UserPassword,AccessRights,Email,isActive")] UserAccount userAccount)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {


                if (id != userAccount.UserID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(userAccount);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserAccountExists(userAccount.UserID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(userAccount);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        private bool UserAccountExists(int id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
