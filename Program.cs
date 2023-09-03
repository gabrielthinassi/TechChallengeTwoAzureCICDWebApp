using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechChallengeTwo.Data;
using TechChallengeTwo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var server = builder.Configuration["DbServer"] ?? "localhost";
//var port = builder.Configuration["DbPort"] ?? "1450";
// var user = builder.Configuration["DbUser"] ?? "SA";
// var password = builder.Configuration["DbPassword"] ?? "Gmtpostech#2023";
// var database = builder.Configuration["Database"] ?? "BlogDB";
// var datasource = builder.Configuration["DataSource"] ?? "techchallengetwodb";
// var connectionString = $"Data Source={datasource};Initial Catalog={database};User ID={user};Password={password}";
//var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
