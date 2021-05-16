using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessfulDataResult<T> : DataResult<T>
    {
        public SuccessfulDataResult() : base(default, true) { }
        public SuccessfulDataResult(string message) : base(default, true, message) { }
        public SuccessfulDataResult(T data) : base(data, true) { }
        public SuccessfulDataResult(T data, string message) : base(data, true, message) { }
    }
}
