using HRMS_MVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_MVC.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.TotalEmployees =
            _context.Users.Count(x => x.Role == "Employee");

        ViewBag.Present =
            _context.Attendances.Count(x => x.Status == "Present");

        ViewBag.HalfDay =
            _context.Attendances.Count(x => x.Status == "Half Day");

        ViewBag.Absent =
            _context.Attendances.Count(x => x.Status == "Absent");

        return View();
    }
}