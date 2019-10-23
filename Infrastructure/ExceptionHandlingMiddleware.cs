using BancoDeAlimentos.DTOs.Response;
using BancoDeAlimentos.Entities.Common;
using BancoDeAlimentos.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Infrastructure
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (AggregateException ex) when (ex.InnerException is TokenException)
            {
                await TokenException(context, (TokenException)ex.InnerException);
            }
            catch (InvalidRoleException ex)
            {
                await GenericBadRequestException(context, ex);
            }
            catch (IncorrectCustomerVariablesException ex)
            {
                await GenericBadRequestException(context, ex);
            }
            catch (TokenException ex)
            {
                await TokenException(context, ex);
            }
            catch (HttpRequestException ex)
            {
                await GenericBadRequestException(context, ex);
            }
            catch (ValidationException ex)
            {
                await ValidationException(context, ex);
            }
            catch (DuplicateObjectException ex)
            {
                await GenericBadRequestException(context, ex);
            }
            catch (Exception ex)
            {
                await GenericBadRequestException(context, ex);
            }


        }

        private Task GenericBadRequestException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse { Errors = { ex.Message } }));
        }

        private static Task ValidationException(HttpContext context, ValidationException validationException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(validationException._baseResponse));
        }

        private static Task TokenException(HttpContext context, TokenException tokenException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse { Errors = { tokenException.Message } }));
        }

    }
}
