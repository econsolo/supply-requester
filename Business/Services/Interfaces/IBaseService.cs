using System.Collections.Generic;
using System.Net;

namespace SupplyRequester.Business.Services.Interfaces
{
    public interface IBaseService
    {
        bool HasNotifications();
        List<string> GetNotifications();
        HttpStatusCode GetHttpStatusCode();
        void Notify(params string[] messages);
        void Notify(HttpStatusCode httpStatusCode, params string[] messages);
        void ClearNotifications();
    }
}
