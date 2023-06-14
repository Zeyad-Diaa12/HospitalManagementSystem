using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hospital.Utilites;
using Hospital.Repositories.Interfaces;
using Hospital.Repositories.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IDbSeeder , DbSeeder>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IClinic, ClinicService>();
builder.Services.AddTransient<IDoctor, DoctorService>();
builder.Services.AddTransient<IAppointment, AppointmentService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

using(var scope = app.Services.CreateScope())
{
    var dbInit = scope.ServiceProvider.GetRequiredService<IDbSeeder>();

    dbInit.Initialize();
}

app.Run();
