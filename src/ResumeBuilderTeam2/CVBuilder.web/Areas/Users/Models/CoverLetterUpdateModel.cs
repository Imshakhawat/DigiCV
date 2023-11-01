using Autofac;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.Entities;

namespace CVBuilder.Web.Areas.Users.Models
{
    public class CoverLetterUpdateModel
    {
        public UserCoverLetter UserCoverLetter { get; set; }
        private ICoverLetterService _coverLetterService;
        public CoverLetterUpdateModel()
        {

        }

        public CoverLetterUpdateModel(ICoverLetterService coverLetterService)
        {
            _coverLetterService = coverLetterService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _coverLetterService = scope.Resolve<ICoverLetterService>();
        }

        internal void UpdateCoverLetter()
        {

            _coverLetterService.UpdateCoverLetter(UserCoverLetter);

        }


    }

}
