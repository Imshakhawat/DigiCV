using Autofac;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.Entities;

namespace CVBuilder.Web.Areas.Users.Models
{
    public class CoverLetterDeleteModel
    {
        public UserCoverLetter UserCoverLetter { get; set; }
        private ICoverLetterService _coverLetterService;
        public CoverLetterDeleteModel()
        {

        }

        public CoverLetterDeleteModel(ICoverLetterService coverLetterService)
        {
            _coverLetterService = coverLetterService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _coverLetterService = scope.Resolve<ICoverLetterService>();
        }

        internal void DeleteCoverLetter(int id, Guid userId)
        {

            _coverLetterService.DeleteCoverLetter(id, userId);

        }

    }

}
