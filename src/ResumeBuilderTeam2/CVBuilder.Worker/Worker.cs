using Crud.Persistance.Features.Membership;
using CVBuilder.Application.features.Services;
using CVBuilder.Infrastructure;
using CVBuilder.Worker.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace CVBuilder.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MailSender _mailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        public Worker(ILogger<Worker> logger, IEmailServiceTest emailService, MailSender mailSender,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _mailSender = mailSender;
            _userManager = userManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var reguser = _userManager.Users.ToList();
                foreach(var user in reguser)
                {
                    if(user.MailSendStatus == false && user.EmailConfirmed == false)
                    {
                       // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var code = user.Token;
                        user.MailSendStatus = true;
                        await _userManager.UpdateAsync(user);
                        _mailSender.SendEmailConfitmationEmail(user, code);
                    }
                    else if(user.MailSendStatus == false && user.EmailConfirmed == true)
                    {
                        var code = user.Token;
                        user.MailSendStatus = true;
                        await _userManager.UpdateAsync(user);
                        _mailSender.SendResetPasswordEmail(user, code);
                    }
                    _logger.LogInformation("Mail Sent : {time}", DateTimeOffset.Now);
                }
                

 

                await Task.Delay(1000*30, stoppingToken);
            }
        }
    }
}