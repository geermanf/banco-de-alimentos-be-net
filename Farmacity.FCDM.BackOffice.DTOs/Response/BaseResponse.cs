using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacity.FCDM.BackOffice.DTOs.Response
{
    public class BaseResponse
    {
        public List<string> Errors { get; set; }

        public BaseResponse(params string[] errors)
        {
            Errors = new List<string>(errors);
        }


    }
}
