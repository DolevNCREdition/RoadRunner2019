using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RoadRunnerServer.Services;
using RoadRunnerServer.Shared.Interfaces;

namespace RoadRunnerServer
{
    public class Startup
    {
        readonly string CorsPolicy = "CORS_POLICY";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                });
            });
			
            services.AddLogging();
            services.AddMemoryCache();

            services.AddSingleton<IProductDataBase, ProductDataBase>();
            services.AddSingleton<ICustomerOrderDataBase, CustomerOrderDatabase>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ILineService, LineService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicy);

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
