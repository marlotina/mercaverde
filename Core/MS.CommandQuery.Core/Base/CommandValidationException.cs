using System;
using System.Collections.Generic;

namespace MS.CommandQuery.Core.Base
{
    public class CommandValidationException : Exception
    {
        private readonly IEnumerable<string> _errorMessages;

        public CommandValidationException(IEnumerable<string> errorMessages)
        {
            _errorMessages = errorMessages;
        }

        public override string Message
        {
            get
            {
                return string.Join(string.Empty, _errorMessages);
            }
        }
    }
}
