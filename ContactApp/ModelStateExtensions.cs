using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactApp;

/// <summary>
/// Extension methods for ModelState
/// </summary>
public static class ModelStateExtensions
{
    /// <summary>
    /// Add validation errors to model state dictionary
    /// </summary>
    /// <param name="modelState">Model state dictionary</param>
    /// <param name="errors">Validation errors to add</param>
    public static void AddValidationErrors(this ModelStateDictionary modelState, IEnumerable<ValidationResult> errors)
    {
        foreach (var error in errors)
        {
            if (error.ErrorMessage is null) continue;

            if (!error.MemberNames.Any())
            {
                modelState.AddModelError("", error.ErrorMessage);
                continue;
            }

            foreach (var memberName in error.MemberNames)
            {
                modelState.AddModelError(memberName, error.ErrorMessage);
            }
        }
    }
}
