﻿using Microsoft.AspNetCore.Mvc;

namespace Olymp_Project.Helpers
{
    public static class ResponseHelper
    {
        public static ActionResult GetActionResult(
            HttpStatusCode statusCode, object? value = null, string? actionName = "")
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    if (value is not null)
                    {
                        return new OkObjectResult(value);
                    }
                    else
                    {
                        return new StatusCodeResult(200);
                    }
                case HttpStatusCode.Created:
                    return new CreatedAtActionResult(actionName, null, null, value);
                case HttpStatusCode.BadRequest:
                    return new BadRequestResult();
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedResult();
                case HttpStatusCode.Forbidden:
                    return new ForbidResult("BasicAuthentication");
                case HttpStatusCode.NotFound:
                    return new NotFoundResult();
                case HttpStatusCode.Conflict:
                    return new ConflictResult();
                default:
                    return new StatusCodeResult(500);
            }
        }
    }
}
