using System;

namespace MS.CommandQuery.Core
{
    public class CommandException : Exception
    {
        public string Code { get; set; }

        public CommandException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
