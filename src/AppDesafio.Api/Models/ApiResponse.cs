using System.Collections.Generic;

namespace AppDesafio.Api.Models
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse()
        {
            Message = new List<string>();
        }

        public bool IsSuccess { get; set; }
        public ICollection<string> Message { get; set; }
        public T Data { get; set; }
    }
}