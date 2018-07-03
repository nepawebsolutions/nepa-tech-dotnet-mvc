using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEPATechDotnetCoreMVC.Data;
using Microsoft.EntityFrameworkCore;
using NEPATechDotnetCoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using NEPATechDotnetCoreMVC.Constants;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NEPATechDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NEPATechDbContext>()
                .AddDefaultTokenProviders();



            services.AddAuthorization();
            services.AddAuthentication();



            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 3;

                // User settings
                options.User.RequireUniqueEmail = true;
            });



            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateUserRoles(services).Wait();
        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;

            //Add roles to database if they do not exist.
            foreach (var role in RoleConstants.GetAllRoles())
            {
                var roleCheck = await RoleManager.RoleExistsAsync(role);
                if (!roleCheck)
                {
                    //create the roles and seed them to the database  
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }

            ApplicationUser user = await UserManager.FindByEmailAsync("lwilljohns@gmail.com");

            var User = new ApplicationUser();
            await UserManager.AddToRoleAsync(user, RoleConstants.Admin);
            await UserManager.AddToRoleAsync(user, RoleConstants.Webmaster);
        }
    }
}
