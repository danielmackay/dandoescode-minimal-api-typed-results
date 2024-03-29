using Ardalis.Result;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Example6;

public static class TypedResultsExt
{
    public static ValidationProblem ValidationProblem(Result result)
    {
        var errors = new Dictionary<string, string[]>();
        foreach (var error in result.ValidationErrors)
            errors.Add("", [error.ErrorMessage]);

        return TypedResults.ValidationProblem(errors, title: "One or more validation errors occurred.");
    }
}
