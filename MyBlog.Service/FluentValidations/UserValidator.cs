namespace MyBlog.Service.FluentValidations;
public class UserValidator: AbstractValidator<AppUser>
{
    public UserValidator()
    {
        RuleFor(x=>x.FirstName)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(3)
            .WithName("İsim");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(3)
            .WithName("Soyisim");
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(3)
            .WithName("Kullanıcı Adı");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MinimumLength(11)
            .WithName("Telefon Numarası");
    }
}