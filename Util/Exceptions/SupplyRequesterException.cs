using System;
using System.Net;

namespace SupplyRequester.Util.Exceptions
{
    public class SupplyRequesterException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public SupplyRequesterException(
            string msg,
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest
        ) : base(msg)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
