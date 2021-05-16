using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool successful) : base(successful)
        {
            Data = data;
        }
        public DataResult(T data, bool successful, string message) : base(successful, message)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
