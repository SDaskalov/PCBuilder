namespace PCBuilder
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.ModelBinders;
    using static PCBuilder.Web.Infrastructure.Extensions.WebApplicationBuilderExtensions;
    using static PCBuilder.Common.GeneralConstants;

    //using PCBuilder.Data;
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<PCBuilderDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddScoped<IPCBuildService, PCBuildService>();
            builder.Services.AddScoped<IBuilderService, BuilderService>();
            builder.Services.AddScoped<ISocketCategoryService, SocketCategoryService>();
            builder.Services.AddScoped<IVendorCategoryService, VendorCategoriesService>();
            builder.Services.AddScoped<ICPUService, CPUService>();
            builder.Services.AddScoped<IGPUService, GPUService>();
            builder.Services.AddScoped<IMotherBoardService, MotherBoardService>();
            builder.Services.AddScoped<IComputerCaseService, ComputerCaseService>();
            builder.Services.AddScoped<IPCBuildService, PCBuildService>();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<PCBuilderDbContext>();
            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error/400");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            //ADMIN ROLE NEEDS CORRECT EMAIL
            //PLEASE LOGIN as Administrator@PCBuild.com and become a builder 
            //Password 123456789
            app.SeedAdministrator(AdminEmail);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                       name: "areas",
                       pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                     );


                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=All}/{id?}");

            endpoints.MapDefaultControllerRoute();
            endpoints.MapRazorPages();
            });


            app.Run();
        }
    }
}