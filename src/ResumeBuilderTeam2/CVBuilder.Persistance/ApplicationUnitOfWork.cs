using CVBuilder.Application;
using CVBuilder.Application.features.ResumeInterfaces;
using CVBuilder.Persistence.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Persistence
{
    public class ApplicationUnitOfWork:UnitOfWork,IApplicationUnitOfWork
    {
        public IResumeRepository Resumes { get; private set; }
        public IResumeTemplateRepository ResumeTemplates { get; private set; }

        public ICoverLetterRepository CoverLetters { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IResumeRepository ResumesRepository, 
            IResumeTemplateRepository resumeTemplateRepository,
            ICoverLetterRepository coverLetters) : base((DbContext)dbContext)
        {
            Resumes = ResumesRepository;
            ResumeTemplates = resumeTemplateRepository;
            CoverLetters = coverLetters;
        }
    }
}
