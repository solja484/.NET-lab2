using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using KMAAndrusiv02.NavigationTools;

namespace KMAAndrusiv02
{
    class PersonListViewModel:BaseViewModel
    {

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get
            {
                _persons = new ObservableCollection<Person>(Query);
                return _persons;
            }
            set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        internal PersonListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
        }

        private RelayCommand<object> _addCommand;

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand<object>(
                           o => NavigationManager.Instance.Navigate(ViewType.Input)));
            }
        }



        private RelayCommand<object> _saveCommand;

        public RelayCommand<object> SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand<object>(
                           SaveImplementation));
            }
        }

        private void SaveImplementation(object obj)
        {
            StationManager.DataStorage.SaveChanges();
        }

        private int _filterSunSign = 0, _filterChineseSign=0, _filterIsAdult=0, _filterIsBirthday=0;
        public int FilterSunSign
        {
            get { return _filterSunSign;}
            set
            {
                _filterSunSign = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }

        public int FilterChineseSign
        {
            get { return _filterChineseSign; }
            set
            {
                _filterChineseSign = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public int FilterIsAdult
        {
            get { return _filterIsAdult; }
            set
            {
                _filterIsAdult = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public int FilterIsBirthday
        {
            get { return _filterIsBirthday; }
            set
            {
                _filterIsBirthday = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }

        private string _filterName = "", _filterSurname = "", _filterMail = "";

        public string FilterName
        {
            get { return _filterName; }
            set
            {
                _filterName = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public string FilterSurname
        {
            get { return _filterSurname; }
            set
            {
                _filterSurname = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public string FilterMail
        {
            get { return _filterMail; }
            set
            {
                _filterMail = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        private DateTime _filterDate = DateTime.MinValue;
        public DateTime FilterDate
        {
            get { return _filterDate; }
            set
            {
                _filterDate = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public List<string> SunSignsList { get; } = new List<string>(new string[] { "All", "Capricorn","Aquarius","Pisces","Aries","Taurus","Gemini","Cancer","Leo","Virgo","Libra","Scorpio","Sagittarius"});

        public List<string> ChineseSignsList { get; } = new List<string>(new string[] { "All","Dragon", "Tiger", "Snake", "Chicken", "Pig", "Horse", "Dog", "Rat", "Bull", "Monkey", "Rabbit", "Goat" });

        public List<string> IsBirthdayList { get; } = new List<string>(new string[] {"All", "Today","Not today" });

        public List<string> IsAdultList { get; } = new List<string>(new string[] {"All","Adult","Child" });


        public IEnumerable<Person> Query
        {
            get
            {
                return (from p in StationManager.DataStorage.PersonsList
                    where p.Name.StartsWith(FilterName) 
                          && p.Surname.StartsWith(FilterSurname) 
                          && p.Mail.StartsWith(FilterMail) 
                          && (FilterDate.Equals(DateTime.MinValue) || p.Birthday.Equals(FilterDate)) 
                          && (FilterChineseSign == 0 || p.ChineseSign.Equals(ChineseSignsList[FilterChineseSign]))
                          && (FilterSunSign == 0 || p.SunSign.Equals(SunSignsList[FilterSunSign]))
                          && (FilterIsAdult == 0 || ((FilterIsAdult == 1) && p.IsAdult))
                          && (FilterIsBirthday == 0 || ((FilterIsBirthday == 1) && p.IsBirthday)) select p);
            }
        }
    }
}
