using FluentValidation;

namespace WebApplication5.Api.Requests
{
    public class CreateAccount
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }


    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(6);
        }
    }
}
