using CVBuilder.Application;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Infrastructure.Services
{
    public class CoverLetterService: ICoverLetterService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public CoverLetterService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void InsertCoverLetter(UserCoverLetter coverLetter)
        {

            _unitOfWork.CoverLetters.Add(coverLetter);
            _unitOfWork.Save();
        }

        public async void DeleteCoverLetter(int id, Guid userId)
        {
            var deleteId = await _unitOfWork.CoverLetters.GetCoverLetterByUserId(userId);
            _unitOfWork.CoverLetters.Remove(deleteId);
            /*            _unitOfWork.Resumes.DeleteTemplate(deleteId);
            */
            _unitOfWork.Save();
        }

        public void UpdateCoverLetter(UserCoverLetter coverLetter)
        {
            _unitOfWork.CoverLetters.Edit(coverLetter);
            _unitOfWork.Save();
        }

        public UserCoverLetter GetCoverLetter(Guid userId)
        {
            return _unitOfWork.CoverLetters.GetCoverLetterByUserId(userId).Result;
        }
    }
}
