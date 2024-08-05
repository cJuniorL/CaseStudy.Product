using CaseStudy.Product.Contracts.Responses.Base;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace CaseStudy.Product.API.Handlers;

public static class ErrorHandlerMiddleware
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder appBuilder)
    {
        return appBuilder.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {   
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                var defaultData = null as BaseResponse;

                if (exceptionHandlerFeature != null)
                {
                    if (exceptionHandlerFeature.Error is FluentValidation.ValidationException fvex)
                    {
                        defaultData = new BaseResponse(fvex.Errors.Select(_ => new BaseMessageResponse(_.ErrorMessage)));
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        defaultData = new BaseResponse(new BaseMessageResponse[] { new("Internal Server Error") });
                        await context.Response.WriteAsync(JsonSerializer.Serialize(exceptionHandlerFeature.Error));
                    }
                }

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(defaultData));
                return;
            });
        });
    }
}
