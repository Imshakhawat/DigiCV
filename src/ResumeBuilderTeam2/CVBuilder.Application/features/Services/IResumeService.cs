using CVBuilder.Domain.CVEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Application.features.Services
{
    public interface IResumeService
    {
        public void InsertResume(Resume Resume);
        public Task<Resume> GetResumeByUserAndTemplateId(Guid userId, int tempId); 
        public Task<bool> UpdateResume(Resume Resume);
		Resume GetCvTemplate(int id);
        public Task<bool> DeleteResumeData(Resume Resume);
		Task<IList<Resume>> GetAllResumeByUser(Guid userId);

        public void GetCvTemplate2(int x); 

    }
}
