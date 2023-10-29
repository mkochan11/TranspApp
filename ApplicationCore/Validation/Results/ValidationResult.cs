using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Validation.Errors;

namespace ApplicationCore.Validation.Results
{
    public class ValidationResult
    {
        private static readonly ValidationResult _success = new ValidationResult { Succeeded = true };
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public bool Succeeded { get; protected set; }

        public IEnumerable<ValidationError> Errors => _errors;
        public static ValidationResult Success => _success;

        public static ValidationResult Failed(params ValidationError[] errors)
        {
            var result = new ValidationResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }
}
