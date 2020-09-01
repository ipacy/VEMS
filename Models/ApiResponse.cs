using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Messages = new List<ApiMessage>();
        }

        public void AddSuccess()
        {
            Messages.Add(new ApiMessage
            {
                Code = 0,
                Text = "Successfull"
            });
        }

        public void AddError(Exception ex)
        {
            Messages.Add(new ApiMessage
            {
                Code = -1,
                Text = ex.Message
            });
        }

        public void AddMessage(String message)
        {
            Messages.Add(new ApiMessage
            {
                Code = 0,
                Text = message
            });
        }

        public T Data { get; set; }
        public List<ApiMessage> Messages { get; set; }

        internal void AddError(string ex)
        {
            throw new NotImplementedException();
        }
    }
}
