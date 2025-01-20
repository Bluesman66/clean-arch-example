namespace GymManagement.Api.Endpoints;

using ErrorOr;

public static class ApiResults
{
    public static IResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Results.Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        return Problem(errors[0]);
    }

    public static IResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Results.Problem(statusCode: statusCode, detail: error.Description);
    }

    public static IResult ValidationProblem(List<Error> errors)
    {
        var stateDictionary = new Dictionary<string, string[]>();

        foreach (var error in errors)
        {
            stateDictionary.Add(error.Code, [error.Description]);
        }

        return Results.ValidationProblem(stateDictionary);
    }
}