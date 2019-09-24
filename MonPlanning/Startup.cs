using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonPlanning.Domain.Handlers;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Infrastructure.Dal;
using System.Data;
using System.Data.SqlClient;

namespace MonPlanning
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string connectionStringDal = string.Format(Configuration.GetConnectionString("DefaultConnection"), Environment.ContentRootPath);
            IDbConnection dbConnection() => new SqlConnection(connectionStringDal);

            var monthsData = new MonthDal(dbConnection);
            services.AddSingleton<IMonthDal>(monthsData);
            services.AddSingleton<MonthHandler>();

            var employeesData = new EmployeeDal(dbConnection);
            services.AddSingleton<IEmployeeDal>(employeesData);
            services.AddSingleton<EmployeeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
