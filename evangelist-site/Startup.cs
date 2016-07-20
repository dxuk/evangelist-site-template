using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MartinKRC2.Data;
using MartinKRC2.Models;
using MartinKRC2.Services;

namespace MartinKRC2
{
    public class PersonaliseOptions
    {
        public string Webroot { get; set; }
        public string BlogFeed { get; set; }
        public string BlogUrl { get; set; }
        public string Title { get; set; }

        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string FirstName { get; set; }
        
        public string ShortDescription { get; set; }
        public string Technologies { get; set; }
        public string Location { get; set; }
        public string Twitter { get; set; }

        public string TwitterHome { get; set; }
        public string LinkedInHome { get; set; }
        public string SkypeHome { get; set; }
        public string GithubHome { get; set; }
        public string StackOverflowHome { get; set; }
        public string EmailAddress { get; set; }
        public Bio Bio { get; set; }
    }
    public class Bio
    {
        public string FirstPerson { get; set; }
        public string ThirdPerson { get; set; }
        public string Short { get; set; }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<PersonaliseOptions>(
                options => Configuration.GetSection("Personalise").Bind(options));

            // Add framework services.
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BetaConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = r => r.Context.Response.Headers.Add("Expires", DateTime.Now.AddDays(7).ToUniversalTime().ToString("r"))
            });

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    "admin",
                    "admin",
                    new { controller = "ResourceGroups", action = "Index" });

                routes.MapRoute(
                    "talk",
                    "speaking/{talk}",
                    new { controller = "Speaking", action = "Talk" });

                routes.MapRoute(
                    "linkgroup",
                    "links/{linkgroup}",
                    new { controller = "Links", action = "LinkGroup" });

                routes.MapRoute(
                    "redirect",
                    "{tagLabel}",
                    new { controller = "Redirect", action = "Index" });
            });
        }
    }
}
