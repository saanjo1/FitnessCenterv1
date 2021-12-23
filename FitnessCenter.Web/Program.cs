using FitnessCenter.Data;
using FitnessCenter.Web.Services;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Main");

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddFlashMessage();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<SelectLists>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();