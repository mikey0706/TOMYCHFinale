using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Enums;
using Microsoft.AspNetCore.Http;
using Common.Exceptions;

namespace Common.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseDataException baseError)
            {
                context.Response.StatusCode = (int)baseError.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(TransformException(baseError));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(TransformException(ex));
            }
        }

        private string TransformException(BaseDataException ex)
        {
            return JsonSerializer.Serialize(new
            {
                StatusCode = (int)ex.ErrorCode,
                Message = ex.Message,
                DevMessage = ex.ToString()
            });
        }

        private string TransformException(Exception ex)
        {
            return JsonSerializer.Serialize(new
            {
                StatusCode = ErrorTypes.Undefined,
                Message = ex.Message,
                DevMessage = ex.ToString()
            });
        }
    }
}
