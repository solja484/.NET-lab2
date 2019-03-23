using KMAAndrusiv02.NavigationTools;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using KMAAndrusiv02.Managers;

namespace KMAAndrusiv02
{
    internal class PersonViewModel : BaseViewModel
    {


        #region Fields

        private PersonManager _personManager = PersonManager.Instance;

        private readonly Person _modelPerson = new Person("", "", "", DateTime.Today);
        private readonly Regex _mailRegex = new Regex(@"^[\w\.\d]+\@[\w\d]+\.[\w\d]{2,}$");

        #endregion


        #region Commands

        private RelayCommand<object> _calculateCommand, _backCommand;

        #endregion

        #region Properties

        private Person _personInstance = new Person("", "", "", DateTime.MinValue);

        public Person PersonInstance
        {
            get { return _personManager.PersonInstance; }
            set
            {
                _personInstance = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>((o) => NavigationManager.Instance.Navigate(ViewType.List)));
            }
        }

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(
                           ResultsImplementation, o => CanExecuteCommand()));
            }
        }

        #endregion



        private async void ResultsImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                PersonInstance.Calculate();
            });
            LoaderManager.Instance.HideLoader();

            try
            {
                if (!_mailRegex.IsMatch(PersonInstance.Mail))
                    throw new InvalidEmailException();

                if (PersonInstance.Birthday > DateTime.Today)
                    throw new AgeTooSmallException();
                
                if(PersonInstance.Age > 135)
                    throw new AgeTooBigException();

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }


            StationManager.DataStorage.AddPerson(new Person(PersonInstance.Name, PersonInstance.Surname, PersonInstance.Mail, PersonInstance.Birthday));
            PersonInstance.Name = "";
            PersonInstance.Surname = "";
            PersonInstance.Mail = "";
            PersonInstance.Birthday=DateTime.MinValue;
            NavigationManager.Instance.Navigate(ViewType.List);
        }



        public bool CanExecuteCommand()
        {
            return !PersonInstance.Name.Equals(string.Empty) && !PersonInstance.Mail.Equals(string.Empty)
                && !PersonInstance.Surname.Equals(string.Empty) && PersonInstance.Birthday != DateTime.MinValue;
        }



    }
}
