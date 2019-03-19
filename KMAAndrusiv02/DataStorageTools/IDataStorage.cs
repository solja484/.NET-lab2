

using System.Collections.Generic;

namespace KMAAndrusiv02.DataStorageTools
{
    internal interface IDataStorage
    {
        bool UserExists(string login);

        Person GetUserByLogin(string login);

        void AddPerson(Person person);
        void SaveChanges();
        List<Person> PersonsList { get; }
    }
}


