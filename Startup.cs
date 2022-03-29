using DAL.IRepos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReqSystem.DAL.IRepos;
using ReqSystem.DAL.Repos;
using ReqSystem.Data;
using ReqSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem
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
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepo<AcademicProgram>, AcademicProgramRepo>();
            services.AddScoped<IRepo<Address>, AddressRepo>();
            services.AddScoped<IRepo<Budget>, BudgetRepo>();
            services.AddScoped<IRepo<Comment>, CommentRepo>();
            services.AddScoped<IRepo<Department>, DepartmentRepo>();
            services.AddScoped<IRepo<Division>, DivisionRepo>();
            services.AddScoped<IRepo<Fee>, FeeRepo>();
            services.AddScoped<IRepo<FileAttachment>, FileAttachmentRepo>();
            services.AddScoped<IRepo<Item>, ItemRepo>();
            services.AddScoped<IRepo<Requisition>, RequisitionRepo>();
            services.AddScoped<IReqUserRepo<ReqUser>, ReqUserRepo>();
            services.AddScoped<IRepo<StateContract>, StateContractRepo>();
            services.AddScoped<IRepo<Vendor>, VendorRepo>();

            services.AddDefaultIdentity<ReqUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
        }
    }
}
