using CVBuilder.Application.features.ResumeInterfaces;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Persistence.Features
{
    public class ResumeTemplateRepository : Repository<ResumeTemplate, int>, IResumeTemplateRepository
    {
                
        public ResumeTemplateRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            
        }

        public bool IsDuplicateName(string name, int? id)
        {
            int? existingTemplateCount = null;
            if (id.HasValue)
            {
                existingTemplateCount = GetCount(x=>x.TemplateName ==name && x.Id == id.Value);
            }
            else
                existingTemplateCount = GetCount(x => x.TemplateName ==name);

            return existingTemplateCount > 0;
        }
    }
}
