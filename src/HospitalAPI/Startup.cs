using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.SharedModel;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.HospitalMap.Repository;
using HospitalLibrary.HospitalMap.Service;
using HospitalLibrary.Settings;
using MailKit;
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
using HospitalLibrary.Registration.Repository;
using HospitalLibrary.Registration.Service;
using HospitalAPI.Registration.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Feedbacks.Service;
using HospitalLibrary.Core.Repository.HospitalLibrary.Core.Repository;

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


            services.AddTransient<IEmailSender, RegisterMailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HospitalDb")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IGenericMapper<Room, RoomDTO>, RoomMapper>();

            services.AddScoped<IRoomMapRepository, RoomMapRepository>();
            services.AddScoped<IRoomMapService, RoomMapService>();

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IGenericMapper<Patient, PatientDTO>, PatientMapper>();
            services.AddScoped<IGenericMapper<User,PatientDTO>, UserPatientMapper>();

            services.AddScoped<IAllergenService, AllergenService>();
            services.AddScoped<IAllergenRepository, AllergenRepository>();
            services.AddScoped<IGenericMapper<Allergen, AllergenDTO>, AllergenMapper>();

            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
            services.AddScoped<IGenericMapper<Specialization, SpecializationDTO>, SpecializationMapper>();
            
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IGenericMapper<MedicalRecord, PatientDTO>, MedicalRecordMapper>();
            
            services.AddScoped<IGenericMapper<Appointment, AppointmentDTO>, AppointmentMapper>();
            services.AddScoped<IGenericMapper<Bed, BedDTO>, BedMapper>();
            services.AddScoped<IGenericMapper<InpatientTreatment, InpatientTreatmentDTO>, InpatientTreatmentMapper>();
            services.AddScoped<IGenericMapper<Medicine, MedicineDTO>, MedicineMapper>();
            services.AddScoped<IGenericMapper<MedicineTherapy, MedicineTherapyDTO>, MedicineTherapyMapper>();
            services.AddScoped<IGenericMapper<BloodTherapy, BloodTherapyDTO>, BloodTherapyMapper>();
            services.AddScoped<IGenericMapper<InpatientTreatmentTherapy, InpatientTreatmentTherapyDTO>, InpatientTreatmentTherapyMapper>();

            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();

            services.AddScoped<ISpecializationRepository, SpecializationRepository>();

            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            services.AddScoped<IBloodRequestService, BloodRequestService>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddScoped<IGenericMapper<BloodRequest, BloodRequestDTO>, BloodRequestMapper>();

            services.AddScoped<IVacationRequestService, VacationRequestService>();
            services.AddScoped<IVacationRequestRepository, VacationRequestRepository>();
            services.AddScoped<IGenericMapper<VacationRequest, VacationRequestDTO>, VacationRequestMapper>();

            services.AddScoped<IConsiliumService, ConsiliumService>();
            services.AddScoped<IConsiliumRepository, ConsiliumRepository>();
            services.AddScoped<IGenericMapper<Consilium, ConsiliumDTO>, ConsiliumMapper>();


            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IGenericMapper<Doctor, DoctorDTO>, DoctorMapper>();

            services.AddScoped<IBloodService, BloodService>();
            services.AddScoped<IBloodRepository, BloodRepository>();
            services.AddScoped<IGenericMapper<Blood, BloodDTO>, BloodMapper>();

            services.AddScoped<IBloodUsageEvidencyService, BloodUsageEvidencyService>();
            services.AddScoped<IBloodUsageEvidencyRepository, BloodUsageEvidencyRepository>();
            services.AddScoped<IGenericMapper<BloodUsageEvidency, BloodUsageEvidencyDTO>, BloodUsageEvidencyMapper>();

            services.AddScoped<IInpatientTreatmentService, InpatientTreatmentService>();
            services.AddScoped<IInpatientTreatmentRepository, InpatientTreatmentRepository>();

            services.AddScoped<IInpatientTreatmentTherapyService, InpatientTreatmentTherapyService>();
            services.AddScoped<IInpatientTreatmentTherapyRepository, InpatientTreatmentTherapyRepository>();

            services.AddScoped<IBedRepository, BedRepository>();
            services.AddScoped<IBedService, BedService>();

            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineService, MedicineService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenericMapper<User, UserDTO>, UserMapper>();

            services.AddScoped<IPhysicianScheduleRepository, PhysicianScheduleRepository>();
            services.AddScoped<IPhysicianScheduleService, PhysicianScheduleService>();

            services.AddScoped<ISymptomRepository, SymptomRepository>();
            services.AddScoped<ISymptomService, SymptomService>();
            services.AddScoped<IGenericMapper<Symptom, SymptomDTO>, SymptomMapper>();

            services.AddScoped<IGenericMapper<Recipe, RecipeDTO>, RecipeMapper>();

            services.AddScoped<IExaminationReportRepository, ExaminationReportRepository>();
            services.AddScoped<IExaminationReportService, ExaminationReportService>();
            services.AddScoped<IGenericMapper<ExaminationReport, ExaminationReportDTO>, ExaminationReportMapper>();


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
