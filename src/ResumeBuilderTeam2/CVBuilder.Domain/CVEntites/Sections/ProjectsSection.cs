using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVBuilder.Domain.CVEntites.BaseEntites;
using CVBuilder.Domain.Entities;

namespace CVBuilder.Domain.CVEntites.Sections
{
    public class ProjectsSection : IEntity<int>
    {
        public ProjectsSection() { 
            ProjectItems = new List<Project>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Project> ProjectItems { get; set; }
        public Resume ResumeData { get; set; }
        public int ResumeDataId { get; set; }

    }
}
