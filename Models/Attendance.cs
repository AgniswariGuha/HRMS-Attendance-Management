namespace HRMS_MVC.Models;

public class Attendance
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime AttendanceDate { get; set; }

    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public decimal WorkingHours { get; set; } = 0;

    public string Status { get; set; } = "Pending";
    public decimal LeaveDeduction { get; set; } = 0;

    public User User { get; set; }
}