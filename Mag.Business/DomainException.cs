using System;

namespace Mag.Business
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception exc)
            : base(message, exc)
        {
        }
    }
}