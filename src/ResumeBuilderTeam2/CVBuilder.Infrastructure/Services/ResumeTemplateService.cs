using CVBuilder.Application;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;
using CVBuilder.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Infrastructure.Services
{
    public class ResumeTemplateService : IResumeTemplateService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ResumeTemplateService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTemplate(string templateName, string templateThumbnail)
        {
            if (_unitOfWork.ResumeTemplates.IsDuplicateName(templateName, null))
            {
                throw new DuplicateNameException("Template Name is Duplicate");
            }
            
            ResumeTemplate template = new ResumeTemplate()
            {
                TemplateName = templateName,
                TemplateThumbNailUrl = templateThumbnail

            };

            _unitOfWork.ResumeTemplates.Add(template);
            _unitOfWork.Save();
        }

        public void DeleteTemplate(int id)
        {
            _unitOfWork.ResumeTemplates.Remove(id);
            _unitOfWork.Save();
        }

        public ResumeTemplate GetTemplate(int id)
        {
            return _unitOfWork.ResumeTemplates.GetById(id);
        }

        public IList<ResumeTemplate> GetTemplates()
        {
            return _unitOfWork.ResumeTemplates.GetAll();
        }

        public void UpdateTemplate(int id, string templateName, string templateThumbnail)
        {
            if(_unitOfWork.ResumeTemplates.IsDuplicateName(templateName,id)) {
                throw new DuplicateNameException("Template name is duplicate");
            }
            ResumeTemplate template = _unitOfWork.ResumeTemplates.GetById(id);
            template.TemplateName = templateName;
            template.TemplateThumbNailUrl= templateThumbnail;

            _unitOfWork.Save();
        }
    }
}
