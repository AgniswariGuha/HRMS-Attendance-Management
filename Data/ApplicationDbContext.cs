using HRMS_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_MVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Attendance> Attendances { get; set; }
}