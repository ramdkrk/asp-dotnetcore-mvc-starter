using ASP_MVC.Configurations;
using ASP_MVC.Filters;
using ASP_MVC.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog using appsettings
builder.ConfigureSerilog();

// Bind strongly-typed configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add MVC with filters and FluentValidation
builder.Services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<GlobalExceptionFilter>();
        options.Filters.Add<RequestLoggingActionFilter>();
        options.Filters.Add<RequireHttpsPermanentFilter>();
        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });

// FluentValidation: auto server/client validation + scan validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Project DI registrations (repositories, services, filters)
builder.Services.AddProjectDependencies();

// Memory cache baseline
builder.Services.AddMemoryCache();

// Auth (cookie) baseline
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Security headers
app.UseMiddleware<SecurityHeadersMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
