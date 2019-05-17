using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MonPlanning.Models;

namespace MonPlanning
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
            ContexteDonnees contexte = new ContexteDonnees();

            Employee genevieve = new Employee(1, "Genevieve", "Wrist");
            Employee lu = new Employee(2, "Lu", "Barreau");
            Employee janelle = new Employee(3, "Janelle", "Monae");
            Employee drake = new Employee(4, "Aubrey Drake", "Graham");

            contexte.AddEmployee(genevieve);
            contexte.AddEmployee(lu);
            contexte.AddEmployee(janelle);
            contexte.AddEmployee(drake);

            Calendar janvier = new Calendar(1, "Janvier", 31);
            Calendar fevrier = new Calendar(2, "Février", 28);
            Calendar mars = new Calendar(3, "Mars", 31);
            Calendar avril = new Calendar(4, "Avril", 30);
            Calendar mai = new Calendar(5, "Mai", 31);
            Calendar juin = new Calendar(6, "Juin", 30);
            Calendar juillet = new Calendar(7, "Juillet", 31);
            Calendar aout = new Calendar(8, "Août", 31);
            Calendar septembre = new Calendar(9, "Septembre", 30);
            Calendar octobre = new Calendar(10, "Octobre", 31);
            Calendar novembre = new Calendar(11, "Novembre", 30);
            Calendar decembre = new Calendar(12, "Décembre", 31);

            contexte.AddMonth(janvier);
            contexte.AddMonth(fevrier);
            contexte.AddMonth(mars);
            contexte.AddMonth(avril);
            contexte.AddMonth(mai);
            contexte.AddMonth(juin);
            contexte.AddMonth(juillet);
            contexte.AddMonth(aout);
            contexte.AddMonth(septembre);
            contexte.AddMonth(octobre);
            contexte.AddMonth(novembre);
            contexte.AddMonth(decembre);

            DaysOption normal = new DaysOption(" ", "normal");
            DaysOption absent = new DaysOption("Absent(e)", "absent");
            DaysOption conge = new DaysOption("Congé", "conge");
            DaysOption deplacement = new DaysOption("Déplacement", "deplacement");
            DaysOption ferie = new DaysOption("Férié", "ferie");
            DaysOption formation = new DaysOption("Formation", "formation");
            DaysOption homeOffice = new DaysOption("Télétravail", "homeOffice");
            DaysOption malade = new DaysOption("Malade", "malade");
            DaysOption reunion = new DaysOption("Réunion", "reunion");
            DaysOption rdv = new DaysOption("Rendez-vous", "rdv");
            DaysOption weekend = new DaysOption("Week-end", "weekend");

            contexte.AddOption(normal);
            contexte.AddOption(absent);
            contexte.AddOption(conge);
            contexte.AddOption(deplacement);
            contexte.AddOption(ferie);
            contexte.AddOption(formation);
            contexte.AddOption(homeOffice);
            contexte.AddOption(malade);
            contexte.AddOption(reunion);
            contexte.AddOption(rdv);
            contexte.AddOption(weekend);

            Year dixNeuf = new Year(2019);
            Year vingt = new Year(2020);

            contexte.AddYear(dixNeuf);
            contexte.AddYear(vingt);

            services.AddSingleton(contexte);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
