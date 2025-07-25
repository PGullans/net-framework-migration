using Microsoft.EntityFrameworkCore;

using Ok.Framework.Db;
using Ok.Framework.Db.Repository;
using Ok.Net.Web.Config;
using Ok.Net.Web.Services;

namespace Ok.Net.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        // Options
        builder.Services.Configure<OptionDb>(builder.Configuration.GetSection("Db"));


        // DB
        var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<OkFrameworkContext>(_ => _.UseSqlServer(dbConnection));


        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<ContactService>();
        builder.Services.AddScoped<AccountService>();
        builder.Services.AddScoped<OrderService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}