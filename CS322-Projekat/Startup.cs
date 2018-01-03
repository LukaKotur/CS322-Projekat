using CS322_Projekat.AppIdentity;
using CS322_Projekat.Services.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjekatData;
using ProjekatServisi;


namespace CS322_Projekat
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
            #region Identity/Security

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Konekcija")));

            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Security.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });

            services.AddTransient<IEmailSender, EmailSender>();

            #endregion

            services.AddMvc();

            #region Data

            services.AddSingleton(Configuration);
            services.AddScoped<IVideoKlubAsset, VideoKlubAssetService>();
            services.AddScoped<IIznajmljivanje, IznajmljivanjeService>();
            services.AddScoped<IClan, ClanService>();


            services.AddDbContext<DataContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("Konekcija")));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
        }
    }
}