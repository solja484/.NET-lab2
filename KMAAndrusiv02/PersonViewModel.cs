using KMAAndrusiv02.NavigationTools;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KMAAndrusiv02
{
    internal class PersonViewModel : BaseViewModel
    {


        #region Fields

        private Person _modelPerson = new Person("", "", "", DateTime.Today);

        #endregion


        #region Commands

        RelayCommand<object> _calculateCommand;

        #endregion

        #region Properties

        private PersonManager _personManagerInstance = PersonManager.Instance;

        public PersonManager PersonManagerInstance
        {
            get
            {
                return _personManagerInstance;
            }
        }

        public RelayCommand<Object> CalculateCommand
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

         
           
            if (PersonManagerInstance.PersonInstance.Age < 0 || PersonManagerInstance.PersonInstance.Age > 135)
            {
                MessageBox.Show("You enter wrong date!" + PersonManagerInstance.PersonInstance.Age);
                return;
            }


            NavigationManager.Instance.Navigate(ViewType.Results);

            if (PersonManagerInstance.PersonInstance.Birthday.Day.Equals(DateTime.Today.Day) &&
                PersonManagerInstance.PersonInstance.Birthday.Month.Equals(DateTime.Today.Month))
            {
                if (PersonManagerInstance.PersonInstance.Age > 0)
                {
                    MessageBox.Show("Congradulations! It is your " + PersonManagerInstance.PersonInstance.Age + " birthday today!");
                }
                else
                {
                    MessageBox.Show("Congradulations to newborn!");
                }
            }


        }
        


        public bool CanExecuteCommand()
        {
            return !PersonManagerInstance.PersonInstance.Name.Equals(String.Empty) && !PersonManagerInstance.PersonInstance.Mail.Equals(String.Empty)
                && !PersonManagerInstance.PersonInstance.Surname.Equals(String.Empty) && PersonManagerInstance.PersonInstance.Birthday != DateTime.MinValue;
        }



    }
}
