using System;
using System.Web;   
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
    public class FacilityModelsController : Controller
    {
        private readonly HomeDecorContext _context;

        public FacilityModelsController(HomeDecorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = from m in _context.Facility
                        select m;

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

        public async Task<IActionResult> ActiveFacilities()
        {
            var facility = _context.Facility.Where(m => m.isActive.Equals("True") ).FirstOrDefault();

           // if (facility.isActive.Equals("True"))
            //{
                // HttpContext.Session.SetString("Username", userAccount.UserName.ToString());


                TempData["username"] = HttpContext.Session.GetString("Username");
                var items = from m in _context.Facility
                            select m;
                //if(items.Equals())

                return View(await items.ToListAsync());

            //}
          //  else
           // {
                // return View(await items.ToListAsync());
                //}

               // return RedirectToAction("Login", "UserLogins");
            //}
        }

        public async Task<IActionResult> InactiveFacilities()
        {
            var items = from m in _context.Facility
                        select m;

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
        // GET: FacilityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var facilityModel = await _context.Facility
                                                  .SingleOrDefaultAsync(m => m.Facility_code == id);
                if (facilityModel == null)
                {
                    return NotFound();
                }

                return View(facilityModel);
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
        public async Task<IActionResult> Create([Bind("Facility_code,Facility_name,Facility_description,isActive")] FacilityModel facilityModel)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(facilityModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(facilityModel);
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

                var facilityModel = await _context.Facility.SingleOrDefaultAsync(m => m.Facility_code == id);
                if (facilityModel == null)
                {
                    return NotFound();
                }
                return View(facilityModel);
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
        public async Task<IActionResult> Edit(int id, [Bind("Facility_code,Facility_name,Facility_description,isActive")] FacilityModel facilityModel)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id != facilityModel.Facility_code)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(facilityModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FacilityModelExists(facilityModel.Facility_code))
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
                return View(facilityModel);
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

                var facilityModel = await _context.Facility.SingleOrDefaultAsync(m => m.Facility_code == id);
                if (facilityModel == null)
                {
                    return NotFound();
                }
                return View(facilityModel);
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
        public async Task<IActionResult> Delete(int id, [Bind("Facility_code,Facility_name,Facility_description,isActive")] FacilityModel facilityModel)
        {
            TempData["username"] = HttpContext.Session.GetString("Username");
            if (TempData["username"] != null)
            {
                if (id != facilityModel.Facility_code)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(facilityModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FacilityModelExists(facilityModel.Facility_code))
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
                return View(facilityModel);
            }
            else
            {
                return RedirectToAction("Login", "UserLogins");
            }
        }


        private bool FacilityModelExists(int id)
        {
            return _context.Facility.Any(e => e.Facility_code == id);
        }
    }
}
