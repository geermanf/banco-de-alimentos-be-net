﻿using Farmacity.FCDM.BackOffice.DTOs.Response;
using System;


namespace Farmacity.FCDM.BackOffice.Infrastructure.Exceptions
{
    public class ValidationException : ArgumentException
    {
        public BaseResponse _baseResponse { get; set; }

        public ValidationException(BaseResponse baseResponse, ArgumentException inner = null)  
        {
            _baseResponse = baseResponse;
        }
    }
}
