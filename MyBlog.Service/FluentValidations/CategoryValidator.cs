namespace MyBlog.Service.FluentValidations;
public class CategoryValidator: AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x=>x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(3)
            .WithName("Kategori Adı");
    }
}