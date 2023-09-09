using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApiResponseDto<T> where T : class
    {
        public T? Result { get; set; }
        public List<T>? Results { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; } = "Saved Successfully";
    }
}
