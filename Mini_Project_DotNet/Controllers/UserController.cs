using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Services;
using System.Security.Claims;

namespace Mini_Project_DotNet.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;
        private readonly IProductService proService;
        private readonly IRolesService rolesService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public UserController(IRolesService rolesService, Microsoft.AspNetCore.Hosting.IHostingEnvironment _env,IUserService service, IProductService proService)
        {
            this.rolesService=rolesService;
            this.service = service;
            this.proService = proService;
            this._env = _env;
        }
        // GET: UserController
        public ActionResult UserList()
        {
            var uList = service.GetUserList();
            return View(uList);
        }

        //// GET: UserController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: UserController/Create
        public IActionResult Register()
        {
                return View();
        }

        public ActionResult UserProductPage()
        {    
            var model = proService.GetAllProducts();
            return View(model);
        }
        //// POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string name,string email,int password,int confirmPassword)
        {
            Users user = new Users
            {
                 Name= name,
                 Email=email,
                 Password = password,
                 RoleId = 0
            };

            var result = service.AddUser(user);
            
            if(result>=1)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Username already exists or another error occured";
            return View();


        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Users users)
        {

            //if (ModelState.IsValid)
            //{
            var loggedInUser = service.GetUser(users.Email, users.Password);
            if (loggedInUser != null)
                {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loggedInUser.Name),
            new Claim(ClaimTypes.Email, loggedInUser.Email),
            new Claim("UserId", loggedInUser.UserId.ToString()),
            new Claim(ClaimTypes.Role, loggedInUser.RoleId == 1 ? "Admin" : "Customer")
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                if (loggedInUser.RoleId==1)
                    {
                        return RedirectToAction("AdminPage");
                    }
                    else
                    {
                        return RedirectToAction("UserProductPage");
                    }
                }

                ViewBag.Error = "Invalid username or password";
            //}
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
        [HttpGet("admin")]
        public IActionResult AdminPage()
        {
            return View();
        }

        [HttpGet("user")]
        public IActionResult UserPage()
        {
            return View();
        }

        private SelectList GetRoleList()
        {
            var roles = rolesService.GetRoles();
            return new SelectList(roles, "RoleId", "Role");
        }
        // get: usercontroller/edit/5
        public ActionResult UpdateUser(int id)
        {
            ViewBag.Roles = GetRoleList();
            var model = service.GetUserById(id);
            return View(model);
        }

        // post: usercontroller/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(Users users)
        {
            ViewBag.Roles = GetRoleList();
            try
            {
                int result = service.UpdateUser(users);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(UserList));
                }
                else
                {
                    ViewBag.Error="Something Went Wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error=ex.Message;
                return View();
            }
        }

        // get: usercontroller/delete/5
        public ActionResult Remove(int id)
        {
            var model = service.GetUserById(id);
            return View(model);
        }

        // post: usercontroller/delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id, IFormCollection collection)
        {
            try
            {
                int result = service.DeleteUser(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(UserList));
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
