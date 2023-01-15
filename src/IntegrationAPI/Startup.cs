using System;
using System.Net;
using System.Text;
using IntegrationLibrary.Features.Blood.Service;
using IntegrationLibrary.Features.BloodBank.Repository;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.BloodBankNews.Repository;
using IntegrationLibrary.Features.BloodBankNews.Service;
using IntegrationLibrary.Features.BloodBank;
using IntegrationLibrary.Features.BloodBankReports.Service;
using IntegrationLibrary.Features.BloodRequests.Repository;
using IntegrationLibrary.Features.BloodRequests.Service;
using IntegrationLibrary.Features.ReportConfigurations.Repository;
using IntegrationLibrary.Features.ReportConfigurations.Service;
using IntegrationLibrary.HospitalService;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Application;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure;
using IntegrationLibrary.Features.UrgentBloodOrder.Service;
using System.Net.Http;
using System.Net.Http.Headers;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Service;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Repository;
using IntegrationLibrary.Features.ManagerNotification.Service;
using IntegrationLibrary.Features.ManagerNotification.Repository;
using IntegrationLibrary.Features.UrgentBloodOrder.Repository;

namespace IntegrationAPI
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AuthorizationPolicy", policy => policy.RequireAssertion(async httpCtx =>
            //    {
            //        var httpClient = new HttpClient();
            //        var token = httpCtx.User.Identity;
            //        Console.WriteLine("tokencina", token?.Name);
            //        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //        var url = AppSettings.HospitalApiUrl + "/api/authorization/manager";
                    
            //        var response = await httpClient.GetAsync(url);
            //        return response.StatusCode == HttpStatusCode.OK;
            //    }));
            //});

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<RabbitMQSettings>(Configuration.GetSection("RabbitMQSettings"));
            services.Configure<RabbitMQBloodSettings>(Configuration.GetSection("RabbitMQBloodSettings"));
            services.Configure<RabbitMQNotificationSettings>(Configuration.GetSection("RabbitMQNotificationsSettings"));
            services.AddTransient<IBloodBankService, BloodBankService>();
            services.AddDbContext<IntegrationDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("IntegrationDb")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegrationAPI", Version = "v1" });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBloodService, BloodService>();
            services.AddScoped<IBankNewsService, BankNewsService>();
            services.AddScoped<IBankNewsRepository, BankNewsRepository>();
            services.AddHostedService<RabbitMQService>();
            services.AddHostedService<RabbitMQBloodService>();
            services.AddHostedService<RabbitMQNotificationService>();
            services.AddScoped<IBloodRequestService, BloodRequestService>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();

            services.AddScoped<IUrgentBloodOrderService, UrgentBloodOrderService>();
            services.AddScoped<IUrgentOrderRepository, UrgentOrderRepository>();

            services.AddScoped<IHospitalService, HospitalService>();

            services.AddScoped<IBBReportsService, BBReportsService>();
            services.AddScoped<IReportConfigurationService, ReportConfigurationService>();
            services.AddScoped<IReportConfigurationRepository, ReportConfigurationRepository>();

            services.AddScoped<IEquipmentTenderService, EquipmentTenderService>();
            services.AddScoped<IEquipmentTenderRepository, EquipmentTenderRepository>();

            services.AddScoped<IBloodSubscriptionService, BloodSubscriptionService>();
            services.AddScoped<IBloodSubscriptionRepository, BloodSubscriptionRepository>();

            services.AddScoped<IManagerNotificationService, ManagerNotificationService>();
            services.AddScoped<IManagerNotificationRepository, ManagerNotificationRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });


 

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntegrationAPI v1"));
            }

            app.UseExceptionHandler("/Error");

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
