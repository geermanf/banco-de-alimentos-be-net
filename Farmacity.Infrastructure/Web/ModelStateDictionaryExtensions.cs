using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Farmacity.Infrastructure.Web
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddModelErrorFormat(this ModelStateDictionary modelState, string key, string format, params object[] args)
        {
            modelState.AddModelError(key, string.Format(format, args));
        }

        public static HttpErrorResponse ToHttpError(this ModelStateDictionary modelState, HttpRequestMessage request)
        {
            if (modelState.IsValid)
                throw new ArgumentException("The modelState is valid", "modelState");

            var error = new HttpErrorResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                StatusDescription = HttpStatusCode.BadRequest.ToString(),
                Message = "One or more of the parameters or the parts of the body were missing or invalid. See data property for more details.",
                RequestId = request.Headers.FirstOrDefault(f=>f.Key== "X-Correlation-Id").Value.ToString()
            };

            error.Data = ConvertModelStateToErrors(modelState);

            return error;
        }

        private static Dictionary<string, string[]> ConvertModelStateToErrors(ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, string[]>();

            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;
                var modelErrors = keyModelStatePair.Value.Errors;

                if (modelErrors != null && modelErrors.Count > 0)
                {
                    var errorMessages = modelErrors.Select(e => string.IsNullOrWhiteSpace(e.ErrorMessage) ? "error occurred" : e.ErrorMessage).ToArray();

                    errors.Add(key, errorMessages);
                }
            }

            return errors;
        }
    }
}
