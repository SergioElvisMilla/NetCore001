using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore001.Data;
using NetCore001.Models;
using NetCore001.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Facebook;
//using NetCore001.Data;
//using NetCore001.Models;
//using NetCore001.Services;





namespace NetCore001
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Facebook
            /* services.AddAuthentication().AddFacebook(FacebookOptions =>
             {
                 FacebookOptions.AppId = Configuration["555562898235338"];
                 FacebookOptions.AppSecret = Configuration["03a49a80ed0d5e8aba6045139c3831a8"];

             });*/
            services.AddAuthentication().AddFacebook(Options =>
            {
                Options.AppId = Configuration["Authentication:Facebook:AppId"];
                Options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];

            });


            services.AddAuthentication().AddGoogle(Options =>
            {
                Options.ClientId = Configuration["AuthenticationG:Google:ClientId"];
                Options.ClientSecret = Configuration["AuthenticationG:Google:ClientSecret"];

            });



            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            //app.UseApplicationInsightsRequestTelemetry();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();

               // builder.AddUserSecrets();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseFacebookAuthentication(new FacebookOptions()
            //{
            //    AppId = "1919901744970558"
        
            //});


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            // await CreateRoles(serviceProvider);
            //CreateRoles(serviceProvider).Wait();

        }
        //private async Task CreateRoles(IServiceProvider serviceProvider)
        //{
        //    var roleMagar = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var userMagar = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    string[] rolesNames = { "Admin", "User" };
        //    IdentityResult result;
        //    foreach (var rolesName in rolesNames)
        //    {
        //        var roleExist = await roleMagar.RoleExistsAsync(rolesName);
        //        if (!roleExist)
        //        {
        //            result = await roleMagar.CreateAsync(new IdentityRole(rolesName));

        //        }
        //    }
        //    var user = await userMagar.FindByIdAsync("d5decff2-30f9-45dc-a0cd-8716fac92121");
        //    await userMagar.AddToRoleAsync(user, "Admin");

        //}



    }
}
