using Microsoft.EntityFrameworkCore;
using ZarzadzanieFirmaTransportowa;
using ZarzadzanieFirmaTransportowa.Context;
using ZarzadzanieFirmaTransportowa.Services.AssignementCar;
using ZarzadzanieFirmaTransportowa.Services.Cars;
using ZarzadzanieFirmaTransportowa.Services.Trailer;
using ZarzadzanieFirmaTransportowa.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CarContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITrailerService, TrailerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAssignmentCarService, AssignmentCarService>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
