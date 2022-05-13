using DAL_DnD.Context;
using DnD_Between.Models;
using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Between.Controllers
{
    public class UserController : Controller
    {
        User_Container container = new User_Container(new User_Context());
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Character");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel _user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User(_user.Id, _user.Username, _user.Password);
                    User validatedUser = container.attemptLogin(user);
                    if (validatedUser.Username != null)
                    {
                        HttpContext.Session.SetString("ID", validatedUser.Id.ToString());
                        HttpContext.Session.SetString("Username", validatedUser.Username.ToString());
                        return RedirectToAction("Index", "Character");
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel _user)
        {
            if (ModelState.IsValid)
            {
                User user = new User(_user.Id, _user.Username, _user.Password);
                bool register = container.register(user);
                if (register != null)
                {
                    TempData["data"] = register;
                }
                else
                {
                    TempData["data"] = null;

                    return RedirectToAction("Index", "Character");
                }
            }
            return View();
        }
    }
}
