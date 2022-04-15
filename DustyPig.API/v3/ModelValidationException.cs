using System;
using System.Collections.Generic;

namespace DustyPig.API.v3
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException() : base("Validation failed") { }

        public ModelValidationException(string error) : base("Validation failed")
        {
            Errors = new List<string>();
            Errors.Add(error);
        }

        public List<string> Errors { get; set; }

        public override string ToString() => $"{Message}:\r\n\r\n" + string.Join("\r\n", Errors);
    }
}
