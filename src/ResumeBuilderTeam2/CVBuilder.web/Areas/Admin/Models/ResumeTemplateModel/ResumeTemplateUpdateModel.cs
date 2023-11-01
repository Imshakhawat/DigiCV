
using Autofac;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;
using System.ComponentModel.DataAnnotations;

namespace CVBuilder.Web.Areas.Admin.Models.ResumeTemplateModel
{
    public class ResumeTemplateUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TemplateName { get; set; }
        [Required]
        public string? TemplatePictureUrl { get; set; }

        private IResumeTemplateService _resumeTemplateService;

        public ResumeTemplateUpdateModel()
        {

        }

        public ResumeTemplateUpdateModel(IResumeTemplateService resumeTemplateService)
        {
            _resumeTemplateService = resumeTemplateService;
        }

        internal void Load(int id)
        {
            ResumeTemplate resumeTemplate = _resumeTemplateService.GetTemplate(id);
            id = resumeTemplate.Id;
            TemplateName = resumeTemplate.TemplateName;
            TemplatePictureUrl = resumeTemplate.TemplateThumbNailUrl;
        }
        internal void UpdateResumeTemplate()
        {
            if (!string.IsNullOrEmpty(TemplateName))
            {
                _resumeTemplateService.UpdateTemplate(Id, TemplateName, TemplatePictureUrl);
            }
        }
        internal void ResolveDependency(ILifetimeScope scope)
        {
            _resumeTemplateService = scope.Resolve<IResumeTemplateService>();
        }
    }
}
 