using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shoer.Business.Abstract;
using Shoer.Business.Concrete;
using Shoer.Data.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Data.Concrete.MsSQL;
using Shoer.Entity.Admin;
using Shoer.Entity.OrderDetails;

namespace Shoer
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
            services.AddControllersWithViews();
            services.AddScoped<IBrandRepository, SQLBrandRepository>();
            services.AddScoped<IBrandService, BrandManager>();

            services.AddScoped<IShoeRepository, SQLShoeRepository>();
            services.AddScoped<IShoeService, ShoeManager>();

            services.AddScoped<ICategoryRepository, SQLCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
            services.AddScoped<ICustomerService, CustomerManager>();

            services.AddScoped<IOrderRepository, SQLOrderRepository>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<IRepository<OrderDetails>, SQLOrderDetailsRepository>();
            services.AddScoped<IOrderDetailsService, OrderDetailsManager>();

            services.AddScoped<IRepository<Admin>, SQLAdminRepository>();
            services.AddScoped<IAdminService, AdminManager>();

            services.AddScoped<ICustomerContactRepository, SQLCustomerContactRepository>();
            services.AddScoped<ICustomerContactService, CustomerContactManager>();

            services.AddScoped<ICustomerAdressRepository, SQLCustomerAdressRepository>();
            services.AddScoped<ICustomerAdressService, CustomerAdressManager>();

            services.AddMvc();
            services.AddSession();
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
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
