
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Context;

public class AppDbContext : DbContext
{
    public DbSet<Class> Classes  { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Discontinuity> Discontinuities { get; set; }
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER02;Database=NTierArchitectureDb;Integrated Security=True;Trust Server Certificate=True;");
    }
}
