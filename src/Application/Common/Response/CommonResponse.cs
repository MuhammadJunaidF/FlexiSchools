using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Response
{
    public class CommonResponse
    {
        public CommonResponse() { }
        public CommonResponse(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static T CreateFailedResponse<T>(string message) where T : CommonResponse
        {
            var instance = Activator.CreateInstance<T>();
            instance.IsSuccess = false;
            instance.Message = message;

            return instance;
        }

        public static T CreateSuccessResponse<T>(string message) where T : CommonResponse
        {
            var instance = Activator.CreateInstance<T>();
            instance.IsSuccess = true;
            instance.Message = message;

            return instance;
        }
    }

}
