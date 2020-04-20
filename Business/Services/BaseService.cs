using AutoMapper;
using Microsoft.Extensions.Logging;
using SupplyRequester.Business.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SupplyRequester.Business.Services
{
    public abstract class BaseService : IBaseService
    {
        protected ILogger Logger;
        protected IMapper Mapper;
        private HttpStatusCode _statusCode;
        private readonly List<string> _notifications;

        protected BaseService(
            IMapper mapper
        )
        {
            Mapper = mapper;
            _notifications = new List<string>();
            _statusCode = HttpStatusCode.OK;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return _statusCode;
        }

        public void Notify(params string[] messages)
        {
            Notify(HttpStatusCode.OK, messages);
        }

        public void Notify(HttpStatusCode httpStatusCode, params string[] messages)
        {
            _statusCode = httpStatusCode;
            _notifications.AddRange(messages);
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
            _statusCode = HttpStatusCode.OK;
        }
    }
}
