using CVBuilder.Domain.Entities;

namespace CVBuilder.Application.features.Services

{
    public interface IEmailServiceTest
    {
        Task SendBulkEmail(UserEmailOptions emailOptions);
        Task SendEmailConfirmation(UserEmailOptions emailOptions);
        Task SendEmailResetPassword(UserEmailOptions emailOptions);
    }
}