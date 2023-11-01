using Autofac;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;
using CVBuilder.Domain.Entities;
using CVBuilder.Web.Utilities;

namespace CVBuilder.Web.Areas.Users.Models
{
    public class CoverLetterCreateModel
    {

        public Guid UserId { get; set; }
        public string Heading { get; set; }
        public DateTime? Date { get; set; }
        public string? HiringBody { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Email { get; set; }
        public string? Body { get; set; }
        public string? Footer { get; set; }
        //public int Id { get; set; }
       // public UserCoverLetter userCoverLetter { get; set; }
        private ICoverLetterService _coverLetterService;
        public CoverLetterCreateModel()
        {

        }

        public CoverLetterCreateModel(ICoverLetterService coverLetterService)
        {
            _coverLetterService = coverLetterService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _coverLetterService = scope.Resolve<ICoverLetterService>();
        }

        internal void CreateCoverLetter()
        {
            UserCoverLetter userCoverLetter = new UserCoverLetter();
            userCoverLetter.UserId = new Guid(CommonClass.Uid) ;
            userCoverLetter.Heading = Heading;
            userCoverLetter.Date = DateTime.Now;
            userCoverLetter.HiringBody = HiringBody;
            userCoverLetter.Footer = Footer;
            userCoverLetter.CompanyAddress = CompanyAddress;
            userCoverLetter.Email = Email;
            userCoverLetter.Body = Body;
            //userCoverLetter.Id  = 1;

            _coverLetterService.InsertCoverLetter(userCoverLetter);

        }

    }

}
