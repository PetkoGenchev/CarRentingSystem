namespace CarRentingSystem
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<CarRentingDbContext>(options => options
                .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            //services
            //  .AddDatabaseDeveloperPageExceptionFilter();

            //services
            //    .AddDefaultIdentity<User>(options =>
            //    {
            //        options.Password.RequireDigit = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireUppercase = false;
            //    })
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<CarRentingDbContext>();

            services
                .AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseAuthentication()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                    //endpoints.MapRazorPages();
                });

        }
    }
}
