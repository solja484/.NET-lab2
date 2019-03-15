using System;

namespace KMAAndrusiv02
{
    internal class AgeTooBigException: Exception
    {

        private const string DefaultMessage = "You're too old to be alive!";


        public AgeTooBigException() : base(DefaultMessage)
        {
        }
        public AgeTooBigException(string msg) : base($"{msg} - {DefaultMessage}")
        {

        }
        public AgeTooBigException(string msg, Exception e) : base($"{msg} - {DefaultMessage}", e)
        {

        }
    }
}
