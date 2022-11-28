using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BankNews> BankNews { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public DbSet<EquipmentTender> EquipmentTenders { get; set; }


        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Email = "email1@gmail.com", AppName = "app1", Password = "OLIfDWaYYunpFtiQ", Server = "localhost:5555" },
                new User() { Id = 2, Email = "email2@gmail.com", AppName = "app2", Password = "UzX1V1A0FfLerVn5", Server = "localhost:6555" },
                new User() { Id = 3, Email = "email3@gmail.com", AppName = "app3", Password = "dd13xfCA5Jz9Y9ho", Server = "localhost:7555" }
            );
            modelBuilder.Entity<BankNews>().HasData(
                new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1", State = NewsState.NEW },
                new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2", State = NewsState.DECLINED },
                new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3", State = NewsState.APPROVED },
                new BankNews() { Id = 4, Title = "vijest 4", Content = "sadrzaj vijesti 4", State = NewsState.NEW },
                new BankNews() { Id = 5, Title = "vijest 5", Content = "sadrzaj vijesti 5", State = NewsState.DECLINED },
                new BankNews() { Id = 6, Title = "vijest 6", Content = "sadrzaj vijesti 6", State = NewsState.NEW },
                new BankNews() { Id = 7, Title = "vijest 7", Content = "sadrzaj vijesti 7", State = NewsState.NEW },
                new BankNews() { Id = 8, Title = "vijest 8", Content = "sadrzaj vijesti 8", State = NewsState.NEW },
                new BankNews() { Id = 9, Title = "vijest 9", Content = "sadrzaj vijesti 9", State = NewsState.APPROVED }
            );
            modelBuilder.Entity<BloodRequest>().HasData(
                new BloodRequest() { Id = 1, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 1", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.NEW },
                new BloodRequest() { Id = 2, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 2", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.APPROVED },
                new BloodRequest() { Id = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 3", FinalDate = new System.DateTime(), DoctorId = 2, State = BloodRequestState.DECLINED },
                new BloodRequest() { Id = 4, BloodType = BloodType.O_MINUS, QuantityInLiters = 12, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3, State = BloodRequestState.UPDATE, ReasonForAdjustment = "Ne moze" },
                new BloodRequest() { Id = 5, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 5", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.NEW },
                new BloodRequest() { Id = 6, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 6", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.APPROVED },
                new BloodRequest() { Id = 7, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 7", FinalDate = new System.DateTime(), DoctorId = 2, State = BloodRequestState.DECLINED },
                new BloodRequest() { Id = 8, BloodType = BloodType.O_MINUS, QuantityInLiters = 12, ReasonForRequest = "treba 8", FinalDate = new System.DateTime(), DoctorId = 3, State = BloodRequestState.UPDATE, ReasonForAdjustment = "Ne moze 2" }
            );
            modelBuilder.Entity<ReportConfiguration>().HasIndex(r => r.BloodBankId).IsUnique();
            modelBuilder.Entity<ReportConfiguration>().HasData(
                new ReportConfiguration()
                {
                    Id = 1, 
                    ReportFrequency = "* * * * *", 
                    ReportPeriod = 3,
                    BloodBankId = 2
                }
            );

            modelBuilder.Entity<EquipmentTender>().Property(e => e.Requirements).HasConversion(
                r => JsonSerializer.Serialize(r, null),
                r => JsonSerializer.Deserialize<List<TenderRequirement>>(r, null),
                    new ValueComparer<List<int>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, r) => HashCode.Combine(a, r.GetHashCode())),
                        c => c.ToList()));
            modelBuilder.Entity<EquipmentTender>().HasData(
                new EquipmentTender(1, "Tender 1"),
                new EquipmentTender(2, "Tender 2"),
                new EquipmentTender(3, "Tender 3")
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
