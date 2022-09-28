using FriendsTown.Data;
using FriendsTown.Data.Repositories;
using FriendsTown.Transversal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace FriendsTown
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string connection = Configuration.GetConnectionString("FriendsTown");
            var options = new DbContextOptionsBuilder<FriendsTownContext>()
                .UseSqlServer(Configuration.GetConnectionString("FriendsTown")).Options;

            FriendsTownContext contexto = new FriendsTownContext(options);
            contexto.Database.EnsureCreated();

            // Options below is to use for MySQL Database Connection Setup

            //var options = new DbContextOptionsBuilder<FriendsTownContext>()
            //    .UseMySql(connection, ServerVersion.AutoDetect(connection))
            //    .Options;
            //FriendsTownContext contexto = new FriendsTownContext(options);
            //contexto.Database.EnsureCreated();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddDbContext<FriendsTownContext>(options =>
                options.UseSqlServer("name=connectionStrings:FriendsTown"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
