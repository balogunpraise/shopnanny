using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopnanny.Core.Application.Constants;
using Shopnanny.Core.Entities;
using Shopnanny.ViewModels;

namespace Shopnanny.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(SignInManager<ApplicationUser> signinManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register(string error)
        {
            if(error != null)
            {
                ViewBag.Error = error;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userManager.FindByEmailAsync(model.Email);
                if (userExists == null)
                {
                    var user = new ApplicationUser
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                State = model.State,
                                City = model.City,
                                StreetName = model.Street,
                                Country = model.Country,
                                IsShippingAddress = true
                            }
                        }
                    };
                    await _userManager.CreateAsync(user, model.Password);
                    await _userManager.AddToRoleAsync(user, RoleConstants.Customer);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Register", new { error = "A user with same email already exists." });
        }
    }
}
