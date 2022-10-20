﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HospitalLibrary.Core.Model.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTime = new DateTime(2022, 10, 20, 15, 58, 32, 932, DateTimeKind.Local).AddTicks(2376),
                            DoctorId = 1,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 2,
                            DateTime = new DateTime(2022, 10, 20, 15, 58, 32, 942, DateTimeKind.Local).AddTicks(7288),
                            DoctorId = 2,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 3,
                            DateTime = new DateTime(2022, 10, 20, 15, 58, 32, 942, DateTimeKind.Local).AddTicks(7345),
                            DoctorId = 3,
                            PatientId = 3
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ognjen",
                            RoomId = 1,
                            SpecializationId = 3,
                            Surname = "Nikolic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mika",
                            RoomId = 2,
                            SpecializationId = 3,
                            Surname = "Mikic"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aleksa",
                            RoomId = 1,
                            SpecializationId = 3,
                            Surname = "Santic"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pera",
                            Surname = "Peric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Marko",
                            Surname = "Markovic"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aleksa",
                            Surname = "Aleksic"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Floor = 1,
                            Number = "101A"
                        },
                        new
                        {
                            Id = 2,
                            Floor = 2,
                            Number = "204"
                        },
                        new
                        {
                            Id = 3,
                            Floor = 3,
                            Number = "305B"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Anesthesiology"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dermatology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Family medicine"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Appointment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.Core.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Doctor", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Room", "Room")
                        .WithMany("Doctors")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.Core.Model.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Room", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
