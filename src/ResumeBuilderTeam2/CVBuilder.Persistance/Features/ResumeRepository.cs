using CVBuilder.Application.features.ResumeInterfaces;
using CVBuilder.Domain.CVEntites;
using CVBuilder.Domain.CVEntites.BaseEntites;
using CVBuilder.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Persistence.Features
{
    public class ResumeRepository : Repository<Resume, int>, IResumeRepository
    {
        protected IApplicationDbContext _dbContext; 
        protected DbSet<Resume> _dbSet;
        protected DbContext _db;
        protected int CommandTimeout { get; set; }
        public ResumeRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _db = context as DbContext;
            _dbContext = context;
            _dbSet = _dbContext.ResumeData;
        }

        public async Task<Resume> GetCVByUserId(Guid userId, int tempId)
        {
            var result   = await  _dbSet.Where(x => x.UserId == userId && x.ResumeTemplteId == tempId)
                .Include(x => x.Education)
                .Include(x => x.Projects).ThenInclude(x => x.ProjectItems)
                .Include(x => x.WorkExperiences)
                .ThenInclude(ww => ww.DescriptionItems)
                .Include(x => x.References) 
                .Include(x => x.Skills)
                .ThenInclude(x => x.SkillsList)
                .Include(x => x.Introduction)
                .Include(x => x.ProfessionalSummary)
                .Include(x => x.ProfessionalTraining) 
                .ThenInclude(x => x.TrainingItemList)
                .Include(x => x.Introduction.SocialMediaList)  
                .FirstOrDefaultAsync();

            if (result == null) return null;
 
            return result;
        }

        public  Task<bool> DeleteResumeData(Resume resumeData)
        {
            try
            {
                _dbContext.ResumeData.Remove(resumeData);
                _db.SaveChanges();
                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCVByUserIdAndTempId( Resume cVTemplate)
        {
           var result =  _dbSet.Update(cVTemplate);
            if (result == null) return false;
            return true;  
        }

		public async Task<IList<Resume>> GetAllResumeByUser(Guid userId)
		{
			 var getAllUserResume = await _dbContext.ResumeData.Where( x => x.UserId == userId).ToListAsync();

            return getAllUserResume;
		}
	}
}
