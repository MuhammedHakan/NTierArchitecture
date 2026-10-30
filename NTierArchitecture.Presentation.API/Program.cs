using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using NTierArchitecture.Business.Services;
using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Built-in OpenAPI document (Development ortaminda /openapi/v1.json)
builder.Services.AddOpenApi();

// Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NTierArchitecture API",
        Version = "v1",
        Description = "Ogrenci, ogretmen, ders, sinif, sinav ve devamsizlik yonetimi icin REST API."
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString(
                            "DefaultConnection")));
builder.Services.AddScoped<ClassRepostory>();
builder.Services.AddScoped<ClassServices>();
builder.Services.AddScoped<StudentRepostory>();
builder.Services.AddScoped<StudentServices>();
builder.Services.AddScoped<LessonRepostory>();
builder.Services.AddScoped<LessonServices>();
builder.Services.AddScoped<TeacherRepostory>();
builder.Services.AddScoped<TeacherServices>();
builder.Services.AddScoped<DiscontinuityRepostory>();
builder.Services.AddScoped<DiscontinuityServices>();
builder.Services.AddScoped<ExamRepostory>();
builder.Services.AddScoped<ExamServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "NTierArchitecture API v1");
    options.DocumentTitle = "NTierArchitecture API";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
