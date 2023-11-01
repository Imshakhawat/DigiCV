using CVBuilder.Domain.Entities;
using CVBuilder.Domain.Repositories;

namespace CVBuilder.Application.features.ResumeInterfaces
{
    public interface ICoverLetterRepository : IRepositoryBase<UserCoverLetter, int>
    {
        Task<UserCoverLetter> GetCoverLetterByUserId(Guid userId);
        Task<bool> UpdateCoverLetterByUserId(UserCoverLetter coverLetter);
        Task<bool> DeleteCoverLetter(UserCoverLetter coverLetter);
    }
}
