using CVBuilder.Domain.CVEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Application.features.Services
{
    public interface IResumeTemplateService
    {
        void AddTemplate(string templateName, string templateThumbnail);

        void DeleteTemplate(int id);

        ResumeTemplate GetTemplate(int id);

        public IList<ResumeTemplate> GetTemplates();
        void UpdateTemplate(int id, string templateName, string templateThumbnail);

    }
}
