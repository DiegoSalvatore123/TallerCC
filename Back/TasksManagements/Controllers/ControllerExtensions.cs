using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TasksManagements.Controllers
{
    public static class ControllerExtensions
    {
        public static async Task<IActionResult> StandardizeResponse(this ControllerBase controller,
            HttpResponseMessage response)
        {
            if (response == null)
                return controller.StatusCode(204, "Content not available");
            var responseContent = await response.Content.ReadAsAsync<object>();
            if (responseContent == null)
                return controller.StatusCode(204, "Content not available");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => controller.Ok(responseContent),
                HttpStatusCode.NoContent => controller.StatusCode(204, responseContent),
                HttpStatusCode.Forbidden => controller.StatusCode(403, responseContent),
                HttpStatusCode.InternalServerError => controller.StatusCode(500, responseContent),
                HttpStatusCode.NotFound => controller.StatusCode(404, responseContent),
                _ => controller.StatusCode(400, responseContent)
            };
        }
    }
}
