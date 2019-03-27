using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gav.IdentityDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Gav.IdentityDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                //var user = await _userManager.GetUserAsync(HttpContext.User);
                //await _userManager.AddClaimAsync(user,new Claim("CategoriaEmpleado","4"));

                var claims = User.Claims.ToList();
            }

            return View();
        }

        public async Task<IActionResult> About()
        {

            if (User.Identity.IsAuthenticated)
            {
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                var user = await _userManager.GetUserAsync(HttpContext.User);

                await _userManager.AddToRoleAsync(user, "Admin");
            }

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //[Authorize(Roles ="Admin") ]
        [Authorize(Policy = "PolicyCategoriaEmpleado")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
