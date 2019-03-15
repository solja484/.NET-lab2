using System;

namespace KMAAndrusiv02
{
    internal class InvalidEmailException: Exception
    {

       private const string DefaultMessage = "Your email is invalid";
    

       public InvalidEmailException() : base(DefaultMessage)
        {
        }
        public InvalidEmailException(string msg):base($"{msg} - {DefaultMessage}")
        {

        }
        public InvalidEmailException(string msg, Exception e) : base($"{msg} - {DefaultMessage}", e)
        {
            
        }
    }
}
