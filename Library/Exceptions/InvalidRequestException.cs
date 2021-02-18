using System;

namespace Library.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string mensagem = "Invalid Request")
            : base(mensagem)
        { }
    }
}