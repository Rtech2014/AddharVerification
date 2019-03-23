using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddharVerification.Data;
using AddharVerification.Models;

namespace AddharVerification.Controllers
{
    public class VisasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Visa.Include(v => v.AppUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Visas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visa = await _context.Visa
                .Include(v => v.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visa == null)
            {
                return NotFound();
            }

            return View(visa);
        }

        // GET: Visas/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Visas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Current,Destination,ApplicationMemberId")] Visa visa)
        {
            if (ModelState.IsValid)
            {
                visa.ApplicationMemberId = User.getUserId();
                _context.Add(visa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visa);
        }

        // GET: Visas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visa = await _context.Visa.FindAsync(id);
            if (visa == null)
            {
                return NotFound();
            }
            ViewData["ApplicationMemberId"] = new SelectList(_context.Users, "Id", "Id", visa.ApplicationMemberId);
            return View(visa);
        }

        // POST: Visas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Current,Destination,ApplicationMemberId")] Visa visa)
        {
            if (id != visa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisaExists(visa.Id))
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
            ViewData["ApplicationMemberId"] = new SelectList(_context.Users, "Id", "Id", visa.ApplicationMemberId);
            return View(visa);
        }

        // GET: Visas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visa = await _context.Visa
                .Include(v => v.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visa == null)
            {
                return NotFound();
            }

            return View(visa);
        }

        // POST: Visas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visa = await _context.Visa.FindAsync(id);
            _context.Visa.Remove(visa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MapLocation()
        {
           
            return View();
        }
        private bool VisaExists(int id)
        {
            return _context.Visa.Any(e => e.Id == id);
        }
    }
}
