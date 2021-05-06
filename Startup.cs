using BPPR_Demo.Database;
using BPPR_Demo.Helpers;
using BPPR_Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BPPR_Demo
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
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options
            //        .WithOrigins("http://localhost:4200")
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});

            services.AddControllers();

            services.AddSingleton(new AppSetting { BPPRDemoConnectionString = Configuration["BPPRDemoConnectionString"] });

            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddSingleton<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.WithOrigins("http://localhost:4200")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IDatabaseConfiguration>().Setup();
        }
    }
}
