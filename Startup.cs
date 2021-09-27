using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using pmdi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pmdi.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using pmdi.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using pmdi.Authorization;

namespace pmdi
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
            var sqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(sqlConnectionStr, ServerVersion.AutoDetect(sqlConnectionStr)));
            
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddIdentity<WebAppUser, WebAppRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<WebAppUser>>(TokenOptions.DefaultProvider);

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddRazorPages();
            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // Authorization handlers.
            services.AddScoped<IAuthorizationHandler,
                                  PatientsUserAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                  PatientsAdministratorsAuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            CreateRoles(serviceProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<WebAppRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<WebAppUser>>();
            List<string> roleNames = new List<string>();
            //= { "Admin", "Patient", "Doctor" };
            roleNames.Add(Constants.AdministratorsRole);
            roleNames.Add(Constants.PatientRole);
            roleNames.Add(Constants.DoctorRole);

            foreach (var roleName in roleNames)
            {
                var roleExist = RoleManager.RoleExistsAsync(roleName);
                roleExist.Wait();
                if (!roleExist.Result)
                {
                    //create the roles and seed them to the database: Question 1
                    var roleResult = RoleManager.CreateAsync(new WebAppRole(roleName));
                    roleResult.Wait();
                }
            }

            //Here you could create a super user who will maintain the web app
            var poweruser = new WebAppUser
            {
                FirstName = "Alexandr",
                LastName = "Maievsky",
                DOB = DateTime.Now,
                UserName = Configuration["AppSettings:AdminUserName"],
                Email = Configuration["AppSettings:AdminUserEmail"],
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = "iq&AKee3Mm5]vF4t";
            var _user = UserManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]);
            _user.Wait();

            if (_user.Result == null)
            {
                var createPowerUser = UserManager.CreateAsync(poweruser, userPWD);
                createPowerUser.Wait();
                if (createPowerUser.Result.Succeeded)
                {
                    //here we tie the new user to the role
                    var um = UserManager.AddToRoleAsync(poweruser, "Admin");
                    um.Wait();
                }
            }
        }
    }
}
