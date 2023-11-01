using Crud.Persistance.Features.Membership;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.Entities;
using CVBuilder.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Worker.Model
{
    public class MailSender 
    {
        private IEmailServiceTest _emailServiceTest;
        private IConfiguration _configuration;

        public MailSender() { }
        public MailSender(IEmailServiceTest emailServiceTest, IConfiguration configuration)
        {
            _emailServiceTest = emailServiceTest;
            _configuration = configuration;
        }
        public async Task SendEmailConfitmationEmail(ApplicationUser user, string code)
        {
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;

            UserEmailOptions emailOptions = new UserEmailOptions()
            {
                ToEmail = new List<string> { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink,user.Id, code))
                }
            };
            await _emailServiceTest.SendEmailConfirmation(emailOptions);
        }

        public async Task SendResetPasswordEmail(ApplicationUser user, string code)
        {
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;

            UserEmailOptions emailOptions = new UserEmailOptions()
            {
                ToEmail = new List<string> { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink,user.Id, code))
                }
            };
            await _emailServiceTest.SendEmailResetPassword(emailOptions);
        }
    }
}
