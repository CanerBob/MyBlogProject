﻿namespace MyBlog.Service.Extensions;
public static class FluentValidatonExtensions
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
    public static void AddToIdentityModelState(this IdentityResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError("",error.Description);
        }
    }
}
