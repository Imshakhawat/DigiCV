using CVBuilder.Domain.Entities;

namespace CVBuilder.Application.features.Services
{
    public interface ICoverLetterService
    {
        public void InsertCoverLetter(UserCoverLetter coverLetter);
        public UserCoverLetter GetCoverLetter(Guid userId);
        public void DeleteCoverLetter(int id, Guid userId);
        public void UpdateCoverLetter(UserCoverLetter coverLetter);

    }
}
