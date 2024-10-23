//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To use To Find Comfort and peace
//=================================================
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Project.Api.Brokers;
using Project.Api.Brokers.Storages;

namespace Project.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
               Configuration = configuration;

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title="Project.Api",
                Version="v1"
            };
            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            services.AddTransient<IStorageBroker, StorageBroker>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: apiInfo);
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Project.Api v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            endpoints.MapControllers());
        }
    }
}