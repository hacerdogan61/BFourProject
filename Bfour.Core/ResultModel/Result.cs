using System;
using System.Text.Json.Serialization;

namespace Bfour.Core.ResultModel
{
	public class Result<T>
	{
		public T? Data { get; set; }
		public List<string>? Errors { get; set; }
		[JsonIgnore]
		public int StatusCode { get; set; }
		public bool IsSuccess { get; set; }



		public static Result<T> Success(int statusCode,T data,bool isSuccess)
		{
			return new Result<T> { Data = data, StatusCode = statusCode ,IsSuccess=isSuccess};
		}
        public static Result<T> Success(int statusCode, bool isSuccess)
        {
            return new Result<T> {StatusCode = statusCode,IsSuccess=isSuccess };
        }
        public static Result<T> Fail(int statusCode, List<string> errors, bool isSuccess)
        {
            return new Result<T> { StatusCode = statusCode,Errors=errors,IsSuccess=isSuccess };
        }
        public static Result<T> Fail(int statusCode, string errors, bool isSuccess)
        {
            return new Result<T> { StatusCode = statusCode, Errors = new List<string> { errors }, IsSuccess = isSuccess };
        }
    }

}

