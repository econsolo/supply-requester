using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SupplyRequester.Business.Services
{
    public abstract class BaseService
    {
        protected ILogger Logger;
        protected IMapper Mapper;
        private readonly List<string> _notifications;

        public bool HasNotifications => _notifications.Any();
        public HttpStatusCode StatusCode { get; private set; }

        protected BaseService(
            IMapper mapper
        )
        {
            Mapper = mapper;
            _notifications = new List<string>();
            StatusCode = HttpStatusCode.OK;
        }

        protected void Notify(params string[] messages)
        {
            Notify(HttpStatusCode.OK, messages);
        }

        protected void Notify(HttpStatusCode httpStatusCode, params string[] messages)
        {
            StatusCode = httpStatusCode;
            _notifications.AddRange(messages);
        }

        protected void ClearNotifications()
        {
            _notifications.Clear();
            StatusCode = HttpStatusCode.OK;
        }
    }
}
