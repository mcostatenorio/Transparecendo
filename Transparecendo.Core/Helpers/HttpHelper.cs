using Microsoft.AspNetCore.Mvc;
using System.Net;
using Transparecendo.Core.Services;

namespace Transparecendo.Core.Helpers
{
    /// <summary>
    /// Operações para auxiliar na manipulação de objetos HTTP.
    /// </summary>
    public static class HttpHelper
    {
        public static ActionResult Post(Result result)
        {
            return HttpHelper.Convert(result, HttpStatusCode.Created);
        }

        public static ActionResult Get(Result result)
        {
            return HttpHelper.Convert(result, HttpStatusCode.OK);
        }

        public static ActionResult Delete(Result result)
        {
            return new NoContentResult();
        }

        public static ActionResult Put(Result result)
        {
            return HttpHelper.Convert(result, HttpStatusCode.OK);
        }

        public static ActionResult Convert(Result result)
        {
            return HttpHelper.Convert(result, HttpStatusCode.OK);
        }

        public static ObjectResult Convert(Result result, HttpStatusCode httpStatusCode)
        {

            if (result == null)
            {
                throw new ArgumentException("Result cannot be null.", "result");
            }

            if (!result.Success)
            {
                return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.UnprocessableEntity };
            }

            return new ObjectResult(result) { StatusCode = (int)httpStatusCode };
        }
    }
}

