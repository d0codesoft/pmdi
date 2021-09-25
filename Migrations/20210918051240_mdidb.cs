using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pmdi.Migrations
{
    public partial class mdidb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosisPatientsDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Document = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisPatientsDoc", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdUsers = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DOB = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PhotoPatient = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenceLabalatory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefDownloadResult = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Site = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceLabalatory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenseTypeMeasuring",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenseTypeMeasuring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenseTypeMeasuring_ReferenseTypeMeasuring_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ReferenseTypeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenсeDoctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenсeDoctors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsGroup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMark = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeAnalysis_TypeAnalysis_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TypeAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnitDosage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeDasage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDosage", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentsPatient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateUpload = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descr_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descr_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descr_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsOSR = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataDoc = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsPatient_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VitalSignsPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MeasurementDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BludPressureUpper = table.Column<uint>(type: "int unsigned", nullable: false),
                    BludPressureLower = table.Column<uint>(type: "int unsigned", nullable: false),
                    Pulse = table.Column<uint>(type: "int unsigned", nullable: false),
                    Temp = table.Column<decimal>(type: "decimal(5,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSignsPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VitalSignsPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenсeMeasuring",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeMeasuringID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenсeMeasuring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenсeMeasuring_ReferenseTypeMeasuring_TypeMeasuringID",
                        column: x => x.TypeMeasuringID,
                        principalTable: "ReferenseTypeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiagnosisPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InfoDiagnosis = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosisPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisPatients_ReferenсeDoctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "ReferenсeDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalTreatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateAppointment = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DoctorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    InfoTreatment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalTreatment_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalTreatment_ReferenсeDoctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "ReferenсeDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenceDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitDosageID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Dosage = table.Column<decimal>(type: "decimal(15,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceDrugs_UnitDosage_UnitDosageID",
                        column: x => x.UnitDosageID,
                        principalTable: "UnitDosage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistiryTackOCR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocPatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    DescrState_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescrState_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescrState_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistiryTackOCR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistiryTackOCR_DocumentsPatient_DocPatientId",
                        column: x => x.DocPatientId,
                        principalTable: "DocumentsPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TackOCR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocPatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsWork = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TackOCR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TackOCR_DocumentsPatient_DocPatientId",
                        column: x => x.DocPatientId,
                        principalTable: "DocumentsPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeasuringSynonym",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MeasuringId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LangSynonym = table.Column<int>(type: "int", nullable: false),
                    NameSynonym = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringSynonym", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuringSynonym_ReferenсeMeasuring_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "ReferenсeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenceUnitAnalyse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeUnitAnalyse = table.Column<int>(type: "int", nullable: false),
                    MeasuringDenominatorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MeasuringNumeratorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceUnitAnalyse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceUnitAnalyse_ReferenсeMeasuring_MeasuringDenominator~",
                        column: x => x.MeasuringDenominatorId,
                        principalTable: "ReferenсeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenceUnitAnalyse_ReferenсeMeasuring_MeasuringNumeratorId",
                        column: x => x.MeasuringNumeratorId,
                        principalTable: "ReferenсeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenseRelationshipMeasuring",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MeasuringFirstId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MeasuringSecondId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CofficientRelationship = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenseRelationshipMeasuring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenseRelationshipMeasuring_ReferenсeMeasuring_MeasuringF~",
                        column: x => x.MeasuringFirstId,
                        principalTable: "ReferenсeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenseRelationshipMeasuring_ReferenсeMeasuring_MeasuringS~",
                        column: x => x.MeasuringSecondId,
                        principalTable: "ReferenсeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrugsSynonym",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DrugsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LangSybonym = table.Column<int>(type: "int", nullable: false),
                    NameSynonym = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugsSynonym", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugsSynonym_ReferenceDrugs_DrugsId",
                        column: x => x.DrugsId,
                        principalTable: "ReferenceDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatientMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdUsers = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PeriodReseving = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    BeginReception = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndReception = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DrugsID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UnitDosageID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Dosage = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_ReferenceDrugs_DrugsID",
                        column: x => x.DrugsID,
                        principalTable: "ReferenceDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_UnitDosage_UnitDosageID",
                        column: x => x.UnitDosageID,
                        principalTable: "UnitDosage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferenceAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BaseUnitAnalyseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeAnalysisId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_en = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_ru = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_tr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceAnalysis_ReferenceUnitAnalyse_BaseUnitAnalyseId",
                        column: x => x.BaseUnitAnalyseId,
                        principalTable: "ReferenceUnitAnalyse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenceAnalysis_TypeAnalysis_TypeAnalysisId",
                        column: x => x.TypeAnalysisId,
                        principalTable: "TypeAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatientAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateAnalysis = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AnalysisId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValueAnalysis = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MeasuringId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LabalatoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAnalysis_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAnalysis_ReferenceAnalysis_AnalysisId",
                        column: x => x.AnalysisId,
                        principalTable: "ReferenceAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAnalysis_ReferenceLabalatory_LabalatoryId",
                        column: x => x.LabalatoryId,
                        principalTable: "ReferenceLabalatory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAnalysis_ReferenсeMeasuring_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "ReferenсeMeasuring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisPatients_DoctorId",
                table: "DiagnosisPatients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisPatients_PatientId",
                table: "DiagnosisPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsPatient_PatientId",
                table: "DocumentsPatient",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugsSynonym_DrugsId",
                table: "DrugsSynonym",
                column: "DrugsId");

            migrationBuilder.CreateIndex(
                name: "IX_HistiryTackOCR_DocPatientId",
                table: "HistiryTackOCR",
                column: "DocPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringSynonym_MeasuringId",
                table: "MeasuringSynonym",
                column: "MeasuringId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTreatment_DoctorId",
                table: "MedicalTreatment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTreatment_PatientId",
                table: "MedicalTreatment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAnalysis_AnalysisId",
                table: "PatientAnalysis",
                column: "AnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAnalysis_LabalatoryId",
                table: "PatientAnalysis",
                column: "LabalatoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAnalysis_MeasuringId",
                table: "PatientAnalysis",
                column: "MeasuringId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAnalysis_PatientId",
                table: "PatientAnalysis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_DrugsID",
                table: "PatientMedicine",
                column: "DrugsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_PatientId",
                table: "PatientMedicine",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_UnitDosageID",
                table: "PatientMedicine",
                column: "UnitDosageID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceAnalysis_BaseUnitAnalyseId",
                table: "ReferenceAnalysis",
                column: "BaseUnitAnalyseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceAnalysis_TypeAnalysisId",
                table: "ReferenceAnalysis",
                column: "TypeAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceDrugs_UnitDosageID",
                table: "ReferenceDrugs",
                column: "UnitDosageID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceUnitAnalyse_MeasuringDenominatorId",
                table: "ReferenceUnitAnalyse",
                column: "MeasuringDenominatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceUnitAnalyse_MeasuringNumeratorId",
                table: "ReferenceUnitAnalyse",
                column: "MeasuringNumeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenseRelationshipMeasuring_MeasuringFirstId",
                table: "ReferenseRelationshipMeasuring",
                column: "MeasuringFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenseRelationshipMeasuring_MeasuringSecondId",
                table: "ReferenseRelationshipMeasuring",
                column: "MeasuringSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenseTypeMeasuring_ParentId",
                table: "ReferenseTypeMeasuring",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenсeMeasuring_TypeMeasuringID",
                table: "ReferenсeMeasuring",
                column: "TypeMeasuringID");

            migrationBuilder.CreateIndex(
                name: "IX_TackOCR_DocPatientId",
                table: "TackOCR",
                column: "DocPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAnalysis_ParentId",
                table: "TypeAnalysis",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignsPatients_PatientId",
                table: "VitalSignsPatients",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosisPatients");

            migrationBuilder.DropTable(
                name: "DiagnosisPatientsDoc");

            migrationBuilder.DropTable(
                name: "DrugsSynonym");

            migrationBuilder.DropTable(
                name: "HistiryTackOCR");

            migrationBuilder.DropTable(
                name: "MeasuringSynonym");

            migrationBuilder.DropTable(
                name: "MedicalTreatment");

            migrationBuilder.DropTable(
                name: "PatientAnalysis");

            migrationBuilder.DropTable(
                name: "PatientMedicine");

            migrationBuilder.DropTable(
                name: "ReferenseRelationshipMeasuring");

            migrationBuilder.DropTable(
                name: "TackOCR");

            migrationBuilder.DropTable(
                name: "VitalSignsPatients");

            migrationBuilder.DropTable(
                name: "ReferenсeDoctors");

            migrationBuilder.DropTable(
                name: "ReferenceAnalysis");

            migrationBuilder.DropTable(
                name: "ReferenceLabalatory");

            migrationBuilder.DropTable(
                name: "ReferenceDrugs");

            migrationBuilder.DropTable(
                name: "DocumentsPatient");

            migrationBuilder.DropTable(
                name: "ReferenceUnitAnalyse");

            migrationBuilder.DropTable(
                name: "TypeAnalysis");

            migrationBuilder.DropTable(
                name: "UnitDosage");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ReferenсeMeasuring");

            migrationBuilder.DropTable(
                name: "ReferenseTypeMeasuring");
        }
    }
}
