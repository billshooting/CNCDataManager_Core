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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

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
                // 修改默认的密码规则，改简单一点
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                // 修改默认的重定向行为,让他直接返回401
                options.Cookies.ApplicationCookie.LoginPath = PathString.Empty;
                Func<CookieRedirectContext, Task> return401 = context =>
                {
                    if (context.Request.Path.Value.StartsWith("/api"))
                    {
                        context.Response.Clear();
                        context.Response.StatusCode = 401;
                        context.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                        context.Response.Headers["Access-Control-Allow-Origin"] = context.Request.Headers["Origin"];
                        return Task.FromResult(0);
                    }
                    context.Response.Redirect(context.RedirectUri);
                    return Task.FromResult(0);
                };
                options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = return401,
                    OnRedirectToAccessDenied = return401
                };

                // 不允许邮箱重复
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationUserContext>()
                .AddDefaultTokenProviders();

            // 3.自定义的验证规则
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(AuthorizationLevel.Tourist),
                    policy => policy.RequireRole("Tourist", "Member", "AdvancedMember", "ResourceOwner", "Administrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.Member),
                    policy => policy.RequireRole("Member", "AdvancedMember", "ResourceOwner", "Administrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.AdvancedMember),
                    policy => policy.RequireRole("AdvancedMember", "ResourceOwner", "Administrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.ResourceOwner),
                    policy => policy.RequireRole("ResourceOwner", "Administrator", "Root"));
                options.AddPolicy(nameof(AuthorizationLevel.Administrator),
                    policy => policy.RequireRole("Administrator", "Root"));
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
                      .SetPreflightMaxAge(TimeSpan.FromSeconds(1))
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

            app.UseCors("FullOpen");

            ////修改Cors头， 因为withCredentials特性不允许Access-Control-Allow-Origin = *
            //app.Use((context, next) =>
            //{
            //    context.Response.Headers["Access-Control-Allow-Origin"] = context.Request.Headers["Origin"];
            //    context.Response.Headers["Access-Control-Allow-Credentials"] = "true";
            //    return next();
            //});

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
