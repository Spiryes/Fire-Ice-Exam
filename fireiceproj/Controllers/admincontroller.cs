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

namespace fireiceproj.Controllers
{
    public class admincontroller : Controller
    {
        private readonly ApplicationDbContext _context;

        public admincontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Queries
        public async Task<IActionResult> Index()
        {

            return View(await _context.Roles.ToListAsync());

        }
      
      
    }
}
