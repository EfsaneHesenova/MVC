using FrontToBacktask.DAL;
using FrontToBacktask.DTOs;
using FrontToBacktask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreatUserDto creatUser)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    FirstName = creatUser.FirstName,
                    LastName = creatUser.LastName,
                    Email = creatUser.Email,
                    UserName = creatUser.UserName
                };

                var result = await _userManager.CreateAsync(appUser, creatUser.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }

                    return View(creatUser);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(creatUser);
        }
    }
}
