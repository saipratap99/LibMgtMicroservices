using System.Net;
using System.Text.Json;

namespace TagsAPIService.Exceptions
{
    public class AppGlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public AppGlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case TagNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { msg = ex?.Message });
                await response.WriteAsync(result);
            }
        }

    }
}
