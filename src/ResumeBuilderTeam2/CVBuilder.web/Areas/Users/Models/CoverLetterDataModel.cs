using Autofac;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.Entities;
using CVBuilder.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilder.Web.Areas.Users.Models
{
    public class CoverLetterDataModel
    {
        private ICoverLetterService _coverLetterService;
        public CoverLetterDataModel()
        {

        }

        public CoverLetterDataModel(ICoverLetterService coverLetterService)
        {
            _coverLetterService = coverLetterService;
        }
        public Guid UserId { get; set; }
        public string Heading { get; set; }
        public DateTime Date { get; set; }
        public string HiringBody { get; set; }
        public string CompanyAddress { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }



        internal void Load(Guid id)
        {
             UserCoverLetter dataModel = _coverLetterService.GetCoverLetter(id);
             Heading = dataModel.Heading;
             Date = dataModel.Date;
             HiringBody = dataModel.HiringBody;
             CompanyAddress = dataModel.CompanyAddress;
             Email = dataModel.Email;
             Body = dataModel.Body;
             Footer = dataModel.Footer;
        }
        internal void ResolveDependency(ILifetimeScope scope)
        {
            _coverLetterService = scope.Resolve<ICoverLetterService>();
        }

       

    }
}
