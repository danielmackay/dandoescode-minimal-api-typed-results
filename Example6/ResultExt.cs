using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;

namespace Example6;

public static class ResultExt
{
    public static bool IsInvalid(this Result result) => result.Status == ResultStatus.Invalid;

    public static bool IsOk(this Result result) => result.Status == ResultStatus.Ok;

    public static bool IsNotFound(this Result result) => result.Status == ResultStatus.NotFound;

    public static bool IsError(this Result result) => result.Status == ResultStatus.Error;

    public static bool IsForbidden(this Result result) => result.Status == ResultStatus.Forbidden;

    public static bool IsUnauthorized(this Result result) => result.Status == ResultStatus.Unauthorized;

    public static bool IsCriticalError(this Result result) => result.Status == ResultStatus.CriticalError;

    public static bool IsConflict(this Result result) => result.Status == ResultStatus.Conflict;

    public static ValidationProblemDetails ToValidationProblem(this Result result)
    {
        var errors = new Dictionary<string, string[]>();
        foreach (var error in result.ValidationErrors)
            errors.Add(error.Identifier, [error.ErrorMessage]);

        return new ValidationProblemDetails
        {
            Status = 400,
            Title = "One or more validation errors occurred.",
            Errors = errors
        };
    }
}
