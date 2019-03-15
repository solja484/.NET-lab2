using System;

namespace KMAAndrusiv02
{
    // Singleton
    internal class PersonManager
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

        public Person PersonInstance { get; } = new Person("", "", "", DateTime.MinValue);

        private PersonManager()
        {

        }
    }
}
