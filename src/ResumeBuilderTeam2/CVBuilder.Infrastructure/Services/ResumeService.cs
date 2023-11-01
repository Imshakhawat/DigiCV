using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVBuilder.Application;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;

namespace CVBuilder.Infrastructure.Service
{
	public class ResumeService : IResumeService
	{

		private readonly IApplicationUnitOfWork _unitOfWork;
		public ResumeService(IApplicationUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Resume> GetResumeByUserAndTemplateId(Guid userId, int tempId)
		{
			var result = await _unitOfWork.Resumes.GetCVByUserId(userId, tempId);
			return result;
		}

		//  public void InsertResume(CVTemplate Resume)

		//used for specific CV
		public Resume GetCvTemplate(int id)
		{
			return _unitOfWork.Resumes.GetById(id);
		}

        public void GetCvTemplate2(int x)
        {
        }

        public void InsertResume(Resume Resume)
			 
		{

			_unitOfWork.Resumes.Add(Resume);
			_unitOfWork.Save();
		}

		public Task<bool> DeleteResumeData(Resume Resume)
		{
			_unitOfWork.Resumes.DeleteResumeData(Resume);
			return Task.FromResult(true);
		}

		public async Task<IList<Resume>> GetAllResumeByUser(Guid userId)
		{
			return await _unitOfWork.Resumes.GetAllResumeByUser(userId);
		}

		public async Task<bool> UpdateResume(Resume Resume)
		{
			//var result =  _unitOfWork.Resumes.UpdateCVByUserIdAndTempId(Resume);
			try
			{
				var result = _unitOfWork.Resumes.EditAsync(Resume);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
	}
}
