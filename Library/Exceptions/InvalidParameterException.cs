using System;

namespace Library.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string mensagem)
            : base(mensagem)
        { }
    }
}