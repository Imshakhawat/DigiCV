using Autofac;
using CVBuilder.Application.features.Services;
using System.ComponentModel.DataAnnotations;

namespace CVBuilder.Web.Areas.Admin.Models.ResumeTemplateModel
{
    public class ResumeTemplateCreateModel
    {
        [Required]
        public string TemplateName { get; set; }

        public string? ReturnUrl { get; set; }

        [Display(Name = "Choose Template Picture")]
        [Required]
        public IFormFile? TemplatePicture { get; set; }
        public string? TemplatePictureUrl { get; set; }

        private IResumeTemplateService _resumeTemplateService;


        public ResumeTemplateCreateModel()
        {

        }
        public ResumeTemplateCreateModel(IResumeTemplateService resumeTemplateService)
        {
            _resumeTemplateService = resumeTemplateService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _resumeTemplateService = scope.Resolve<IResumeTemplateService>();
        }

        internal void CreateResumeTemplate(string name, string url)
        {

            _resumeTemplateService.AddTemplate(name, url);

        }
    }
}
