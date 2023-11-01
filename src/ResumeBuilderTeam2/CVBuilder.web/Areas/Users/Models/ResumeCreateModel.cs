using Autofac;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;

namespace CVBuilder.Web.Areas.Users.Models
{
    public class ResumeCreateModel
    {
        public Resume CVTemplate { get; set; }
        private IResumeService _resumeService;
        public ResumeCreateModel()
        {
        }
        public ResumeCreateModel(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }
        internal void ResolveDependency(ILifetimeScope scope)
        {
            _resumeService = scope.Resolve<IResumeService>();
        }
        internal void CreateResume()
        {
            _resumeService.InsertResume(CVTemplate);
        }


        public Task<bool> DeleteResumeData(Resume resume)
        {
            return _resumeService.DeleteResumeData(resume);
        }

    

        public async Task<Resume> GetCVByByUserIdWithTempateId(Guid userId , int tempId)
        {
           
            var result =  await  _resumeService.GetResumeByUserAndTemplateId(userId, tempId);
            return result;
        }

        public Task<IList<Resume>> GetAllResumeByUser(Guid userId)
        {
            return _resumeService.GetAllResumeByUser(userId);
        }
        internal Resume GetCV(int id)
        {
            Resume cv = _resumeService.GetCvTemplate( id);
            return cv;
		}
	}
}
