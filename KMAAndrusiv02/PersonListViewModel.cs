using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            get => _persons;
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
    }
}
