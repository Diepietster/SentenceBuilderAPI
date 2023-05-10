using System;

namespace SentenceBuilderAPI.Models.BaseResponse
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            
        }

        public BaseResponse(bool success, string message)
        {
            Message = message;
            Success = success;
        }

        public bool Success { get; set; }
        
        public string Message { get; set; } 
    }
    public class BaseResponse<T> : BaseResponse where T : class
    {
        public BaseResponse()
        {
            
        }

        public BaseResponse(T data , string message ,bool success = true)
        {
            Message=message; 
            Success = success;
            Data = data;
        }

        public T Data { get; set; }
    }
}
