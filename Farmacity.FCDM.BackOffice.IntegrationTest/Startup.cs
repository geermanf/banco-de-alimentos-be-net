using Farmacity.FCDM.BackOffice.Configuration;
using Farmacity.FCDM.BackOffice.Constants;
using Farmacity.FCDM.BackOffice.Context;
using Farmacity.FCDM.BackOffice.Infrastructure;
using Farmacity.FCDM.BackOffice.Repositories;
using Farmacity.FCDM.BackOffice.Repositories.Implementation;
using Farmacity.FCDM.BackOffice.Services;
using Farmacity.FCDM.BackOffice.Services.Implementation;
using Farmacity.FCDM.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Farmacity.FCDM.BackOffice.Entities;

namespace Farmacity.FCDM.BackOffice.IntegrationTest
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<Startup>();

            var builder = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.Test.json", false, true);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddSpaStaticFiles(c =>
            {
                c.RootPath = "ClientApp/dist";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DB_FCDM_BackOfficeContext>(options => options.UseInMemoryDatabase(databaseName: "DB_FCDM_BackOffice"));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailTemplateService, EmailTemplateService>();
            services.AddTransient<ISynchronizationRepository, SynchronizationRepository>();
            services.AddTransient<ISynchronizationService, SynchronizationService>();
            services.AddTransient<IInternalUserRepository, IInternalUserRepository>();
            services.AddTransient<IInternalUserService, InternalUserService>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleService, RoleService >();
            services.AddTransient<IParametersServices, ParametersServices>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<TokenHelper, TokenHelper>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var configuration = _configuration.GetSection(ConfigurationSections.ApiInformation).Get<ApiInformation>();
            var security = _configuration.GetSection(ConfigurationSections.SecurityConfiguration).Get<SecurityConfiguration>();
            var tokenConfiguration = _configuration.GetSection(ConfigurationSections.TokenConfiguration).Get<TokenConfiguration>();



            services.AddSingleton<AppToken, AppToken>();
            services.AddScoped<FCDMClient, FCDMClient>();


        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime lifetime)
        {
            loggerFactory.AddNLog();


            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            var configuration = _configuration.GetSection(ConfigurationSections.ApiInformation).Get<ApiInformation>();

            var context = app.ApplicationServices.GetService<DB_FCDM_BackOfficeContext>();
            AddTestData(context);

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action=index}/{id}");
            });

            if (!env.IsDevelopment())
            {
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";
                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
            }
        }

        private void AddTestData(DB_FCDM_BackOfficeContext context)
        {
            User testUser1 = new User ()
            {
                Id = 1,
                FirstName = "Luke",
                LastName = "Skywalker",
                Dni = "29994329",
                Key = "sdasdasdasdasd",
                Email = "jmc@hotmail.com",
                Province= "CBA"
            };

            context.Users.Add(testUser1);
                      

            context.SaveChanges();
        }
    }
}