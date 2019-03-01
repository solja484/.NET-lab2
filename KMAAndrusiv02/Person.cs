

using System;

namespace KMAAndrusiv02
{
    class Person
    {
        #region Fields
        private string _name = "", _surname = "", _mail = "";
        private DateTime _birthday = DateTime.MinValue;
        #endregion

        #region Constructors
        public Person(string name, string surname, string Email, DateTime Date)
        {
            _name = name;
            _surname = surname;
            _mail = Email;
            _birthday = Date;
        }
        public Person(string name, string surname, string Email)
        {
            _name = name;
            _surname = surname;
            _mail = Email;
        }

        public Person(string name, string surname, DateTime Date)
        {
            _name = name;
            _surname = surname;
            _birthday = Date;
        }
        #endregion
        #region Properties

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public String Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        public String Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
            }
        }
        #endregion


        #region Read only properties
        public int Age
        {
            get { return GetAge(Birthday); }
        }

        public bool IsAdult
        {
            get
            {
                if (GetAge(Birthday) >= 18)
                    return true;
                return false;
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month)
                    return true;
                return false;
            }
        }

        public string SunSign
        {
            get { return getSunSign(Birthday); }
        }
        public string ChineseSign
        {
            get { return getChineseSign(Birthday.Year); }
        }

        #endregion

        #region Private methods
        private static string getSunSign(DateTime bday)
        {
            int month = bday.Month;
            int day = bday.Day;
            if ((month == 1 && day < 20) || (month == 12 && day > 21)) return "Capricorn";
            if ((month == 1 && day > 19) || (month == 2 && day < 19)) return "Aquarius";
            if ((month == 2 && day > 18) || (month == 3 && day < 21)) return "Pisces";
            if ((month == 3 && day > 20) || (month == 4 && day < 20)) return "Aries";
            if ((month == 4 && day > 19) || (month == 5 && day < 21)) return "Taurus";
            if ((month == 5 && day > 20) || (month == 6 && day < 21)) return "Gemini";
            if ((month == 6 && day > 20) || (month == 7 && day < 23)) return "Cancer";
            if ((month == 7 && day > 22) || (month == 8 && day < 23)) return "Leo";
            if ((month == 8 && day > 22) || (month == 9 && day < 23)) return "Virgo";
            if ((month == 9 && day > 22) || (month == 10 && day < 23)) return "Libra";
            if ((month == 10 && day > 22) || (month == 11 && day < 22)) return "Scorpio";
            if ((month == 11 && day > 21) || (month == 12 && day < 22)) return "Sagittarius";
            return "Capricorn";
        }


        private static string getChineseSign(int year)
        {

            switch (year % 12)
            {
                case 11: return "Monkey";
                case 10: return "Horse";
                case 9: return "Snake";
                case 8: return "Dragon";
                case 7: return "Rabbit";
                case 6: return "Tiger";
                case 5: return "Bull";
                case 4: return "Rat";
                case 3: return "Pig";
                case 2: return "Dog";
                case 1: return "Chicken";
                default: return "Goat";
            }
        }


        private static int GetAge(DateTime bday)
        {
            int age = DateTime.Today.Year - bday.Year;
            if (age == 0) return 0;
            if (DateTime.Today.Month < bday.Month || DateTime.Today.Day < bday.Day)
                age--;

            return age;
        }

        #endregion


    }
}
