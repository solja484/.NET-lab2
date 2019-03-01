using System;

namespace KMAAndrusiv02
{
    // Singleton
    class PersonManager
    {
        private static readonly object Locker = new object();
        private static PersonManager _instance;

        public static PersonManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new PersonManager());
                }
            }
        }

        private Person _personInstance = new Person("", "", "", DateTime.MinValue);

        public Person PersonInstance
        {
            get
            {
                return _personInstance;
            }
        }

        private PersonManager()
        {

        }
    }
}
