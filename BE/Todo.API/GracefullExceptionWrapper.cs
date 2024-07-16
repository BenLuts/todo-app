using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Todo.API;

public class GracefullExceptionWrapper : IExceptionHandler
{
    private readonly ILogger<GracefullExceptionWrapper> _logger;

    public GracefullExceptionWrapper(ILogger<GracefullExceptionWrapper> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var gracefullResponse = new Error(HttpStatusCode.InternalServerError, exception.Message);
        httpContext.Response.StatusCode = (int)HttpStatusCode.OK;

        await httpContext.Response
            .WriteAsJsonAsync(gracefullResponse, cancellationToken);

        return true;
    }
}
