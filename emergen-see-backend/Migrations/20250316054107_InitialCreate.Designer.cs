﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using emergen_see_backend.Data;

#nullable disable

namespace emergen_see_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250316054107_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("emergen_see_backend.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Nurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AssignedDoctorId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QueueId")
                        .HasColumnType("int");

                    b.Property<int>("TriageFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedDoctorId");

                    b.HasIndex("QueueId");

                    b.HasIndex("TriageFormId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Queue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QueueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("emergen_see_backend.Models.TriageForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("NurseId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("NurseId");

                    b.ToTable("TriageForms");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Patient", b =>
                {
                    b.HasOne("emergen_see_backend.Models.Doctor", "AssignedDoctor")
                        .WithMany("Patients")
                        .HasForeignKey("AssignedDoctorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("emergen_see_backend.Models.Queue", "Queue")
                        .WithMany("Patients")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("emergen_see_backend.Models.TriageForm", "TriageForm")
                        .WithOne("Patient")
                        .HasForeignKey("emergen_see_backend.Models.Patient", "TriageFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedDoctor");

                    b.Navigation("Queue");

                    b.Navigation("TriageForm");
                });

            modelBuilder.Entity("emergen_see_backend.Models.TriageForm", b =>
                {
                    b.HasOne("emergen_see_backend.Models.Doctor", "Doctor")
                        .WithMany("TriageForms")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emergen_see_backend.Models.Nurse", "Nurse")
                        .WithMany("TriageForms")
                        .HasForeignKey("NurseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Nurse");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Doctor", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("TriageForms");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Nurse", b =>
                {
                    b.Navigation("TriageForms");
                });

            modelBuilder.Entity("emergen_see_backend.Models.Queue", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("emergen_see_backend.Models.TriageForm", b =>
                {
                    b.Navigation("Patient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
