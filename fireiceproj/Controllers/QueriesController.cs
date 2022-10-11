using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fireiceproj.Data;
using fireiceproj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace fireiceproj.Controllers
{
    public class QueriesController : Controller
    {
        private readonly fireiceprojContext _context;
        private readonly UserManager<IdentityUser> usermb;

        public QueriesController(fireiceprojContext context, UserManager<IdentityUser> usermb)
        {
            _context = context;
            this.usermb = usermb;
        }

        // GET: Queries
        [Authorize]
        public async Task<IActionResult> Index()
        {

            return View(await _context.Queries.ToListAsync());

        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Indexadmin()
        {
            return View(await _context.Queries.ToListAsync());
        }
        
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> indexadmin(string status)
        {
            ViewData["status"] = status;
            var st = from x in _context.Queries select x;
            if (!String.IsNullOrEmpty(status))
            {
                st = st.Where(x => x.Idquer==int.Parse(status)||x.Nameoftechnition.Contains(status));
            }
            return View(await st.AsNoTracking().ToListAsync());
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(string status)
        {
            ViewData["status"] = status;
            var st = from x in _context.Queries select x;
            if (!String.IsNullOrEmpty(status))
            {
                st = st.Where(x => x.Status.Contains(status) );
            }
            return View(await st.AsNoTracking().ToListAsync());
        }

        // GET: Queries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queries = await _context.Queries
                .FirstOrDefaultAsync(m => m.Idquer == id);
            if (queries == null)
            {
                return NotFound();
            }

            return View(queries);
        }

        // GET: Queries/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Queries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idquer,Nameoftheproblem,Txt,Adress,Image,Status,Dateofvisit,Nameoftechnition")] Queries queries)
        {
            var loggedid = (await usermb.GetUserAsync(User)).Id;
            if (ModelState.IsValid)
            {
                _context.Add(queries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(queries);
        }

        // GET: Queries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queries = await _context.Queries.FindAsync(id);
            if (queries == null)
            {
                return NotFound();
            }
            return View(queries);
        }

        // POST: Queries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idquer,Nameoftheproblem,Txt,Adress,Image,Status,Dateofvisit,Nameoftechnition")] Queries queries)
        {
            if (id != queries.Idquer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueriesExists(queries.Idquer))
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
            return View(queries);
        }
        [Authorize(Roles = "Administrator,Tech")]
       // [Authorize(Roles = "Tech")]
        public async Task<IActionResult> EditEngenear(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queries = await _context.Queries.FindAsync(id);
            if (queries == null)
            {
                return NotFound();
            }
            return View(queries);
        }

        // POST: Queries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> EditEngenear(int id, [Bind("Idquer,Nameoftheproblem,Txt,Adress,Image,Status,Dateofvisit,Nameoftechnition")] Queries queries)
        {
            if (id != queries.Idquer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueriesExists(queries.Idquer))
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
            return View(queries);
        }

        // GET: Queries/Delete/5
        [Authorize(Roles = "Administrator,Tech")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queries = await _context.Queries
                .FirstOrDefaultAsync(m => m.Idquer == id);
            if (queries == null)
            {
                return NotFound();
            }

            return View(queries);
        }

        // POST: Queries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var queries = await _context.Queries.FindAsync(id);
            _context.Queries.Remove(queries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QueriesExists(int id)
        {
            return _context.Queries.Any(e => e.Idquer == id);
        }
    }
}
