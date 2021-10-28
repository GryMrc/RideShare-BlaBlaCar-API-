using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.DataModels
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResponse SuccessfulResponse(string message)
        {
            return new ServiceResponse { Success = true, Message = message };
        }

        public static ServiceResponse FailedResponse(string message)
        {
            return new ServiceResponse { Success = false, Message = message };
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public IEnumerable<T> DataList { get; set; }
        public int Total { get; set; }
    }

    public class ServiceResponseSingleData<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}

