using KMAAndrusiv02.NavigationTools;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace KMAAndrusiv02
{
    internal class PersonViewModel : BaseViewModel
    {


        #region Fields

        private readonly Person _modelPerson = new Person("", "", "", DateTime.Today);
        private readonly Regex _mailRegex = new Regex(@"^[\w\.\d]+\@[\w\d]+\.[\w\d]{2,}$");

        #endregion


        #region Commands

        private RelayCommand<object> _calculateCommand;

        #endregion

        #region Properties

        public PersonManager PersonManagerInstance { get; } = PersonManager.Instance;

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
                PersonManagerInstance.PersonInstance.Calculate();
            });
            LoaderManager.Instance.HideLoader();

            try
            {
                if (!_mailRegex.IsMatch(PersonManagerInstance.PersonInstance.Mail))
                    throw new InvalidEmailException();

                if (PersonManagerInstance.PersonInstance.Birthday > DateTime.Today)
                    throw new AgeTooSmallException();
                
                if(PersonManagerInstance.PersonInstance.Age > 135)
                    throw new AgeTooBigException();

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            NavigationManager.Instance.Navigate(ViewType.Results);

            if (PersonManagerInstance.PersonInstance.Birthday.Day.Equals(DateTime.Today.Day) &&
                PersonManagerInstance.PersonInstance.Birthday.Month.Equals(DateTime.Today.Month))
            {
                if (PersonManagerInstance.PersonInstance.Age > 0)
                {
                    MessageBox.Show("Congratulations! It is your " + PersonManagerInstance.PersonInstance.Age + " birthday today!");
                }
                else
                {
                    MessageBox.Show("Congratulations to newborn!");
                }
            }


        }



        public bool CanExecuteCommand()
        {
            return !PersonManagerInstance.PersonInstance.Name.Equals(string.Empty) && !PersonManagerInstance.PersonInstance.Mail.Equals(string.Empty)
                && !PersonManagerInstance.PersonInstance.Surname.Equals(string.Empty) && PersonManagerInstance.PersonInstance.Birthday != DateTime.MinValue;
        }



    }
}
