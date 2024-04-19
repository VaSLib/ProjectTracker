
using Microsoft.EntityFrameworkCore;
using DataAccess.DataBase;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Services;
using DataAccess.Entities;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IEmployeesService, EmployeeService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IAdminService,AdminService>();


builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer("Server=.; DataBase=ProjectTrackerOne ; Trusted_Connection=true;Encrypt=Optional"))
    .AddIdentity<EmployeeEntity,ApplicationRole>(config =>
    {
        config.Password.RequireDigit = false;
        config.Password.RequireLowercase = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireUppercase = false;
        config.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Administrator");
    });

    options.AddPolicy("ProjectManager", builder =>
    {
        builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager")
                                      || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
    });
    options.AddPolicy("Employee", builder =>
    {
        builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager")
                                      || x.User.HasClaim(ClaimTypes.Role, "Administrator")
                                      || x.User.HasClaim(ClaimTypes.Role, "Employee"));
    });

});





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
