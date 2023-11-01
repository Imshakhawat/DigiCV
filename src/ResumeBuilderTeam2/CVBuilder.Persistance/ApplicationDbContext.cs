using Crud.Persistance.Features.Membership;
using CVBuilder.Domain.CVEntites.BaseEntites;
using CVBuilder.Domain.CVEntites.Sections;
using CVBuilder.Domain.CVEntites;
using CVBuilder.Domain.Entities;
using CVBuilder.Persistence.Features.DataSeeding;
using CVBuilder.Persistence.Features.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Diagnostics;
using CVBuilder.Domain.CVEntites.BaseEntites.ItemLists;

namespace CVBuilder.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly));
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //create Claim
            builder.Entity<ApplicationClaim>().HasData(
                new ApplicationClaim() { Id = 1, ClaimType = "Admin", ClaimValue = "Add User", CreateDate = DateTime.UtcNow, ModifyDate = DateTime.UtcNow },
                new ApplicationClaim() { Id = 2, ClaimType = "Admin", ClaimValue = "Edit User", CreateDate = DateTime.UtcNow, ModifyDate = DateTime.UtcNow },
                new ApplicationClaim() { Id = 3, ClaimType = "Admin", ClaimValue = "Delete User", CreateDate = DateTime.UtcNow, ModifyDate = DateTime.UtcNow },
                new ApplicationClaim() { Id = 4, ClaimType = "Admin", ClaimValue = "Get User", CreateDate = DateTime.UtcNow, ModifyDate = DateTime.UtcNow }
            );
            //Create Role
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole() { Id = new Guid("C81D000C-5FB1-47B7-ADDF-F0C73FAEBEBC"), Name = "Super Admin", NormalizedName = "Super Admin".ToUpper(), },
                new ApplicationRole() { Id = new Guid("ABCD000C-5FB1-47B7-ADDF-F0C73FAEBABC"), Name = "Admin", NormalizedName = "Admin".ToUpper(), }
                );
            //Create User
            //builder.Entity<ApplicationUser>().HasData(AdminUserCreateSeed.Admins);
            var adminUser = new ApplicationUser()
            {
                Id = new Guid("A41D000C-5FB1-47B7-ADDF-F0C73FAEBEEA"),
                FirstName = "Jhon",
                LastName = "Deo",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                SecurityStamp = new Guid().ToString(),
                EmailConfirmed = true,
                MailSendStatus = true
            };
            adminUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(adminUser, "Abc123");
            builder.Entity<ApplicationUser>().HasData(adminUser);


            //Assign role in user
            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole() { RoleId = new Guid("C81D000C-5FB1-47B7-ADDF-F0C73FAEBEBC"), UserId = new Guid("A41D000C-5FB1-47B7-ADDF-F0C73FAEBEEA") }
                );
            //Assign Claim in user
            builder.Entity<ApplicationUserClaim>().HasData(
                new ApplicationUserClaim() { Id = 1, UserId = new Guid("A41D000C-5FB1-47B7-ADDF-F0C73FAEBEEA"), ClaimType = "Admin", ClaimValue = "Add User" },
                new ApplicationUserClaim() { Id = 2, UserId = new Guid("A41D000C-5FB1-47B7-ADDF-F0C73FAEBEEA"), ClaimType = "Admin", ClaimValue = "Edit User" },
                new ApplicationUserClaim() { Id = 3, UserId = new Guid("A41D000C-5FB1-47B7-ADDF-F0C73FAEBEEA"), ClaimType = "Admin", ClaimValue = "Delete User" },
                new ApplicationUserClaim() { Id = 4, UserId = new Guid("A41D000C-5FB1-47B7-ADDF-F0C73FAEBEEA"), ClaimType = "Admin", ClaimValue = "Get User" }
            );



            // One-to-Many relationship between ResumeData and user
            //builder.Entity<ResumeData>()
            //    .HasOne<User>(cv => cv.User)
            //    .WithMany(u => u.ResumeDatas)
            //    .HasForeignKey(cv => cv.UserId);//done

            #region Introduction
            // One-to-one relationship between ResumeData and IntroductionSection
            builder.Entity<Resume>()
                .HasOne<IntroductionSection>(cv => cv.Introduction)
                .WithOne(intro => intro.ResumeData)
                .HasForeignKey<IntroductionSection>(intro => intro.ResumeDataId);//done

            // One-to-man relationship between workExperience and workExperienceItemList
            builder.Entity<SocialMedia>()
                .HasOne<IntroductionSection>(item => item.introductionSection)
                .WithMany(intro => intro.SocialMediaList)
                .HasForeignKey(item => item.introductionSectionId);//done
            #endregion

            #region skills
            // One-to-one relationship between ResumeData and skills
            builder.Entity<Resume>()
                .HasOne(cv => cv.Skills)
                .WithOne(sk => sk.ResumeData)
                .HasForeignKey<LanguageFrameworkSkillsSection>(sk => sk.ResumeDataId);//done

            // One-to-man relationship between skills and skillsItemList
            builder.Entity<SkillListItems>()
                .HasOne<LanguageFrameworkSkillsSection>(sk => sk.SkillsSection)
                .WithMany(sc => sc.SkillsList)
                .HasForeignKey(sk => sk.SkillsSectionId);//done
            #endregion

            #region workExperience
            // One-to-man relationship between Cvtemplate and workExperience
            builder.Entity<Resume>()
            .HasMany(cv => cv.WorkExperiences)
            .WithOne(we => we.CVTemplate)
            .HasForeignKey(we => we.CVTemplateId);

            // One-to-man relationship between workExperience and workExperienceItemList
            builder.Entity<WorkExperienceDescriptionItems>()
                .HasOne<WorkExperience>(item => item.WorkExperience)
                .WithMany(we => we.DescriptionItems)
                .HasForeignKey(item => item.WorkExperiencId);//done
            #endregion

            #region projects
            // One-to-one relationship between ResumeData and ProjectsSection
            builder.Entity<Resume>()
                .HasOne(cv => cv.Projects)
                .WithOne(ps => ps.ResumeData)
                .HasForeignKey<ProjectsSection>(ps => ps.ResumeDataId);//done

            // One-to-man relationship between workExperience and workExperienceItemList
            builder.Entity<Project>()
                .HasOne<ProjectsSection>(item => item.ProjectsSection)
                .WithMany(ps => ps.ProjectItems)
                .HasForeignKey(item => item.ProjectsSectionId);//done
            #endregion

            #region Training
            // One-to-one relationship between ResumeData and ProjectsSection
            builder.Entity<Resume>()
                .HasOne(cv => cv.ProfessionalTraining)
                .WithOne(ps => ps.ResumeData)
                .HasForeignKey<ProfessionalTrainingSection>(ps => ps.ResumeDataId);//done

            // One-to-man relationship between workExperience and workExperienceItemList
            builder.Entity<TrainingListItems>()
                .HasOne<ProfessionalTrainingSection>(item => item.TrainingSection)
                .WithMany(pt => pt.TrainingItemList)
                .HasForeignKey(item => item.TrainingSectionId);//done
            #endregion


            // One-to-Many relationship between ResumeData and Education
            builder.Entity<Resume>()
                .HasMany(cv => cv.Education)
                .WithOne(edu => edu.ResumeData)
                .HasForeignKey(edu => edu.ResumeDataId);

            // One-to-Many relationship between ResumeData and Reference
            builder.Entity<Resume>()
                .HasMany(cv => cv.References)
                .WithOne(refs => refs.ResumeData)
                .HasForeignKey(refs => refs.ResumeDataId);


            base.OnModelCreating(builder);
        }

        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Resume> ResumeData { get; set; }
        public DbSet<Education> Educations { get; set; }
        //public DbSet<SkillListItems> SkillListItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<IntroductionSection> IntroductionSections { get; set; }
        public DbSet<LanguageFrameworkSkillsSection> LanguageFrameworkSkillsSections { get; set; }
        public DbSet<ProfessionalSummarySection> ProfessionalSummarySections { get; set; }
        public DbSet<ProfessionalTrainingSection> ProfessionalTrainingSections { get; set; }
        public DbSet<ProjectsSection> ProjectsSections { get; set; }
        public DbSet<ResumeTemplate> ResumeTemplates { get; set; }
        public DbSet<UserCoverLetter> UserCoverLetters { get; set; }

        //public DbSet<WorkExperienceDescriptionItems> WorkExperienceDescriptionItems { get; set; }
    }
}