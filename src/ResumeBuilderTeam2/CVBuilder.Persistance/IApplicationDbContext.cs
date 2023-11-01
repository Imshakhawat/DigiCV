using CVBuilder.Domain.CVEntites;
using CVBuilder.Domain.CVEntites.BaseEntites;
using CVBuilder.Domain.CVEntites.BaseEntites.ItemLists;
using CVBuilder.Domain.CVEntites.Sections;
using CVBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Resume> ResumeData { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        //public DbSet<WorkExperienceDescriptionItems> WorkExperienceDescriptionItems { get; set; }
        public DbSet<IntroductionSection> IntroductionSections { get; set; }
        public DbSet<LanguageFrameworkSkillsSection> LanguageFrameworkSkillsSections { get; set; }
        public DbSet<ProfessionalSummarySection> ProfessionalSummarySections { get; set; }
        public DbSet<ProfessionalTrainingSection> ProfessionalTrainingSections { get; set; }
        public DbSet<ProjectsSection> ProjectsSections { get; set; }
        public DbSet<ResumeTemplate> ResumeTemplates { get; set; }
        public DbSet<UserCoverLetter> UserCoverLetters { get; set; }



    }
}
