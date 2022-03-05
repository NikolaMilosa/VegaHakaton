using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerObjects.Responses
{
    public class BasicResponse
    {
        public bool IsSuccessful { get; }
        public string Message { get; }

        public BasicResponse(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
