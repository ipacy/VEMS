using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using VEMS.Data;
using VEMS.Services.Extensions;

namespace VEMS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                   );

            services.AddDbContextConfiguration(Configuration);
            services.AddIdentityConfiguration();
            services.AddAuthenticationConfiguration(Configuration);
            services.AddAuthorizationConfiguration();
            services.AddEntityConfiguration();
            services.AddSwaggerConfiguration();
        }

        public void ApplyMigrations(ApplicationDbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           /* var serviceScope = app.ApplicationServices.CreateScope();
            this.ApplyMigrations(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());*/

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vistex API");
            });

            app.UseRouting();
            app.UseCors("APIPolicy");


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
