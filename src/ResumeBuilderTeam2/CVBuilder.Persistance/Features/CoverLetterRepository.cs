using CVBuilder.Application.features.ResumeInterfaces;
using CVBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVBuilder.Persistence.Features
{
    public class CoverLetterRepository : Repository<UserCoverLetter, int>, ICoverLetterRepository
    {
        protected IApplicationDbContext _dbContext;
        
        protected int CommandTimeout { get; set; }

        public CoverLetterRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;            
        }
        public async Task<UserCoverLetter> GetCoverLetterByUserId(Guid userId)
        {
            var result = await _dbSet.Where(x => x.UserId == userId).FirstOrDefaultAsync();

            if (result == null) return null;

            return result;
        }

        public async Task<bool> UpdateCoverLetterByUserId(UserCoverLetter coverLetter)
        {
            var result = _dbSet.Update(coverLetter);
            if (result == null) return false;
            return true;

        }
        public async Task<bool> DeleteCoverLetter(UserCoverLetter coverLetter)
        {
            _dbContext.UserCoverLetters.Remove(coverLetter);
            return true;
        }
    }

}
