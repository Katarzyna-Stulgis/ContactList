using ContactList.Dal.Context;
using ContactList.Service.Dtos;
using FluentValidation;

namespace ContactList.Api.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ContactlistDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}") // validation for more than 8 characters, uppercase and lowercase letters and special character
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .NotEmpty();
        }
    }
}
