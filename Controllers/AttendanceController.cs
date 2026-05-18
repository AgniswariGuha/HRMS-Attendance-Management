using HRMS_MVC.Data;
using HRMS_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_MVC.Controllers;

public class AttendanceController : Controller
{
    private readonly ApplicationDbContext _context;

    public AttendanceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToAction("Login", "Auth");

        var attendance = _context.Attendances
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.AttendanceDate)
            .ToList();

        return View("EmployeeDashboard", attendance);
    }

    [HttpPost]
    public IActionResult CheckIn()
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToAction("Login", "Auth");

        var todayAttendance = _context.Attendances
            .FirstOrDefault(x =>
                x.UserId == userId &&
                x.AttendanceDate == DateTime.Today);

        // Prevent multiple check-ins
        if (todayAttendance != null)
        {
            TempData["Error"] = "You have already checked in today.";
            return RedirectToAction("Index");
        }

        var attendance = new Attendance
        {
            UserId = userId.Value,
            AttendanceDate = DateTime.Today,
            CheckInTime = DateTime.Now,
            Status = "Pending",
            WorkingHours = 0
        };

        _context.Attendances.Add(attendance);
        _context.SaveChanges();

        TempData["Success"] = "Checked in successfully.";

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult CheckOut()
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToAction("Login", "Auth");

        var attendance = _context.Attendances
            .FirstOrDefault(x =>
                x.UserId == userId &&
                x.AttendanceDate == DateTime.Today);

        // No check-in found
        if (attendance == null)
        {
            TempData["Error"] = "Please check in first.";
            return RedirectToAction("Index");
        }

        // Prevent multiple check-outs
        if (attendance.CheckOutTime != null)
        {
            TempData["Error"] = "You have already checked out today.";
            return RedirectToAction("Index");
        }
        

        attendance.CheckOutTime = DateTime.Now;

        var totalHours = (
            attendance.CheckOutTime.Value -
            attendance.CheckInTime.Value
        ).TotalHours;

        attendance.WorkingHours = Math.Round((decimal)totalHours, 2);

      // Attendance + Leave Calculation Logic

        if (totalHours >= 8)
        {
            attendance.Status = "Present";
            attendance.LeaveDeduction = 0;
        }
        else if (totalHours >= 4)
        {
            attendance.Status = "Half Day";
            attendance.LeaveDeduction = 0.5m;
        }
        else
        {
            attendance.Status = "Absent";
            attendance.LeaveDeduction = 1;
        }
        _context.SaveChanges();
        TempData["Success"] = "Checked out successfully.";

        return RedirectToAction("Index");
    }
}