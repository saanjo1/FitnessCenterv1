using FitnessCenter.Data;
using FitnessCenter.Web.Services;
using FitnessCenter.Web.Utilities.Constants;
using FitnessCenter.Web.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;
using FitnessCenter.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Main");

builder.Services.AddFlashMessage();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<SelectLists>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();
builder.Services.AddResponseCaching();
builder.Services.AddSignalR();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseResponseCaching();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapHub<MyHub>("/MyHub");
app.Run();