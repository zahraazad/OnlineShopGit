using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlineShop.Logger.Interfaces;
using OnlineShop.GlobalErrorHandling.Extentions;
using Microsoft.Extensions.Options;
using OnlineShop.Facade.Resolver;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            AutoMapperProfile.config();
            var builder = new Autofac.ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new AutoFacResolver(Configuration.GetConnectionString("DefaultConnection")));
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigExceptionHandling(logger);


            //To fix the index.html not found issue, I needed to declare UseDefaultFiles() before UseStaticFiles().

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
