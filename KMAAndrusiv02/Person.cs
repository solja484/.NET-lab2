using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KMAAndrusiv02
{
    internal class Person : INotifyPropertyChanged
    {
        #region Fields
        private bool _calculated = false;
        private string _name, _surname , _mail = "";
        private string _chinese, _sun;
        private bool _isAdult;
        private DateTime _birthday = DateTime.MinValue;
        #endregion

        public void Calculate()
        {
            _calculated = true;
            _sun = GetSunSign(_birthday);
            _chinese = GetChineseSign(_birthday.Year);
            _isAdult = Age >= 18;

            OnPropertyChanged($"ChineseSign");
            OnPropertyChanged($"SunSign");
            OnPropertyChanged($"IsBirthday");
            OnPropertyChanged($"IsAdult");
        }

        #region Constructors
        public Person(string name, string surname, string email, DateTime date)
        {
            _name = name;
            _surname = surname;
            _mail = email;
            _birthday = date;
            _calculated = false;
        }
        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _mail = email;
            _calculated = false;
        }

        public Person(string name, string surname, DateTime date)
        {
            _name = name;
            _surname = surname;
            _birthday = date;
            _calculated = false;
        }
        #endregion
        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _calculated = false;
                _name = value;
                OnPropertyChanged();

            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _calculated = false;
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _calculated = false;
                _birthday = value;
                OnPropertyChanged();

            }
        }
        #endregion


        #region Read only properties
        public int Age
        {
            get
            {
                if (!_calculated)
                    Calculate();
                return GetAge(_birthday);
            }
        }

        public bool IsAdult
        {
            get
            {
                if (!_calculated)
                    Calculate();
                return _isAdult;
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (!_calculated)
                    Calculate();
                return Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month;
            }
        }

        public string SunSign
        {
            get
            {
                if (!_calculated)
                    Calculate();
                return _sun;
            }
        }
        public string ChineseSign
        {
            get
            {
                if (!_calculated)
                    Calculate();
                return _chinese;
            }
        }

        #endregion

        #region Private methods
        private static string GetSunSign(DateTime bday)
        {
            var month = bday.Month;
            var day = bday.Day;
            switch (month)
            {
                case 1 when day < 20:
                case 12 when day > 21:
                    return "Capricorn";
                case 1 when day > 19:
                case 2 when day < 19:
                    return "Aquarius";
                case 2 when day > 18:
                case 3 when day < 21:
                    return "Pisces";
                case 3 when day > 20:
                case 4 when day < 20:
                    return "Aries";
                case 4 when day > 19:
                case 5 when day < 21:
                    return "Taurus";
                case 5 when day > 20:
                case 6 when day < 21:
                    return "Gemini";
                case 6 when day > 20:
                case 7 when day < 23:
                    return "Cancer";
                case 7 when day > 22:
                case 8 when day < 23:
                    return "Leo";
                case 8 when day > 22:
                case 9 when day < 23:
                    return "Virgo";
                case 9 when day > 22:
                case 10 when day < 23:
                    return "Libra";
                case 10 when day > 22:
                case 11 when day < 22:
                    return "Scorpio";
                case 11 when day > 21:
                case 12 when day < 22:
                    return "Sagittarius";
                default:
                    return "Capricorn";
            }
        }


        private static string GetChineseSign(int year)
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
            var age = DateTime.Today.Year - bday.Year;
          
            if (age == 0) return age;
            if (DateTime.Today.Month < bday.Month || DateTime.Today.Day < bday.Day)
                age--;

            return age;
        }

        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion#region INotifyPropertyChanged

    }
}
