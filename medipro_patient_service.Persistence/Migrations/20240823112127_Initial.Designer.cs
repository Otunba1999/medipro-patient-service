﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using medipro_patient_service.Persistence.Context;

#nullable disable

namespace medipro_patient_service.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240823112127_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Allergy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Allergen")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reaction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.ChronicCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("DiagonoseDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PastMedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PastMedicalHistoryId");

                    b.ToTable("ChronicConditions");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.FamilyCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Relative")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("FamilyConditions");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.HealthCareProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("HealthCareProviders");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Illness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("OnsetDate")
                        .HasColumnType("date");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PastMedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("ResolutionDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PastMedicalHistoryId");

                    b.ToTable("Illnesses");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Immunization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DateAdministered")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("VaccineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Immunizations");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Injury", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PastMedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PastMedicalHistoryId");

                    b.ToTable("Injuries");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.MedicalHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LivingSituation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MentalHealthCondition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("SocialSupport")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Medication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MedicalHistoryId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.HasIndex("MedicalHistoryId1");

                    b.HasIndex("PatientId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.PastMedicalHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("PastMedicalHistories");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LifeStyle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.PresentIllness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AlleviatingFactor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AssociatedSymptoms")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExacerbationFactors")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Intensity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("OnsetDate")
                        .HasColumnType("date");

                    b.Property<string>("PreviousEpisode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId")
                        .IsUnique();

                    b.ToTable("PresentIllnesses");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.ReviewOfSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cardiovascular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GastroIntestinal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("General")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Musculskeletal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Neurological")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Respiratory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId")
                        .IsUnique();

                    b.ToTable("ReviewOfSystems");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Screening", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.SexualHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContraceptionMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HistoryOfSTIs")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("NumberOfPartners")
                        .HasColumnType("integer");

                    b.Property<bool>("SexuallyActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId")
                        .IsUnique();

                    b.ToTable("SexualHistories");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.SubstanceUse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AlcoholConsuption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CigPerDay")
                        .HasColumnType("integer");

                    b.Property<bool>("ConsumesAlcohol")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DrugType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Smokes")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseRecreationalDrugs")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId")
                        .IsUnique();

                    b.ToTable("SubstanceUses");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Surgery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Hospital")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PastMedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Procedure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PastMedicalHistoryId");

                    b.ToTable("Surgeries");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Vaccination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateAdministered")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MedicalHistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("VaccineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Allergy", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("Allergies")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.ChronicCondition", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.PastMedicalHistory", "PastMedicalHistory")
                        .WithMany("ChronicConditions")
                        .HasForeignKey("PastMedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PastMedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Contact", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.Patient", "Patient")
                        .WithOne("Contact")
                        .HasForeignKey("medipro_patient_service.Domain.Models.Contact", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.FamilyCondition", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("FamilyConditions")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Illness", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.PastMedicalHistory", "PastMedicalHistory")
                        .WithMany("Illnesses")
                        .HasForeignKey("PastMedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PastMedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Immunization", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("Immunizations")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Injury", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.PastMedicalHistory", "PastMedicalHistory")
                        .WithMany("Injuries")
                        .HasForeignKey("PastMedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PastMedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.MedicalHistory", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.Patient", "Patient")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("medipro_patient_service.Domain.Models.MedicalHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Medication", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("CurentMedications")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", null)
                        .WithMany("PastMedications")
                        .HasForeignKey("MedicalHistoryId1");

                    b.HasOne("medipro_patient_service.Domain.Models.Patient", "Patient")
                        .WithMany("CurrentMedications")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.PastMedicalHistory", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.Patient", "Patient")
                        .WithOne("PastMedicalHistory")
                        .HasForeignKey("medipro_patient_service.Domain.Models.PastMedicalHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.PresentIllness", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithOne("PresentIllness")
                        .HasForeignKey("medipro_patient_service.Domain.Models.PresentIllness", "MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.ReviewOfSystem", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithOne("ReviewOfSystem")
                        .HasForeignKey("medipro_patient_service.Domain.Models.ReviewOfSystem", "MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Screening", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("Screenings")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.SexualHistory", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithOne("SexualHistory")
                        .HasForeignKey("medipro_patient_service.Domain.Models.SexualHistory", "MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.SubstanceUse", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithOne("SubstanceUse")
                        .HasForeignKey("medipro_patient_service.Domain.Models.SubstanceUse", "MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Surgery", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.PastMedicalHistory", "PastMedicalHistory")
                        .WithMany("Surgeries")
                        .HasForeignKey("PastMedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PastMedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Vaccination", b =>
                {
                    b.HasOne("medipro_patient_service.Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("Vaccinations")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.MedicalHistory", b =>
                {
                    b.Navigation("Allergies");

                    b.Navigation("CurentMedications");

                    b.Navigation("FamilyConditions");

                    b.Navigation("Immunizations");

                    b.Navigation("PastMedications");

                    b.Navigation("PresentIllness");

                    b.Navigation("ReviewOfSystem");

                    b.Navigation("Screenings");

                    b.Navigation("SexualHistory");

                    b.Navigation("SubstanceUse");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.PastMedicalHistory", b =>
                {
                    b.Navigation("ChronicConditions");

                    b.Navigation("Illnesses");

                    b.Navigation("Injuries");

                    b.Navigation("Surgeries");
                });

            modelBuilder.Entity("medipro_patient_service.Domain.Models.Patient", b =>
                {
                    b.Navigation("Contact");

                    b.Navigation("CurrentMedications");

                    b.Navigation("MedicalHistory");

                    b.Navigation("PastMedicalHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
