using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CNCDataManager.Data;
using CNCDataManager.Models;
using CNCDataManager.Services;
using CNCDataManager.Models.APIs;
using CNCDataManager.Controllers.Internals;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Buffers;

namespace CNCDataManager
{
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
            // 1.数据库服务
            services.AddDbContext<CNCMachineData>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("CNCMachineData")));
            services.AddDbContext<ApplicationUserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CNCUserData")));

            // 2.登陆认证服务
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationUserContext>()
                .AddDefaultTokenProviders();

            // 3.自定义的验证规则
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(AuthorizationLevel.Tourist),
                    policy => policy.RequireRole("Tourist", "Member", "AdvancedMember", "ResourceOwner", "Adminstrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.Member),
                    policy => policy.RequireRole("Member", "AdvancedMember", "ResourceOwner", "Adminstrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.AdvancedMember),
                    policy => policy.RequireRole("AdvancedMember", "ResourceOwner", "Adminstrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.ResourceOwner),
                    policy => policy.RequireRole("ResourceOwner", "Adminstrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.Adminstrator),
                    policy => policy.RequireRole("Adminstrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.Root),
                    policy => policy.RequireRole("Root"));
            });

            // 4.MVC核心服务
            services.AddMvc();

            // 5.配置JSON序列化时使用Pascal风格
            services.AddMvcCore().AddJsonFormatters(options =>
            {
                var resolver = options.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;
                }
            });

            // 6.配置Cors
            services.AddCors(options => options.AddPolicy("FullOpen", policy =>
            {
                policy.AllowAnyHeader()
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
                      .AllowCredentials();
            }));

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
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseCors("FullOpen");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "api/cncdata/{controller}/{id?}");
            });
        }
    }
}
