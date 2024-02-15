using ChalkBoardChat.Data.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChalkBoardChat.ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            var authConnectionString = builder.Configuration.GetConnectionString("AuthConnection");
            var connectionString = builder.Configuration.GetConnectionString("MessageConnection");

            builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(authConnectionString, b => b.MigrationsAssembly("ChalkBoardChat.Ui")));
            builder.Services.AddDbContext<MessageDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ChalkBoardChat.Ui")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
