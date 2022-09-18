using Demo.Core.Business.Abstract;
using Demo.Core.Business.Concrete;
using Demo.Core.DAL.Abstract;
using Demo.Core.DAL.Concrete;
using Demo.Core.MvcUI.Middlewares;
using Demo.Core.MvcUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Core.MvcUI
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

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICartSessionServices, CartSessionService>();
            services.AddScoped<ICartService, CartManager>();

            services.AddDbContext<NorthwindContext>(
                option => option.UseSqlServer("Server=S102EGT\\SQLEXPRESS;Database=Northwind; User Id=sa; Password =1;"));

            //
            services.AddIdentity<IdentityUser, IdentityRole>(

                opt =>
                {
                    opt.Password.RequireDigit = true;//Say�sal de�er olmal�d�r �ifre
                    opt.Password.RequiredLength = 6;//min 6 karakter olmal�d�r 
                    opt.Password.RequireNonAlphanumeric = false;//a z ye metin olmas�na gerek yoktur.
                    opt.Password.RequireUppercase = false;// buyuk harf zorunlulugu yok 
                    opt.Password.RequireLowercase = false;//kucuk harf zorunlugu yok. 
                }


                ).AddEntityFrameworkStores<NorthwindContext>() // entity yani db bildirim yapt�k
                .AddDefaultTokenProviders(); // varsay�lan token yani giri� i�in jeton kulland�k...

            services.AddMvc(); // mvc kullanacag�m�z bildirdik
            services.AddSession(); // sepet i�in session kullanacag�z
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseAuthentication();
            app.UseSession();
            

            app.UseMvc(ConfiguretionRoutes);
        }
        public void ConfiguretionRoutes(IRouteBuilder routeBuilder)
        {
            //Y�nlendirme Alan�
            routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
            //id alan� opsiyoneldirr
        }
      
    }
}
