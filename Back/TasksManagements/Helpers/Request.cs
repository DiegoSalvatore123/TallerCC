using System.Net;
using System.Net.Http.Formatting;

namespace TasksManagements.Helpers
{
    public static class Request
    {
        public static HttpResponseMessage CreateResponse<T>(HttpStatusCode statusCode, T content)
        {
            return new HttpResponseMessage()
            {
                StatusCode = statusCode,
                Content = new ObjectContent<T>(content, new JsonMediaTypeFormatter(), "application/json")
            };
        }
    }
}
