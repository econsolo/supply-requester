using System.Collections.Generic;
using System.Linq;

namespace SupplyRequester.Model.DataTransferObjects
{
    public class ApiResponseDto
    {
        public ApiResponseDto(object data)
        {
            Init(data, Enumerable.Empty<string>());
        }

        public ApiResponseDto(object data, IEnumerable<string> notifications)
        {
            Init(data, notifications);
        }

        public ApiResponseDto(string notification)
        {
            Init(null, Enumerable.Repeat(notification, (int)decimal.One));
        }

        public object Data { get; set; }
        public IEnumerable<string> Notifications { get; set; }

        private void Init(object data, IEnumerable<string> notifications)
        {
            Data = data;
            Notifications = notifications;
        }
    }
}
