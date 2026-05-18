using HRMS_MVC.Data;
using HRMS_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_MVC.Controllers;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users
            .FirstOrDefault(x =>
                x.Email == email &&
                x.Password == password);

        if (user == null)
        {
            ViewBag.Error = "Invalid email or password.";
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Role", user.Role);
        HttpContext.Session.SetString("UserName", user.Name);

        TempData["Success"] = "Login successful.";

        if (user.Role == "HR")
            return RedirectToAction("Index", "HR");

        return RedirectToAction("Index", "Attendance");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(
        string name,
        string email,
        string password,
        string role)
    {
        var existingUser = _context.Users
            .FirstOrDefault(x => x.Email == email);

        if (existingUser != null)
        {
            ViewBag.Error = "Email already exists.";
            return View();
        }

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password,
            Role = role
        };

        _context.Users.Add(user);

        _context.SaveChanges();

        TempData["Success"] = "Registration successful.";

        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        TempData["Success"] = "Logged out successfully.";

        return RedirectToAction("Login");
    }
}