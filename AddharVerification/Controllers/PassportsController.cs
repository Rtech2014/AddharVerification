using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddharVerification.Data;
using AddharVerification.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AddharVerification.Controllers
{
    public class PassportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passports
        public async Task<IActionResult> Index(string searchData)
        {
            //if (searchData.ToString() == null)
            //{
            //    return View(await _context.Passport.ToListAsync());
            //}
            //else
            //{
                var sdata = _context.Passport.Where(s => s.Aadhar.Contains(searchData));
                return View(sdata);
            //}
        }

        // GET: Passports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = await _context.Passport
                .Include(p => p.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // GET: Passports/Create
        public IActionResult Create()
        {
            var data = _context.Passport.ToList();

            foreach (var item in data)
            {
                if (item.ApplicationMemberId == User.getUserId())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult PassportApprove(string id)
        {
            PassportApprove paa = new PassportApprove();
            paa.PassportId = id;
            paa.Status = true;
            paa.AppuserId = User.getUserId();
            _context.PassportApprove.Add(paa);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // POST: Passports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FName,LName,MobileNum,Aadhar,PlaceOfBirth,ExpiryDate,DOB,Gender,CivilStatus,Address,Occupation,NameOfMother,NameOfFather,Citizenship,Photo,ApplicationMemberId")] Passport passport, IFormFile formFile)
        {

                    if (formFile != null)   
                    {
                        if (formFile.Length > 0)
                        {
                            byte[] p1 = null;
                            using (var fs1 = formFile.OpenReadStream())
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                            if (ModelState.IsValid)
                            {
                                var userid = User.getUserId();
                                passport.ApplicationMemberId = userid;
                                passport.Photo = p1;
                                _context.Add(passport);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }

            return RedirectToAction(nameof(Index));
        }

        // GET: Passports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = await _context.Passport.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }
            ViewData["ApplicationMemberId"] = new SelectList(_context.Users, "Id", "Email", passport.ApplicationMemberId);
            return View(passport);
        }

        // POST: Passports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FName,LName,MobileNum,PlaceOfBirth,DOB,Gender,CivilStatus,Address,Occupation,NameOfMother,NameOfFather,Citizenship,Photo,ApplicationMemberId")] Passport passport)
        {
            if (id != passport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassportExists(passport.Id))
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
            ViewData["ApplicationMemberId"] = new SelectList(_context.Users, "Id", "Id", passport.ApplicationMemberId);
            return View(passport);
        }

        // GET: Passports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = await _context.Passport
                .Include(p => p.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // POST: Passports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passport = await _context.Passport.FindAsync(id);
            _context.Passport.Remove(passport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassportExists(int id)
        {
            return _context.Passport.Any(e => e.Id == id);
        }
    }
}
