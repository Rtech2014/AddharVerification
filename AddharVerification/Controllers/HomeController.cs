using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddharVerification.Models;
using Microsoft.AspNetCore.Authorization;
using AddharVerification.Data;

namespace AddharVerification.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var userid = User.getUserId();
            var passtatus = _context.PassportApprove.ToList();
            foreach (var item in passtatus)
            {
                if (item.AppuserId == userid)
                {
                    ViewData["status"] = "You are approved for this passport";
                }
                else
                {
                    ViewData["status"] = "You are at pending or you had'nt applied for passport";
                }
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
