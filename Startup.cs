using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ARBDashboard.Repository;
using ARBDashboard.Services;
using Newtonsoft.Json.Serialization;
using ARBDashboard.Models;

namespace ARBDashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DBSettings>(Configuration.GetSection("DBSettings"));

            //services.AddDbContext<ARBDashboard.Models.ARB_DevelopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ARBDashboard.Models.ARB_DevelopContext>(options => options.UseSqlServer(Configuration.GetSection("DBSettings:ConnectionString").ToString()));


            services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddCors();

            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<ILoginProvider, DomainUserLoginProvider>();
            services.AddTransient<ILoginRepository, LoginRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseCors(options => options.WithOrigins("http://172.17.0.2").AllowAnyMethod());
            app.UseCors(options => options.WithOrigins("http://172.17.0.3").AllowAnyMethod());
            app.UseCors(options => options.WithOrigins("http://172.17.0.4").AllowAnyMethod());
            app.UseCors(options => options.WithOrigins("http://172.24.3.70").AllowAnyMethod());
            app.UseCors(options => options.WithOrigins("http://172.24.3.70:8080").AllowAnyMethod());

        }
    }
}
