using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medipro_patient_service.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthCareProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCareProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Occupation = table.Column<string>(type: "text", nullable: false),
                    LifeStyle = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LivingSituation = table.Column<string>(type: "text", nullable: false),
                    SocialSupport = table.Column<string>(type: "text", nullable: false),
                    MentalHealthCondition = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastMedicalHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastMedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastMedicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Allergen = table.Column<string>(type: "text", nullable: false),
                    Reaction = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    Relative = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyConditions_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Immunizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineName = table.Column<string>(type: "text", nullable: false),
                    DateAdministered = table.Column<DateOnly>(type: "date", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immunizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Immunizations_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Dosage = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalHistoryId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medications_MedicalHistories_MedicalHistoryId1",
                        column: x => x.MedicalHistoryId1,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medications_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresentIllnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OnsetDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    Intensity = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AlleviatingFactor = table.Column<string>(type: "text", nullable: false),
                    ExacerbationFactors = table.Column<string>(type: "text", nullable: false),
                    AssociatedSymptoms = table.Column<string>(type: "text", nullable: false),
                    PreviousEpisode = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentIllnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentIllnesses_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewOfSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    General = table.Column<string>(type: "text", nullable: false),
                    Neurological = table.Column<string>(type: "text", nullable: false),
                    Cardiovascular = table.Column<string>(type: "text", nullable: false),
                    Respiratory = table.Column<string>(type: "text", nullable: false),
                    GastroIntestinal = table.Column<string>(type: "text", nullable: false),
                    Musculskeletal = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewOfSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewOfSystems_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SexualHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SexuallyActive = table.Column<bool>(type: "boolean", nullable: false),
                    ContraceptionMethod = table.Column<string>(type: "text", nullable: false),
                    NumberOfPartners = table.Column<int>(type: "integer", nullable: false),
                    HistoryOfSTIs = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SexualHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SexualHistories_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceUses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Smokes = table.Column<bool>(type: "boolean", nullable: false),
                    CigPerDay = table.Column<int>(type: "integer", nullable: false),
                    ConsumesAlcohol = table.Column<bool>(type: "boolean", nullable: false),
                    AlcoholConsuption = table.Column<string>(type: "text", nullable: false),
                    UseRecreationalDrugs = table.Column<bool>(type: "boolean", nullable: false),
                    DrugType = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceUses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubstanceUses_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineName = table.Column<string>(type: "text", nullable: false),
                    DateAdministered = table.Column<DateOnly>(type: "date", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    BatchNumber = table.Column<string>(type: "text", nullable: false),
                    MedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChronicConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DiagonoseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    PastMedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChronicConditions_PastMedicalHistories_PastMedicalHistoryId",
                        column: x => x.PastMedicalHistoryId,
                        principalTable: "PastMedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OnsetDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ResolutionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: false),
                    PastMedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Illnesses_PastMedicalHistories_PastMedicalHistoryId",
                        column: x => x.PastMedicalHistoryId,
                        principalTable: "PastMedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Injuries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Treatment = table.Column<string>(type: "text", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: false),
                    PastMedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injuries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injuries_PastMedicalHistories_PastMedicalHistoryId",
                        column: x => x.PastMedicalHistoryId,
                        principalTable: "PastMedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Procedure = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Hospital = table.Column<string>(type: "text", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: false),
                    PastMedicalHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surgeries_PastMedicalHistories_PastMedicalHistoryId",
                        column: x => x.PastMedicalHistoryId,
                        principalTable: "PastMedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_MedicalHistoryId",
                table: "Allergies",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicConditions_PastMedicalHistoryId",
                table: "ChronicConditions",
                column: "PastMedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PatientId",
                table: "Contacts",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyConditions_MedicalHistoryId",
                table: "FamilyConditions",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Illnesses_PastMedicalHistoryId",
                table: "Illnesses",
                column: "PastMedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Immunizations_MedicalHistoryId",
                table: "Immunizations",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Injuries_PastMedicalHistoryId",
                table: "Injuries",
                column: "PastMedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicalHistoryId",
                table: "Medications",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicalHistoryId1",
                table: "Medications",
                column: "MedicalHistoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PatientId",
                table: "Medications",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PastMedicalHistories_PatientId",
                table: "PastMedicalHistories",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresentIllnesses_MedicalHistoryId",
                table: "PresentIllnesses",
                column: "MedicalHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewOfSystems_MedicalHistoryId",
                table: "ReviewOfSystems",
                column: "MedicalHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MedicalHistoryId",
                table: "Screenings",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SexualHistories_MedicalHistoryId",
                table: "SexualHistories",
                column: "MedicalHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubstanceUses_MedicalHistoryId",
                table: "SubstanceUses",
                column: "MedicalHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PastMedicalHistoryId",
                table: "Surgeries",
                column: "PastMedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_MedicalHistoryId",
                table: "Vaccinations",
                column: "MedicalHistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "ChronicConditions");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "FamilyConditions");

            migrationBuilder.DropTable(
                name: "HealthCareProviders");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Immunizations");

            migrationBuilder.DropTable(
                name: "Injuries");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "PresentIllnesses");

            migrationBuilder.DropTable(
                name: "ReviewOfSystems");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "SexualHistories");

            migrationBuilder.DropTable(
                name: "SubstanceUses");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "PastMedicalHistories");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
