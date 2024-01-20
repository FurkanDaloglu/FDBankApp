using FDBankApp.Data.Context;
using FDBankApp.Data.Interfaces;
using FDBankApp.Data.Repositories;
using FDBankApp.Data.UnitOfWork;
using FDBankApp.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IUow, Uow>();
//builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountMapper, AccountMapper>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BankContext>(opt =>
{
    opt.UseSqlServer("server=LAPTOP-7DCEO2K6\\SQLEXPRESS; database=BankDb; integrated security=true;");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
/*app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
    "node_modules")),
    RequestPath = "/node_modules"
});*/
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
