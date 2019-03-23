using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KMAAndrusiv02.Managers;
using KMAAndrusiv02.NavigationTools;

namespace KMAAndrusiv02
{
    class PersonListViewModel : BaseViewModel
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

        private Person _selectedPerson;

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

        private RelayCommand<object> _deleteCommand;

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(
                           DeleteImplementation, (o) => SelectedPerson != null));
            }
        }

        private void DeleteImplementation(object obj)
        {
            StationManager.DataStorage.DeletePerson(SelectedPerson);
            OnPropertyChanged($"Persons");
        }

        private void SaveImplementation(object obj)
        {
            StationManager.DataStorage.SaveChanges();
        }

        private int _filterSunSign, _filterChineseSign, _filterIsAdult, _filterIsBirthday;
        public int FilterSunSign
        {
            get => _filterSunSign;
            set
            {
                _filterSunSign = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }

        public int FilterChineseSign
        {
            get => _filterChineseSign;
            set
            {
                _filterChineseSign = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public int FilterIsAdult
        {
            get => _filterIsAdult;
            set
            {
                _filterIsAdult = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public int FilterIsBirthday
        {
            get => _filterIsBirthday;
            set
            {
                _filterIsBirthday = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }

        private string _filterName = "", _filterSurname = "", _filterMail = "";

        public string FilterName
        {
            get => _filterName;
            set
            {
                _filterName = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public string FilterSurname
        {
            get => _filterSurname;
            set
            {
                _filterSurname = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public string FilterMail
        {
            get => _filterMail;
            set
            {
                _filterMail = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        private DateTime _filterDate = DateTime.MinValue;
        public DateTime FilterDate
        {
            get => _filterDate;
            set
            {
                _filterDate = value;
                Persons = new ObservableCollection<Person>(Query);
            }
        }
        public List<string> SunSignsList { get; } = new List<string>(new[] { "All", "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" });

        public List<string> ChineseSignsList { get; } = new List<string>(new[] { "All", "Dragon", "Tiger", "Snake", "Chicken", "Pig", "Horse", "Dog", "Rat", "Bull", "Monkey", "Rabbit", "Goat" });

        public List<string> IsBirthdayList { get; } = new List<string>(new[] { "All", "Today", "Not today" });

        public List<string> IsAdultList { get; } = new List<string>(new[] { "All", "Adult", "Child" });

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Person> Query =>
            from p in StationManager.DataStorage.PersonsList
            where p.Name.StartsWith(FilterName)
                  && p.Surname.StartsWith(FilterSurname)
                  && p.Mail.StartsWith(FilterMail)
                  && (FilterDate.Equals(DateTime.MinValue) || p.Birthday.Equals(FilterDate))
                  && (FilterChineseSign == 0 || p.ChineseSign.Equals(ChineseSignsList[FilterChineseSign]))
                  && (FilterSunSign == 0 || p.SunSign.Equals(SunSignsList[FilterSunSign]))
                  && (FilterIsAdult == 0 || ((FilterIsAdult == 1) && p.IsAdult))
                  && (FilterIsBirthday == 0 || ((FilterIsBirthday == 1) && p.IsBirthday))
            select p;
    }
}
