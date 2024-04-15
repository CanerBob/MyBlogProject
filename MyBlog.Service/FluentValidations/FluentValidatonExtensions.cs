namespace MyBlog.Service.FluentValidations;
public static class FluentValidatonExtensions
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState) 
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}