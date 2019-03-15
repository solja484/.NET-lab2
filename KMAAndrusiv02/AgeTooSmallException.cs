using System;

namespace KMAAndrusiv02
{
   internal class AgeTooSmallException:Exception
    {
        private const string DefaultMessage = "Age can't be less than 0!";


        public AgeTooSmallException() : base(DefaultMessage)
        {
        }
        public AgeTooSmallException(string msg) : base($"{msg} - {DefaultMessage}")
        {

        }
        public AgeTooSmallException(string msg, Exception e) : base($"{msg} - {DefaultMessage}", e)
        {

        }

    }
}
