using System;
using System.Collections.Generic;

namespace SwaggerApiNetCore31.ViewModels
{
    public class ErrorResponseVm
    {
        public ErrorResponseVm()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsVm>();
        }

        public ErrorResponseVm(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsVm>();
            AddError(logref, message);
        }

        public string TraceId { get; private set; }
        public List<ErrorDetailsVm> Errors { get; private set; }

        public class ErrorDetailsVm
        {
            public ErrorDetailsVm(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }

            public string Logref { get; private set; }

            public string Message { get; private set; }
        }

        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetailsVm(logref, message));
        }
    }
}
