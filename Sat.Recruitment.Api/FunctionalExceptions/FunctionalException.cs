using System;

namespace Sat.Recruitment.Api.FunctionalExceptions
{
    public class FunctionalException : Exception
    {
        public FunctionalException(string? message)
            : base(message) { }
    }
}
