//using BookShop.Data;
//using BookShop.Data.Repositories;
//using BookShop.Web.Models;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace BookShop.Web.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly IUserRepository _userRepository;

//        public AccountController(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        [AllowAnonymous]
//        public IActionResult Login(string returnUrl = "/")
//        {
//            return View(new LoginModel { ReturnUrl = returnUrl });
//        }


//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<IActionResult> Login(LoginModel model)
//        {
//            var user = _userRepository.GetByUsernameAndPassword(model.UserName, model.Password);

//            if(user == null) 
//            { 
//                return Unauthorized();
//            }

//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
//                new Claim(ClaimTypes.Name, user.FullName),
//                new Claim(ClaimTypes.Role, user.Role),
//                new Claim("FavoriteColor", user.FavoriteColor)
//            };

//            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            var principal = new ClaimsPrincipal(identity);

//            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
//            {
//                IsPersistent = model.RememberMe
//            });

//            return LocalRedirect(model.ReturnUrl);
             
//        }

//        [AllowAnonymous]
//        public IActionResult LoginWithGG(string returnUrl = "/")
//        {
//            var props = new AuthenticationProperties
//            {
//                RedirectUri = Url.Action("GoogleLoginCallback"),
//                Items = {
//                    { "returnUrl", returnUrl }
//                }
//            };

//            return Challenge(props, GoogleDefaults.AuthenticationScheme);
//        }

//        public async Task<IActionResult> GoogleLoginCallback()
//        {
//            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

//            var claims = result.Principal.Claims;

//            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

//            var claimPrincipal = new ClaimsPrincipal(identity);

//            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

//            return LocalRedirect(result.Properties.Items["returnUrl"]);
//        }

//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return Redirect("/");
//        }
//    }
//}
