using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;

namespace CVBuilder.Web.Areas.Admin.Models.ResumeTemplateModel
{
    public class ResumeTemplateListModel
    {
        
        private readonly IResumeTemplateService _resumeTemplateService;

        public ResumeTemplateListModel(IResumeTemplateService resumeTemplateService)
        {
            _resumeTemplateService = resumeTemplateService;
        }

        public IList<ResumeTemplate> GetResumeTemplates()
        {
            return _resumeTemplateService.GetTemplates();
        }

        public void DeleteTemplate(int id)
        {
            _resumeTemplateService.DeleteTemplate(id);
        }
    }
}
