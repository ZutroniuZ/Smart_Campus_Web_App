using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Smart_Campus_Web_App.Models;
using Azure.Identity;
using Smart_Campus_Web_App.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Smart_Campus_Web_App.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, user.PasswordHash);
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Authentication auth)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(auth.Email, auth.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Chat", "Chat");
                }
            }
            return View(auth);

        }*/

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            //var hashedPassword = HashPassword(model.PasswordHash);
            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash),
                UserType = model.UserType
            };

            _context.UserTbl.Add(newUser);
            await _context.SaveChangesAsync();

            return View(model);

        }

        [HttpPost]

        public async Task<IActionResult> Login(User z)
        {


            //if (ModelState.IsValid)
            //{
            try
            {
                var user = await _context.UserTbl.SingleOrDefaultAsync(u => u.Email == z.Email);

                HttpContext.Session.SetString("Username", user.Username);

                if (user != null && BCrypt.Net.BCrypt.Verify(z.PasswordHash, user.PasswordHash))
                {
                    user.IsOnline = true;
                    _context.SaveChanges();
                    // Password is correct, log the user in
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            catch (Exception) { }


            //}

            return View(z);
        }

        
        public async Task<IActionResult> Logout(User model)
        {
            var t = HttpContext.Session.GetString("Username");
            var user = await _context.UserTbl.SingleOrDefaultAsync(u => u.Username == t);

            user.IsOnline = false;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Login", "Auth");


        }
        /*public string HashPassword(string password)
        {
            // Implement password hashing here (e.g., using ASP.NET Identity or your custom logic)
            return 
        }*/

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public void SaveHist()
        {
            var res = Request.Form.ToDictionary();

            //var hashedPassword = HashPassword(model.PasswordHash);
            var newHist = new MsgHist
            {
                Username = res["Username"],
                Msg = res["Msg"],
            };

            //Console.WriteLine(newHist.Msg);

            _context.ChatHist.Add(newHist);
            _context.SaveChangesAsync();

            //SaveHist1(newHist);

        }

        
    }
}
