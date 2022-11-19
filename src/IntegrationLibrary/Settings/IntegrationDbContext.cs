﻿using System;
using IntegrationLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Utility;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using Microsoft.EntityFrameworkCore;


namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BankNews> BankNews { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<ReportConfiguration> ReportConfigurations { get; set; }

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
                new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1", State = NewsStateEnum.UNCHECKED },
                new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2", State = NewsStateEnum.DISAPPROVED },
                new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3", State = NewsStateEnum.APPROVED },
                new BankNews() { Id = 4, Title = "vijest 4", Content = "sadrzaj vijesti 4", State = NewsStateEnum.UNCHECKED },
                new BankNews() { Id = 5, Title = "vijest 5", Content = "sadrzaj vijesti 5", State = NewsStateEnum.DISAPPROVED },
                new BankNews() { Id = 6, Title = "vijest 6", Content = "sadrzaj vijesti 6", State = NewsStateEnum.UNCHECKED },
                new BankNews() { Id = 7, Title = "vijest 7", Content = "sadrzaj vijesti 7", State = NewsStateEnum.UNCHECKED },
                new BankNews() { Id = 8, Title = "vijest 8", Content = "sadrzaj vijesti 8", State = NewsStateEnum.UNCHECKED },
                new BankNews() { Id = 9, Title = "vijest 9", Content = "sadrzaj vijesti 9", State = NewsStateEnum.APPROVED }
            );
            modelBuilder.Entity<BloodRequest>().HasData(
                new BloodRequest() { Id = 1, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 1", FinalDate = new System.DateTime(), DoctorId = 1 },
                new BloodRequest() { Id = 2, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 2", FinalDate = new System.DateTime(), DoctorId = 1 },
                new BloodRequest() { Id = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 3", FinalDate = new System.DateTime(), DoctorId = 2 }    
            );
            modelBuilder.Entity<ReportConfiguration>().HasData(
                new ReportConfiguration()
                {
                    Id = 1, 
                    ReportFrequency = 7, 
                    ReportRange = new DateRange(
                        new DateTime(2022, 11, 3, 0, 0, 0), 
                        new DateTime(2022, 11, 10, 0, 0, 0))
                },
                new ReportConfiguration() { 
                    Id = 2, 
                    ReportFrequency = 30, 
                    ReportRange = new DateRange(
                        new DateTime(2022, 10, 1, 0, 0, 0), 
                        new DateTime(2022, 11, 1, 0, 0, 0))
                },
                new ReportConfiguration() { 
                    Id = 3, 
                    ReportFrequency = 14, 
                    ReportRange = new DateRange(
                        new DateTime(2022, 10, 16, 0, 0, 0), 
                        new DateTime(2022, 11, 30, 0, 0, 0))
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
