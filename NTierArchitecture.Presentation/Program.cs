using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NTierArchitecture.Business.Services;
using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Presentation.Forms;

namespace NTierArchitecture.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory);
                config.AddJsonFile(
                    "appsettings.json",
                    optional: false,
                    reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString(
                            "DefaultConnection")));

                services.AddTransient<Main>();
                #region Services Registration
                services.AddScoped<ClassRepostory>();
                services.AddScoped<ClassServices>();
                services.AddScoped<StudentRepostory>();
                services.AddScoped<StudentServices>();
                services.AddScoped<LessonRepostory>();
                services.AddScoped<LessonServices>();
                services.AddScoped<TeacherRepostory>();
                services.AddScoped<TeacherServices>();
                services.AddScoped<DiscontinuityRepostory>();
                services.AddScoped<DiscontinuityServices>();
                services.AddScoped<ExamRepostory>();
                services.AddScoped<ExamServices>();
                services.AddTransient<ClassForm>();
                services.AddTransient<Student_form>();
                services.AddTransient<Lesson_form>();
                services.AddTransient<Teacher_form>();
                services.AddTransient<Discontinuity_form>();
                services.AddTransient<Exam_form>();
                #endregion
            })

            .Build();

            using (host)
            {
                var form = host.Services.GetRequiredService<Main>();
                Application.Run(form);
            }
        }
    }
}