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
        private readonly SignInManager<AppUser> _signInManager;



        public AccountsController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
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

        public IActionResult Login()
            { return View(); }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View();
            }
            AppUser? user = await _userManager.FindByEmailAsync(loginUserDto.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginUserDto.EmailOrUsername);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, loginUserDto.isPersistant, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
