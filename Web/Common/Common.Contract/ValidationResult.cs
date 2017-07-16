using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contract
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            ErrorCode = string.Empty;
            ErrorMessage = string.Empty;
            IsValid = true;
        }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsValid { get; set; }
    }
}
