
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Class> Classes  { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Discontinuity> Discontinuities { get; set; }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Navigation(s => s.Class).AutoInclude();
        modelBuilder.Entity<Teacher>().Navigation(t => t.Lesson).AutoInclude();
        modelBuilder.Entity<Discontinuity>().Navigation(d => d.Student).AutoInclude();
        modelBuilder.Entity<Exam>().Navigation(e => e.Student).AutoInclude();
        modelBuilder.Entity<Exam>().Navigation(e => e.Lesson).AutoInclude();
    }
}
