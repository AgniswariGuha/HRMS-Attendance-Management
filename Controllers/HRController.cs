using HRMS_MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_MVC.Controllers;

public class HRController : Controller
{
    private readonly ApplicationDbContext _context;

    public HRController(ApplicationDbContext context)
    {
        _context = context;
    }

   public IActionResult Index(
    int? employeeId,
    DateTime? attendanceDate)
{
    var query = _context.Attendances
        .Include(x => x.User)
        .AsQueryable();

    if (employeeId.HasValue)
    {
        query = query.Where(x =>
            x.UserId == employeeId);
    }

    if (attendanceDate.HasValue)
    {
        query = query.Where(x =>
            x.AttendanceDate.Date ==
            attendanceDate.Value.Date);
    }

    var attendanceList = query
        .OrderByDescending(x => x.AttendanceDate)
        .ToList();

    // Dashboard Counts

    ViewBag.TotalEmployees =
        _context.Users.Count(x => x.Role == "Employee");

    ViewBag.PresentCount =
        _context.Attendances.Count(x => x.Status == "Present");

    ViewBag.HalfDayCount =
        _context.Attendances.Count(x => x.Status == "Half Day");

    ViewBag.AbsentCount =
        _context.Attendances.Count(x => x.Status == "Absent");

    ViewBag.Users = _context.Users.ToList();

    return View("HRDashboard", attendanceList);
}
}