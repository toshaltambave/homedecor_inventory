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
    public class DecorModelsController : Controller
    {
        private readonly HomeDecorContext _context;

        public DecorModelsController(HomeDecorContext context)
        {
            _context = context;
        }

        // GET: DecorModels
        public async Task<IActionResult> Index(int SearchString1, string searchString)
        {
            var items = from m in _context.Resource
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Resource_name.Contains(searchString));
            }

            if (SearchString1 != 0)
            {
                items = items.Where(s => s.Resource_code == SearchString1);
                // items = items.Where(s => s.Furniture_type == SearchString1);
            }

            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                return View(await items.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }
        
        public async Task<IActionResult> Index2()
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
        {
                return View(await _context.Resource.ToListAsync());
        }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: DecorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var decorModel = await _context.Resource
                                               .SingleOrDefaultAsync(m => m.Resource_code == id);
                if (decorModel == null)
                {
                    return NotFound();
                }

                return View(decorModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: DecorModels/Create
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

        // POST: DecorModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Resource_code,Resource_name,Resource_description, Color, Size, Quantity, Facility_code,isActive")] DecorModel decorModel)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(decorModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(decorModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: DecorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var decorModel = await _context.Resource.SingleOrDefaultAsync(m => m.Resource_code == id);
                if (decorModel == null)
                {
                    return NotFound();
                }
                return View(decorModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // POST: DecorModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Resource_code,Resource_name,Resource_description, Color, Size, Quantity,Facility_code,isActive")] DecorModel decorModel)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id != decorModel.Resource_code)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(decorModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DecorModelExists(decorModel.Resource_code))
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
                return View(decorModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // GET: DecorModels/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var decorModel = await _context.Resource.SingleOrDefaultAsync(m => m.Resource_code == id);
                if (decorModel == null)
                {
                    return NotFound();
                }
                return View(decorModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        // POST: DecorModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [Bind("Resource_code,Resource_name,Resource_description, Color, Size, Quantity,Facility_code,isActive")] DecorModel decorModel)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id != decorModel.Resource_code)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(decorModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DecorModelExists(decorModel.Resource_code))
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
                return View(decorModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }

        private bool DecorModelExists(int id)
        {
            return _context.Resource.Any(e => e.Resource_code == id);
        }
    }
}
