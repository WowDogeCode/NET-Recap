using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool successful)
        {
            Successful = successful;
        }
        public Result(bool successful, string message) : this(successful)
        {
            Message = message;
        }
        public bool Successful { get; }
        public string Message { get; }
    }
}
