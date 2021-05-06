using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPPR_Demo.Models
{
    public class Response<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
