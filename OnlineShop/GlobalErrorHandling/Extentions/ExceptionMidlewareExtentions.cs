using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using OlineShop.Logger.Interfaces;
using OlineShop.Logger.Models;
using OnlineShop.GlobalErrorHandling.Models;
using System.Net;

namespace OnlineShop.GlobalErrorHandling.Extentions
{
    public static class ExceptionMidlewareExtentions
    {
        public static void ConfigExceptionHandling(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log log = logger.LogError(null, OlineShop.Logger.Enums.LogEvents.Exception, $"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error, for more information please contact 'SUPPORT'. Log id = {log.Id}"
                        }.ToString());
                    }
                });

            }
                );
        }
    }
}
