using System.Collections.Generic;

namespace MS.CommandQuery.Core.Base
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IList<string> ErrorMessages { get; set; }

        public ValidationResult()
        {
            IsValid = true;
        }
    }
}
