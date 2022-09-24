using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(_configuration.GetConnectionString("default"));
            });

			services.AddIdentity<AppUser, IdentityRole>(opt =>
			{
				opt.User.RequireUniqueEmail = true;
                //opt.SignIn.RequireConfirmedEmail = true;
                opt.User.AllowedUserNameCharacters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890_";

				opt.Password.RequiredUniqueChars = 3; // en azi 1 tekrar olunmayin herif olmalidir
				opt.Password.RequireDigit = true;
				opt.Password.RequiredLength = 8;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireLowercase = false;

				opt.Lockout.MaxFailedAccessAttempts = 3;
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				opt.Lockout.AllowedForNewUsers = true;
			}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

			services.AddScoped<LayoutService>();

			services.AddHttpContextAccessor();

			services.AddControllers().AddNewtonsoftJson(options =>
		    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

			app.UseEndpoints(endpoints =>
            {
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
				);

				endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=home}/{action=index}/{id?}"
                 );
            });
        }
    }
}
