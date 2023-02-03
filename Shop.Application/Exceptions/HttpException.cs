﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Exceptions
{
    [Serializable]
    public class HttpException : ApplicationException
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpException() { }
        public HttpException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
        public HttpException(string message, Exception inner) : base(message, inner) { }
    }
}
