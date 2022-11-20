using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.SharedModel;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System;
using HospitalLibrary.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI
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

            services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HospitalDb")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IGenericMapper<Patient, PatientDTO>, PatientMapper>();
            services.AddScoped<IGenericMapper<Appointment, AppointmentDTO>, AppointmentMapper>();

            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IVacationRepository, VacationRepository>();

            services.AddScoped<IWorkTimeService, WorkTimeService>();
            services.AddScoped<IWorkTimeRepository, WorkTimeRepository>();

            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();


            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            services.AddScoped<IBloodRequestService, BloodRequestService>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddScoped<IGenericMapper<BloodRequest, BloodRequestDTO>, BloodRequestMapper>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenericMapper<User, UserDTO>, UserMapper>();

            SetupAuth(services);
        }

        private static void SetupAuth(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("managerPolicy", policy => policy.RequireRole("manager"));
                options.AddPolicy("doctorPolicy", policy => policy.RequireRole("doctor"));
                options.AddPolicy("patientPolicy", policy => policy.RequireRole("patient"));
            });

            var key = "this is my custom Secret key for authentication";
            var issuer = "http://localhost:16177/";
            var audience = "http://localhost:4200/";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("AuthenticationTokens-Expired", "true");
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
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
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
