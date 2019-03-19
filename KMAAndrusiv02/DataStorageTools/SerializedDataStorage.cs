
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KMAAndrusiv02.Managers;

namespace KMAAndrusiv02.DataStorageTools
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                FillPersonsList(50);
            }
        }

        

        public bool UserExists(string mail)
        {
            return _persons.Exists(u => u.Mail == mail);
        }

        public Person GetUserByLogin(string mail)
        {
            return _persons.FirstOrDefault(u => u.Mail == mail);
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public List<Person> PersonsList => _persons.ToList();

        public void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }


        private void FillPersonsList(int v)
        {
            //1
           AddPerson(new Person("Benedict","Cumberbatch", "enedict@gmail.com", new DateTime(1976,7,19)));
           AddPerson(new Person("Bumbleclick", "Crumblescotch", "umbleclick@gmail.com", new DateTime(1992, 6, 17)));
           AddPerson(new Person("Benerobber"," Crackerblow", "enerobber@gmail.com", new DateTime(1988, 5, 1)));
           AddPerson(new Person("Bankerbuilder", "Clintonclopper", "ankerbuilder@gmail.com", new DateTime(1992, 4, 15)));
           AddPerson(new Person("Bananapeel","Childgibbler", "ananapeel@gmail.com", new DateTime(1901, 3, 13)));
        //2
           AddPerson(new Person("Brandydick","Cumsabunch ", "randydick@gmail.com", new DateTime(2001, 2, 22)));
           AddPerson(new Person("Benedril","Cumbersnatch", "enedril@gmail.com", new DateTime(1954, 1, 12)));
           AddPerson(new Person("Bumbersnatch","Cuddlebitch", "umbersnatch@gmail.com", new DateTime(2008, 12, 21)));
           AddPerson(new Person("Beneduack","Cucemberbatch", "eneduack@gmail.com", new DateTime(2005, 11, 18)));
           AddPerson(new Person("Banglesnack","Fumbleswatch", "anglesnack@gmail.com", new DateTime(1923, 10, 21)));
            //3
           AddPerson(new Person("Benethumper","Rumperstiltskin ", "enethumper@gmail.com", new DateTime(1947, 9, 1)));
           AddPerson(new Person("Zingelbert","Bembleback", "ingelbert@gmail.com", new DateTime(2017, 8, 21)));
           AddPerson(new Person("Butterbean","Cobblepot", "utterbean@gmail.com", new DateTime(2004, 7, 30)));
           AddPerson(new Person("Butterscotch","Sugarpatch", "utterscotc@gmail.com", new DateTime(2000, 7, 29)));
           AddPerson(new Person("Cameldort","Dangledrink", "ameldort@gmail.com", new DateTime(1999, 8, 28)));
            //4
           AddPerson(new Person("Boobytrap","Cuckooclock", "oobytrap@gmail.com", new DateTime(1977, 9, 27)));
           AddPerson(new Person("Blubberbutt","Coochyrash", "lubberbutt@gmail.com", new DateTime(1966, 10, 26)));
           AddPerson(new Person("Billiardball","Scratchnsniff", "illiardball@gmail.com", new DateTime(1922, 11, 25)));
           AddPerson(new Person("Billboard", "Cummerbund", "illboard@gmail.com", new DateTime(1933, 12, 24)));
           AddPerson(new Person("Brandybuck", "Camouflage", "randybuck@gmail.com", new DateTime(2014, 12, 23)));
            //5
            AddPerson(new Person("Blubberdick","Candygram", "lubberdick@gmail.com", new DateTime(1962, 1, 21)));
            AddPerson(new Person("Billyray", "Colonist", "illyray@gmail.com", new DateTime(1935, 2, 22)));
            AddPerson(new Person("Burgerking","Stinkyrash", "urgerking@gmail.com", new DateTime(1978, 3, 30)));
            AddPerson(new Person("Bumbleprunk","Jangledort", "umbleprun@gmail.com", new DateTime(1969, 4, 17)));
            AddPerson(new Person("Bumbletumble","Humblecrumble", "umbletumble@gmail.com", new DateTime(1989, 5, 16)));
            //6
            AddPerson(new Person("Bundledip","Cabbagewank", "undledip@gmail.com", new DateTime(1928, 6, 20)));
            AddPerson(new Person("David","Bumblebryuh", "onaparte@gmail.com",  DateTime.Today));
            AddPerson(new Person("Bubblebath","Cuckooclock", "ubblebath@gmail.com", new DateTime(1977, 8, 18)));
            AddPerson(new Person("Bumberstump","Banglesnatch", "umberstump@gmail.com", new DateTime(1945, 9, 17)));
            AddPerson(new Person("Bettyboop","Snickersbar", "ettyboop@gmail.com", DateTime.Today));
            //7
            AddPerson(new Person("Boobytrap","Clombyclomp", "oobytrap@gmail.com", new DateTime(1955, 11, 15)));
            AddPerson(new Person("Englebert","Lemonscotch", "nglebert@gmail.com", new DateTime(1915, 12, 14)));
            AddPerson(new Person("Bunnytink","Twinklefluff", "unnytink@gmail.com", new DateTime(1951, 10, 13)));
            AddPerson(new Person("Butterkick","Candleblow", "utterkick@gmail.com", new DateTime(1937, 8, 12)));
            AddPerson(new Person("Badgerdonkey","Cobblebabble", "adgerdonkey@gmail.com", new DateTime(1929, 6, 11)));
            //8
            AddPerson(new Person("Birdflipper","Cummerbadger", "irdflipper@gmail.com", new DateTime(1994, 4, 10)));
            AddPerson(new Person("Biscuit","Crumblebeef", "iscuitg@mail.com", new DateTime(1944, 2, 9)));
            AddPerson(new Person("Bootstrap","Winklebash", "ootstrap@gmail.com", new DateTime(1948, 1, 8)));
            AddPerson(new Person("Waterproof","Comicdoor", "aterproof@gmail.com", new DateTime(1943, 3, 7)));
            AddPerson(new Person("Bunnyland","Crackershack", "unnyland@gmail.com", new DateTime(1928, 5, 6)));
            //9
            AddPerson(new Person("Babydodo","Cellarbirds", "abydodo@gmail.com", new DateTime(1980, 7, 5)));
            AddPerson(new Person("Badagod","Cabbagedapper", "adagod@gmail.com", new DateTime(2016, 9, 4)));
            AddPerson(new Person("Crumblegibble","Timberslacker", "rumblegibble@gmail.com", new DateTime(2005, 11, 3)));
            AddPerson(new Person("Badapimple","Pupperfatter", "adapimple@gmail.com", new DateTime(2007, 12, 2)));
            AddPerson(new Person("Bigbumble","Chunkybark", "igbumble@gmail.com", DateTime.Today));
            //10
            AddPerson(new Person("Bankerflipper","Mindtwitter", "ankerflipper@gmail.com", new DateTime(1948, 8, 2)));
            AddPerson(new Person("Bubblegum","Colontwitch", "ubblegum@gmail.com", DateTime.Today));
            AddPerson(new Person("Bumblebee","Cumbersnatch", "umblebee@gmail.com", new DateTime(1972, 12, 4)));
            AddPerson(new Person("Benadryl","Cockletit", "enadryl@gmail.com", new DateTime(1964, 3, 5)));
            AddPerson(new Person("Brinkledink", "Timberpiss", "rinkledink@gmail.com", new DateTime(2012, 1, 6)));



        }


    }
}

