﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CVBuilder.web.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailSendStatus = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeTemplteId = table.Column<int>(type: "int", nullable: false),
                    ResumeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateThumbNailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCoverLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HiringBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Footer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoverLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduationYear = table.Column<int>(type: "int", nullable: true),
                    CGPA = table.Column<double>(type: "float", nullable: true),
                    MajorField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_ResumeData_ResumeDataId",
                        column: x => x.ResumeDataId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntroductionSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroductionSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntroductionSections_ResumeData_ResumeDataId",
                        column: x => x.ResumeDataId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageFrameworkSkillsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageFrameworkSkillsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageFrameworkSkillsSections_ResumeData_ResumeDataId",
                        column: x => x.ResumeDataId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalSummarySections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSummarySections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalSummarySections_ResumeData_CVTemplateId",
                        column: x => x.CVTemplateId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalTrainingSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalTrainingSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalTrainingSections_ResumeData_ResumeDataId",
                        column: x => x.ResumeDataId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsSections_ResumeData_ResumeDataId",
                        column: x => x.ResumeDataId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_ResumeData_ResumeDataId",
                        column: x => x.ResumeDataId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_ResumeData_CVTemplateId",
                        column: x => x.CVTemplateId,
                        principalTable: "ResumeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkOrText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    introductionSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_IntroductionSections_introductionSectionId",
                        column: x => x.introductionSectionId,
                        principalTable: "IntroductionSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillsSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillListItems_LanguageFrameworkSkillsSections_SkillsSectionId",
                        column: x => x.SkillsSectionId,
                        principalTable: "LanguageFrameworkSkillsSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingListItems_ProfessionalTrainingSections_TrainingSectionId",
                        column: x => x.TrainingSectionId,
                        principalTable: "ProfessionalTrainingSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechStack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectsSections_ProjectsSectionId",
                        column: x => x.ProjectsSectionId,
                        principalTable: "ProjectsSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperienceDescriptionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperiencId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperienceDescriptionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperienceDescriptionItems_WorkExperiences_WorkExperiencId",
                        column: x => x.WorkExperiencId,
                        principalTable: "WorkExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreateDate", "ModifyDate" },
                values: new object[,]
                {
                    { 1, "Admin", "Add User", new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4559), new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4567) },
                    { 2, "Admin", "Edit User", new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4572), new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4574) },
                    { 3, "Admin", "Delete User", new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4578), new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4579) },
                    { 4, "Admin", "Get User", new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4582), new DateTime(2023, 10, 27, 15, 57, 3, 126, DateTimeKind.Utc).AddTicks(4584) }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("abcd000c-5fb1-47b7-addf-f0c73faebabc"), null, "Admin", "ADMIN" },
                    { new Guid("c81d000c-5fb1-47b7-addf-f0c73faebebc"), null, "Super Admin", "SUPER ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MailSendStatus", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "Token", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a41d000c-5fb1-47b7-addf-f0c73faebeea"), 0, null, "ad102286-a410-48e0-8fcd-073c1b973a78", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Jhon", "Deo", false, null, true, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAECzWHdMekbnkrHzvome0wL4z9X2aArsIYj5xsjNy0rtYfmeXE9osTPTpIJFKwCPk/g==", null, false, null, "00000000-0000-0000-0000-000000000000", null, false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Admin", "Add User", new Guid("a41d000c-5fb1-47b7-addf-f0c73faebeea") },
                    { 2, "Admin", "Edit User", new Guid("a41d000c-5fb1-47b7-addf-f0c73faebeea") },
                    { 3, "Admin", "Delete User", new Guid("a41d000c-5fb1-47b7-addf-f0c73faebeea") },
                    { 4, "Admin", "Get User", new Guid("a41d000c-5fb1-47b7-addf-f0c73faebeea") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c81d000c-5fb1-47b7-addf-f0c73faebebc"), new Guid("a41d000c-5fb1-47b7-addf-f0c73faebeea") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeDataId",
                table: "Educations",
                column: "ResumeDataId");

            migrationBuilder.CreateIndex(
                name: "IX_IntroductionSections_ResumeDataId",
                table: "IntroductionSections",
                column: "ResumeDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageFrameworkSkillsSections_ResumeDataId",
                table: "LanguageFrameworkSkillsSections",
                column: "ResumeDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSummarySections_CVTemplateId",
                table: "ProfessionalSummarySections",
                column: "CVTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalTrainingSections_ResumeDataId",
                table: "ProfessionalTrainingSections",
                column: "ResumeDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectsSectionId",
                table: "Projects",
                column: "ProjectsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsSections_ResumeDataId",
                table: "ProjectsSections",
                column: "ResumeDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_References_ResumeDataId",
                table: "References",
                column: "ResumeDataId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillListItems_SkillsSectionId",
                table: "SkillListItems",
                column: "SkillsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_introductionSectionId",
                table: "SocialMedia",
                column: "introductionSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingListItems_TrainingSectionId",
                table: "TrainingListItems",
                column: "TrainingSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperienceDescriptionItems_WorkExperiencId",
                table: "WorkExperienceDescriptionItems",
                column: "WorkExperiencId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_CVTemplateId",
                table: "WorkExperiences",
                column: "CVTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationClaim");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "ProfessionalSummarySections");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "ResumeTemplates");

            migrationBuilder.DropTable(
                name: "SkillListItems");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "TrainingListItems");

            migrationBuilder.DropTable(
                name: "UserCoverLetters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkExperienceDescriptionItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProjectsSections");

            migrationBuilder.DropTable(
                name: "LanguageFrameworkSkillsSections");

            migrationBuilder.DropTable(
                name: "IntroductionSections");

            migrationBuilder.DropTable(
                name: "ProfessionalTrainingSections");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "ResumeData");
        }
    }
}
