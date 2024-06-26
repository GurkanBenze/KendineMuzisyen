﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Core.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, string message, string messageCode) : base(true, message, messageCode, data)
        {
        }

        public SuccessDataResult(T data, string message) : base(true, message, data)
        {
        }

    }
}
