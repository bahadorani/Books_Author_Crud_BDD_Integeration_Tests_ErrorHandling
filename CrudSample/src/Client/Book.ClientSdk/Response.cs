using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.ClientSdk
{
    public class Response<TData> 
    {
        public Response()
        {
        }

        public Response(TData data)
        {
            Success = true;
            Data = data;
        }

        public Response(int error)
        {
            Success = false;
            Error = error;
        }

        public bool Success { get; set; }
        public TData? Data { get; set; }
        public int Error { get; set; }
    }
}
